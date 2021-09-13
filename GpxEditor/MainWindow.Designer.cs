namespace GpxEditor
{
    partial class MainWindow
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
            this.lbl_ChooseDir = new System.Windows.Forms.Label();
            this.tb_ChooseDir = new System.Windows.Forms.TextBox();
            this.bt_Generate = new System.Windows.Forms.Button();
            this.bt_Browse = new System.Windows.Forms.Button();
            this.tb_Console = new System.Windows.Forms.TextBox();
            this.lbl_Console = new System.Windows.Forms.Label();
            this.bt_BrowseOutput = new System.Windows.Forms.Button();
            this.tb_Output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ChooseDir
            // 
            this.lbl_ChooseDir.AutoSize = true;
            this.lbl_ChooseDir.Location = new System.Drawing.Point(39, 31);
            this.lbl_ChooseDir.Name = "lbl_ChooseDir";
            this.lbl_ChooseDir.Size = new System.Drawing.Size(187, 17);
            this.lbl_ChooseDir.TabIndex = 0;
            this.lbl_ChooseDir.Text = "Podaj ścieżkę do plików gpx:";
            // 
            // tb_ChooseDir
            // 
            this.tb_ChooseDir.Location = new System.Drawing.Point(42, 57);
            this.tb_ChooseDir.Name = "tb_ChooseDir";
            this.tb_ChooseDir.Size = new System.Drawing.Size(470, 22);
            this.tb_ChooseDir.TabIndex = 1;
            this.tb_ChooseDir.Leave += new System.EventHandler(this.tb_ChooseDir_Leave);
            // 
            // bt_Generate
            // 
            this.bt_Generate.Location = new System.Drawing.Point(42, 161);
            this.bt_Generate.Name = "bt_Generate";
            this.bt_Generate.Size = new System.Drawing.Size(184, 29);
            this.bt_Generate.TabIndex = 2;
            this.bt_Generate.Text = "Generuj nowe pliki";
            this.bt_Generate.UseVisualStyleBackColor = true;
            this.bt_Generate.Click += new System.EventHandler(this.bt_Generate_Click);
            // 
            // bt_Browse
            // 
            this.bt_Browse.Location = new System.Drawing.Point(518, 53);
            this.bt_Browse.Name = "bt_Browse";
            this.bt_Browse.Size = new System.Drawing.Size(101, 30);
            this.bt_Browse.TabIndex = 3;
            this.bt_Browse.Text = "Przeglądaj";
            this.bt_Browse.UseVisualStyleBackColor = true;
            this.bt_Browse.Click += new System.EventHandler(this.bt_Browse_Click);
            // 
            // tb_Console
            // 
            this.tb_Console.Location = new System.Drawing.Point(42, 253);
            this.tb_Console.Multiline = true;
            this.tb_Console.Name = "tb_Console";
            this.tb_Console.ReadOnly = true;
            this.tb_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Console.Size = new System.Drawing.Size(577, 196);
            this.tb_Console.TabIndex = 4;
            // 
            // lbl_Console
            // 
            this.lbl_Console.AutoSize = true;
            this.lbl_Console.Location = new System.Drawing.Point(39, 220);
            this.lbl_Console.Name = "lbl_Console";
            this.lbl_Console.Size = new System.Drawing.Size(63, 17);
            this.lbl_Console.TabIndex = 5;
            this.lbl_Console.Text = "Konsola:";
            // 
            // bt_BrowseOutput
            // 
            this.bt_BrowseOutput.Location = new System.Drawing.Point(518, 119);
            this.bt_BrowseOutput.Name = "bt_BrowseOutput";
            this.bt_BrowseOutput.Size = new System.Drawing.Size(101, 30);
            this.bt_BrowseOutput.TabIndex = 7;
            this.bt_BrowseOutput.Text = "Przeglądaj";
            this.bt_BrowseOutput.UseVisualStyleBackColor = true;
            this.bt_BrowseOutput.Click += new System.EventHandler(this.bt_BrowseOutput_Click);
            // 
            // tb_Output
            // 
            this.tb_Output.Location = new System.Drawing.Point(42, 123);
            this.tb_Output.Name = "tb_Output";
            this.tb_Output.Size = new System.Drawing.Size(470, 22);
            this.tb_Output.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Podaj ścieżkę do plików wyjściowych:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 483);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_BrowseOutput);
            this.Controls.Add(this.tb_Output);
            this.Controls.Add(this.lbl_Console);
            this.Controls.Add(this.tb_Console);
            this.Controls.Add(this.bt_Browse);
            this.Controls.Add(this.bt_Generate);
            this.Controls.Add(this.tb_ChooseDir);
            this.Controls.Add(this.lbl_ChooseDir);
            this.Name = "MainWindow";
            this.Text = "GpxEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ChooseDir;
        private System.Windows.Forms.TextBox tb_ChooseDir;
        private System.Windows.Forms.Button bt_Generate;
        private System.Windows.Forms.Button bt_Browse;
        private System.Windows.Forms.TextBox tb_Console;
        private System.Windows.Forms.Label lbl_Console;
        private System.Windows.Forms.Button bt_BrowseOutput;
        private System.Windows.Forms.TextBox tb_Output;
        private System.Windows.Forms.Label label1;
    }
}

