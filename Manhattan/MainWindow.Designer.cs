namespace Manhattan
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CycleDirectoryTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            справToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            SelectCycleDirectoryButton = new Button();
            label2 = new Label();
            UnitDirectoryTextBox = new TextBox();
            CycleDirectoryFolderDialogur = new FolderBrowserDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // CycleDirectoryTextBox
            // 
            CycleDirectoryTextBox.Location = new Point(12, 55);
            CycleDirectoryTextBox.Name = "CycleDirectoryTextBox";
            CycleDirectoryTextBox.ReadOnly = true;
            CycleDirectoryTextBox.Size = new Size(378, 23);
            CycleDirectoryTextBox.TabIndex = 999;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, справToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(499, 24);
            menuStrip1.TabIndex = 9999;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            // 
            // справToolStripMenuItem
            // 
            справToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
            справToolStripMenuItem.Name = "справToolStripMenuItem";
            справToolStripMenuItem.Size = new Size(65, 20);
            справToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(149, 22);
            оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "Cycle directory:";
            // 
            // SelectCycleDirectoryButton
            // 
            SelectCycleDirectoryButton.Location = new Point(396, 55);
            SelectCycleDirectoryButton.Name = "SelectCycleDirectoryButton";
            SelectCycleDirectoryButton.Size = new Size(91, 23);
            SelectCycleDirectoryButton.TabIndex = 10;
            SelectCycleDirectoryButton.Text = "Обзор";
            SelectCycleDirectoryButton.UseVisualStyleBackColor = true;
            SelectCycleDirectoryButton.Click += SelectUnitDirectoryButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 10000;
            label2.Text = "Unit directory:";
            // 
            // UnitDirectoryTextBox
            // 
            UnitDirectoryTextBox.Location = new Point(12, 99);
            UnitDirectoryTextBox.Name = "UnitDirectoryTextBox";
            UnitDirectoryTextBox.ReadOnly = true;
            UnitDirectoryTextBox.Size = new Size(378, 23);
            UnitDirectoryTextBox.TabIndex = 10002;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 450);
            Controls.Add(SelectCycleDirectoryButton);
            Controls.Add(label2);
            Controls.Add(UnitDirectoryTextBox);
            Controls.Add(label1);
            Controls.Add(CycleDirectoryTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Manhattan";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CycleDirectoryTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem справToolStripMenuItem;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private Label label1;
        private Button SelectCycleDirectoryButton;
        private Label label2;
        private TextBox UnitDirectoryTextBox;
        private FolderBrowserDialog CycleDirectoryFolderDialogur;
    }
}
