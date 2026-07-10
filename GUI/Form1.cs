using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {

        static string RemoveDiacritics(string text)  //https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }


        private string soutezNameLatinized;
           
        private string d_projectRoot;
        private string d_archive;
        private string d_archiveSource;
        private string d_archiveDestination;

        private class ParsedData
        {
            public string soutezNazev { get;set;}
            public string soutezDatum { get;set;}
            public List<string> kategorie { get;set;}
            public List<Dictionary<string,string>> teamy { get;set;}

            public DateTime datumToDatetime()
            {
                string[] formats = new string[]
                {
                   "d.M. yyyy",
                   "d.M. yyyy (HH:mm)"
                };
                DateTime result;
                if (DateTime.TryParseExact(soutezDatum, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;
                else
                    return DateTime.Now;
            }

            public void UpdateData(string soutez, string datum, DataGridViewRowCollection teamy)
            {

            }
        }

        private ParsedData data;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            d_projectRoot = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            Console.WriteLine("project root: "+d_projectRoot);

            //načítání dat z parsedData.js
            string json = string.Join("\n",File.ReadAllLines(d_projectRoot+"\\Web\\soutez\\parsedData.js").Skip(1));
            data = JsonSerializer.Deserialize<ParsedData>(json);
            jmeno_tb.Text = data.soutezNazev;
            datum_dt.Value = data.datumToDatetime();
            soutezNameLatinized = RemoveDiacritics(data.soutezNazev).Replace(" ", string.Empty);
            this.g_kategorie.DataSource = data.kategorie;

            foreach(Dictionary<string, string> team in data.teamy)
                dataGridView1.Rows.Add(team["jmeno"],team["kategorie"],team["levy"], team["pravy"]);

            d_archiveSource = d_projectRoot+"\\Web\\soutez\\";
            d_archive = d_projectRoot+"\\Web\\archiv\\";
            d_archiveDestination = d_projectRoot+"\\Web\\archiv\\"+soutezNameLatinized;

            //TODO: git
        }   

        private string normalizeTime(string str)
        {
            //vrací normalizovaný string ve formátu MM:SS:MLS
            //při chybě hazí InvalidDataException

            string padNum(string numStr)
            {
                return numStr.PadLeft(2, '0');
            }

            string padMili(string numStr)
            {
                return numStr.PadRight(3,'0');
            }

            string[] tempNums = str.Split(new char[]{' ',':',';',',','.','_','-','/','*','+','?'});
            List<string> nums = new List<string>();

            foreach(string num in tempNums)
                if(num.Length != 0)
                    nums.Add(num);
            
            if(nums.Count == 0)
                return "";

            if(nums[0].IndexOf("np",StringComparison.OrdinalIgnoreCase) >= 0) 
                return "NP";

            foreach(string num in nums)
            { 
                int res;
                if(int.TryParse(num, out res) == false)
                    throw new InvalidDataException(str);
            }

            

            switch(nums.Count)
            {
                case 1:
                    return $"00:{padNum(nums[0])}.000";
                    
                case 2:
                    if(nums[0].Length == 1)
                        return $"{padNum(nums[0])}:{padNum(nums[1])}.000";
                    else
                        return $"00:{padNum(nums[0])}.{padMili(nums[1])}";

                case 3:
                    return $"{padNum(nums[0])}:{padNum(nums[1])}.{padMili(nums[2])}";
                    
                default:
                    throw new InvalidDataException(str);
            }
            
            
        }

        private void normalizeTimeCells()
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = normalizeTime((string)row.Cells[2].Value ?? "");
                row.Cells[3].Value = normalizeTime((string)row.Cells[3].Value ?? "");
            }
        }

        private void updateParsedData()
        {
            try
            {normalizeTimeCells();}
            catch(Exception e)
            {
                if(e is InvalidDataException)
                    MessageBox.Show($"Špatný formát času: \"{e.Message}\" (má být MM:SS.MIL). \nZměny neodeslány.");
                else
                    MessageBox.Show("Chyba při formátování času, zkontrolujte formát.\n"+e.Message);
                return;
            }
            
            data.soutezNazev = jmeno_tb.Text;
            data.soutezDatum = datum_dt.Value.ToString();
                
            data.teamy.Clear();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.IsNewRow == false)
                    data.teamy.Add(new Dictionary<string, string>()
                    { 
                        {"jmeno",(string)row.Cells[0].Value ?? "" },
                        {"kategorie",(string)row.Cells[1].Value ?? "" },
                        {"levy",(string)row.Cells[2].Value ?? "" },
                        {"pravy",(string)row.Cells[3].Value ?? "" }
                    });
            }   

            string updatedStr = "let data = \n" + JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            //Console.WriteLine(updatedStr);
            
            File.WriteAllText(d_projectRoot+"\\Web\\soutez\\parsedData.js", updatedStr);
        }


        public void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/k " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            
            Process = Process.Start(ProcessInfo);
        }

        private void aktualizovat_Click(object sender, EventArgs e)
        {
            updateParsedData();


            ExecuteCommand(d_projectRoot+"\\sendWebsiteData.bat");
            MessageBox.Show("Data odeslána. Za minutu by měly být viditelná.");

            //git add .
            //git commit -m "app website update"
            //git subtree push --prefix Web origin gh-pages
        }

        private void archivovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateParsedData();

            //zápis do archivu
            List<string> archiveLines = File.ReadAllLines(d_archive+"archivData.js").ToList();
            archiveLines.RemoveAt(archiveLines.Count-1);
            if(archiveLines.Count > 1)
                archiveLines[archiveLines.Count-1] += ',';
            

            foreach(string line in archiveLines) //odstraní předchozí záznam
            {
                if(line.IndexOf(soutezNameLatinized) != -1)
                    if(MessageBox.Show($"Záznam pro soutěž {soutezNameLatinized} již existuje.\nPřepsat?","Přepsat záznam?", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return;
                    else
                        {archiveLines.Remove(line); break; }
            }

            archiveLines.Add($"{{\"jmeno\":\"{data.soutezNazev}\",\"cesta\":\"{soutezNameLatinized}/index.html\"}}");
            archiveLines.Add("]");

            File.WriteAllLines(d_archive+"archivData.js",archiveLines);
           

            //přesouvání souborů
            Directory.CreateDirectory(d_archiveDestination);
            FileInfo[] files = new DirectoryInfo(d_archiveSource).GetFiles();

            foreach(FileInfo file in files) 
                file.CopyTo(d_archiveDestination+"\\"+file.Name, true);
           
            MessageBox.Show("Soutěž archivována do podsložky "+soutezNameLatinized);
        }


        private void vyčistitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            data = new ParsedData();
            
            jmeno_tb.Text = "";
            kategorie_tb.Text = "";

        }

        private void kategorie_pridat_Click(object sender, EventArgs e)
        {
            data.kategorie.Add(this.kategorie_tb.Text);
        }

        private void kategorie_odebrat_Click(object sender, EventArgs e)
        {
            for(int i=0; i<dataGridView1.RowCount; i++)
            {
                if(dataGridView1[1,i].Value != null && 
                ((string)dataGridView1[1,i].Value).Replace(" ",string.Empty) == kategorie_tb.Text.Replace(" ", string.Empty))
                {
                    dataGridView1[1,i].Value = null;
                }
            }
            data.kategorie.Remove(this.kategorie_tb.Text);
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs ev)
        {
                        try
            {normalizeTimeCells();}
            catch(Exception e)
            {
                if(e is InvalidDataException)
                    MessageBox.Show($"Špatný formát času: \"{e.Message}\" (má být MM:SS.MIL). \nZměny neodeslány.");
                else
                    MessageBox.Show("Chyba při formátování času, zkontrolujte formát.\n"+e.Message);
                return;
            }
        }
    }
}
