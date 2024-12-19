namespace Manhattan
{
    public partial class MainWindow : Form
    {
        string _CycleDirectory;
        string CycleDirectory { get { return _CycleDirectory; } set { CycleDirectoryTextBox.Text = value; _CycleDirectory = value; }  }

        string _UnitDirectory;
        string UnitDirectory { get { return _UnitDirectory; } set { UnitDirectoryTextBox.Text = value; _UnitDirectory = value; } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectUnitDirectoryButton_Click(object sender, EventArgs e)
        {
            if (CycleDirectoryFolderDialogur.ShowDialog() == DialogResult.OK)
            { 
                CycleDirectory = CycleDirectoryFolderDialogur.SelectedPath;
                UnitDirectory = Path.GetDirectoryName(CycleDirectoryFolderDialogur.SelectedPath);
            }
        }
    }
}
