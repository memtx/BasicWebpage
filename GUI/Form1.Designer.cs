namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.archivovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyčistitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jmeno_tb = new System.Windows.Forms.TextBox();
            this.datum_dt = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.g_nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_kategorie = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.g_LP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_PP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.posunoutNahoruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posunoutDolůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyčistitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.odstranitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.kategorie_tb = new System.Windows.Forms.TextBox();
            this.kategorie_odebrat = new System.Windows.Forms.Button();
            this.kategorie_pridat = new System.Windows.Forms.Button();
            this.topMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GridRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aktualizovat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.aktualizovat_Click);
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivovatToolStripMenuItem,
            this.vyčistitToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(800, 24);
            this.topMenu.TabIndex = 1;
            this.topMenu.Text = "menuStrip1";
            // 
            // archivovatToolStripMenuItem
            // 
            this.archivovatToolStripMenuItem.Name = "archivovatToolStripMenuItem";
            this.archivovatToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.archivovatToolStripMenuItem.Text = "Archivovat";
            this.archivovatToolStripMenuItem.Click += new System.EventHandler(this.archivovatToolStripMenuItem_Click);
            // 
            // vyčistitToolStripMenuItem
            // 
            this.vyčistitToolStripMenuItem.Name = "vyčistitToolStripMenuItem";
            this.vyčistitToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.vyčistitToolStripMenuItem.Text = "Vyčistit Vše";
            this.vyčistitToolStripMenuItem.Click += new System.EventHandler(this.vyčistitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "JménoSoutěže";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum Konání";
            // 
            // jmeno_tb
            // 
            this.jmeno_tb.Location = new System.Drawing.Point(13, 45);
            this.jmeno_tb.Name = "jmeno_tb";
            this.jmeno_tb.Size = new System.Drawing.Size(300, 20);
            this.jmeno_tb.TabIndex = 5;
            // 
            // datum_dt
            // 
            this.datum_dt.CustomFormat = "dd.MM. yyyy (HH:mm)";
            this.datum_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum_dt.Location = new System.Drawing.Point(319, 45);
            this.datum_dt.Name = "datum_dt";
            this.datum_dt.Size = new System.Drawing.Size(158, 20);
            this.datum_dt.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g_nazev,
            this.g_kategorie,
            this.g_LP,
            this.g_PP});
            this.dataGridView1.Location = new System.Drawing.Point(16, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(772, 338);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // g_nazev
            // 
            this.g_nazev.HeaderText = "Název Družstva";
            this.g_nazev.Name = "g_nazev";
            // 
            // g_kategorie
            // 
            this.g_kategorie.HeaderText = "Kategorie";
            this.g_kategorie.Name = "g_kategorie";
            this.g_kategorie.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.g_kategorie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // g_LP
            // 
            this.g_LP.HeaderText = "LP";
            this.g_LP.Name = "g_LP";
            // 
            // g_PP
            // 
            this.g_PP.HeaderText = "PP";
            this.g_PP.Name = "g_PP";
            // 
            // GridRightClickMenu
            // 
            this.GridRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posunoutNahoruToolStripMenuItem,
            this.posunoutDolůToolStripMenuItem,
            this.vyčistitToolStripMenuItem1,
            this.odstranitToolStripMenuItem});
            this.GridRightClickMenu.Name = "GridRightClickMenu";
            this.GridRightClickMenu.Size = new System.Drawing.Size(167, 92);
            // 
            // posunoutNahoruToolStripMenuItem
            // 
            this.posunoutNahoruToolStripMenuItem.Name = "posunoutNahoruToolStripMenuItem";
            this.posunoutNahoruToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.posunoutNahoruToolStripMenuItem.Text = "Posunout nahoru";
            this.posunoutNahoruToolStripMenuItem.Click += new System.EventHandler(this.posunoutNahoruToolStripMenuItem_Click);
            // 
            // posunoutDolůToolStripMenuItem
            // 
            this.posunoutDolůToolStripMenuItem.Name = "posunoutDolůToolStripMenuItem";
            this.posunoutDolůToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.posunoutDolůToolStripMenuItem.Text = "Posunout dolů";
            this.posunoutDolůToolStripMenuItem.Click += new System.EventHandler(this.posunoutDolůToolStripMenuItem_Click);
            // 
            // vyčistitToolStripMenuItem1
            // 
            this.vyčistitToolStripMenuItem1.Name = "vyčistitToolStripMenuItem1";
            this.vyčistitToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.vyčistitToolStripMenuItem1.Text = "Vyčistit";
            this.vyčistitToolStripMenuItem1.Click += new System.EventHandler(this.vyčistitToolStripMenuItem1_Click);
            // 
            // odstranitToolStripMenuItem
            // 
            this.odstranitToolStripMenuItem.Name = "odstranitToolStripMenuItem";
            this.odstranitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.odstranitToolStripMenuItem.Text = "Odstranit";
            this.odstranitToolStripMenuItem.Click += new System.EventHandler(this.odstranitToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kategorie";
            // 
            // kategorie_tb
            // 
            this.kategorie_tb.Location = new System.Drawing.Point(547, 45);
            this.kategorie_tb.Name = "kategorie_tb";
            this.kategorie_tb.Size = new System.Drawing.Size(121, 20);
            this.kategorie_tb.TabIndex = 10;
            // 
            // kategorie_odebrat
            // 
            this.kategorie_odebrat.Location = new System.Drawing.Point(674, 43);
            this.kategorie_odebrat.Name = "kategorie_odebrat";
            this.kategorie_odebrat.Size = new System.Drawing.Size(56, 23);
            this.kategorie_odebrat.TabIndex = 11;
            this.kategorie_odebrat.Text = "Odebrat";
            this.kategorie_odebrat.UseVisualStyleBackColor = true;
            this.kategorie_odebrat.Click += new System.EventHandler(this.kategorie_odebrat_Click);
            // 
            // kategorie_pridat
            // 
            this.kategorie_pridat.Location = new System.Drawing.Point(736, 42);
            this.kategorie_pridat.Name = "kategorie_pridat";
            this.kategorie_pridat.Size = new System.Drawing.Size(52, 23);
            this.kategorie_pridat.TabIndex = 12;
            this.kategorie_pridat.Text = "Přidat";
            this.kategorie_pridat.UseVisualStyleBackColor = true;
            this.kategorie_pridat.Click += new System.EventHandler(this.kategorie_pridat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kategorie_pridat);
            this.Controls.Add(this.kategorie_odebrat);
            this.Controls.Add(this.kategorie_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.datum_dt);
            this.Controls.Add(this.jmeno_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "Form1";
            this.Text = "Kontrolní Panel";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GridRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem archivovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyčistitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jmeno_tb;
        private System.Windows.Forms.DateTimePicker datum_dt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kategorie_tb;
        private System.Windows.Forms.Button kategorie_odebrat;
        private System.Windows.Forms.Button kategorie_pridat;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_nazev;
        private System.Windows.Forms.DataGridViewComboBoxColumn g_kategorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_LP;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_PP;
        private System.Windows.Forms.ContextMenuStrip GridRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem posunoutNahoruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posunoutDolůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odstranitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyčistitToolStripMenuItem1;
    }
}

