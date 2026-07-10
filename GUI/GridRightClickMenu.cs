using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private int rightClick_row;

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClick_row = dataGridView1.HitTest(e.X,e.Y).RowIndex;
                GridRightClickMenu.Show(MousePosition);
            }
        }

        private void posunoutNahoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rightClick_row > 0 && rightClick_row < dataGridView1.Rows.Count-1)
            {
                DataGridViewRow tmp = dataGridView1.Rows[rightClick_row];
                dataGridView1.Rows.RemoveAt(rightClick_row);
                dataGridView1.Rows.Insert(rightClick_row-1, tmp);

                for(int i=0; i<dataGridView1.Rows.Count; i++)
                    dataGridView1.Rows[i].Selected = false;

                dataGridView1.Rows[rightClick_row-1].Selected = true;
            }
                
        }

        private void posunoutDolůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rightClick_row >= 0 && rightClick_row < dataGridView1.Rows.Count-2)
            {
                DataGridViewRow tmp = dataGridView1.Rows[rightClick_row];
                dataGridView1.Rows.RemoveAt(rightClick_row);
                dataGridView1.Rows.Insert(rightClick_row+1, tmp);

                for(int i=0; i<dataGridView1.Rows.Count; i++)
                    dataGridView1.Rows[i].Selected = false;

                dataGridView1.Rows[rightClick_row+1].Selected = true;
            }
                
        }

        private void vyčistitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(rightClick_row >= 0 && rightClick_row < dataGridView1.Rows.Count-1)
                for(int i=0; i<dataGridView1.Columns.Count; i++)
                    dataGridView1[i, rightClick_row].Value = "";
        }

        private void odstranitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rightClick_row >= 0 && rightClick_row < dataGridView1.Rows.Count-1)
                dataGridView1.Rows.RemoveAt(rightClick_row);
        }

    }
}
