using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;



namespace Move_n_link
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button_src_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSRC.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void Destination_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button_dest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxDEST.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Help file is in the works. Stay tuned", "No help yet", MessageBoxButtons.OK);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!Program.IsAdministrator())
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Administrator privileges are required to create symbolic links. Would you like to restart the application as administrator?",
                    "Administrator Privileges Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (Program.TryRestartAsAdministrator())
                    {
                        Application.Exit();
                    }
                }
                return;
            }

            //Show source path test
            MessageBox.Show(textBoxSRC.Text, "Source", MessageBoxButtons.OK);

            //Show dest path test
            MessageBox.Show(textBoxDEST.Text, "Destination", MessageBoxButtons.OK);

            //Yeah...I haven't the slightest clue how to do error handling with C# and Win32API so we're YOLOing it
            //try
            //{
            //    Directory.Move(textBoxSRC.Text, textBoxDEST.Text);
            //}

            //catch (IOException)
            //{
            //    if (Directory.Exists(textBoxDEST.Text))
            //    {
            //        // Ask the user if they want to overwrite
            //        DialogResult result = MessageBox.Show("File already exists. Overwrite?", "Overwrite Confirmation", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.Yes)
            //        {
            //            Directory.Delete(textBoxDEST.Text);
            //            Directory.Move(textBoxSRC.Text, textBoxDEST.Text);
            //        }
            //    }
            //}


            string sourcePath = textBoxSRC.Text.Trim();
            string destinationPath = textBoxDEST.Text.Trim();

            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                MessageBox.Show("Please select both a source and a destination path.", "Missing Paths", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("The source directory does not exist.", "Invalid Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Win32FileUtils.CopyDirectoryAcrossFilesystems(sourcePath, destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy directory: {ex.Message}", "Copy Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Directory.Delete(sourcePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Files were copied to destination, but failed to delete original source folder: {ex.Message}", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Directory.CreateSymbolicLink(sourcePath, destinationPath);
                MessageBox.Show("Symbolic link created successfully.", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex2)
            {
                MessageBox.Show($"The source folder was moved, but creating the symbolic link failed: {ex2.Message}", "Link Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


//Why in the heck doesn't C# have a way to move a folder across filesystems?
//This is janky as heck. I don't like it. But I couldn't find any better way.
//This would be easier to do in VB.net but I haaaaad to use C#
//So what did I end up doing? Having to do all this BS in Win32API
public static class Win32FileUtils
{
    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

    private struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public uint wFunc;
        [MarshalAs(UnmanagedType.LPWStr)] public string pFrom;
        [MarshalAs(UnmanagedType.LPWStr)] public string pTo;
        public ushort
 fFlags;
        public bool fAnyOperationsAborted;
        public IntPtr hNameMappings;
        [MarshalAs(UnmanagedType.LPWStr)] public string lpszProgressTitle;

    }

    private
 const uint FO_COPY = 2;
    private const ushort FOF_NOCONFIRMATION = 0x0010; // Suppress confirmation dialogs
    private const ushort FOF_NOCONFIRMMKDIR = 0x0200; // Don't confirm creating new directories
    private const ushort FOF_NOERRORUI = 0x0400; // No error UI 

    public static void CopyDirectoryAcrossFilesystems(string sourceDir, string destinationDir)
    {
        SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT
        {
            wFunc = FO_COPY,
            pFrom = sourceDir + '\0', // Null-terminated string
            pTo = destinationDir + '\0',
            fFlags = FOF_NOCONFIRMATION | FOF_NOCONFIRMMKDIR | FOF_NOERRORUI
        };

        int result = SHFileOperation(ref fileOp);
        if (result != 0)
        {
            throw new Exception("Error copying directory: " + result);
        }
        if (fileOp.fAnyOperationsAborted)
        {
            throw new Exception("Copy operation was aborted.");
        }
    }
}

