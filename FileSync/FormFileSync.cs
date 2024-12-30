using Microsoft.VisualBasic.FileIO;

namespace FileSync
{
    //TODO: fazer em uma thread separada
    //TODO: soncronizar diretórios primeiro
    //TODO: tratar exceção pra cada arquivo pra não parar
    //TODO: 

    public partial class FormFileSync : Form
    {
        List<string> sourceFiles = new List<string>();
        List<string> targetFiles = new List<string>();
        List<string> deleteFiles = new List<string>();
        List<string> addFiles = new List<string>();
        List<string> modifyFiles = new List<string>();

        public FormFileSync()
        {
            InitializeComponent();
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);

            textBoxSource.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonTarget_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);

            textBoxTarget.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            try
            {
                labelFileSync.Text = "-";
                labelFileSync.Refresh();
                listBoxAdd.Items.Clear();
                listBoxAdd.Refresh();
                listBoxModify.Items.Clear();
                listBoxModify.Refresh();
                listBoxDelete.Items.Clear();
                listBoxDelete.Refresh();

                addFiles.Clear();
                modifyFiles.Clear();
                deleteFiles.Clear();

                if (textBoxSource.Text == "") return;

                if (textBoxTarget.Text == "") return;

                sourceFiles = Directory.GetFiles(textBoxSource.Text, "*", System.IO.SearchOption.AllDirectories).ToList();
                targetFiles = Directory.GetFiles(textBoxTarget.Text, "*", System.IO.SearchOption.AllDirectories).ToList();

                progressBar1.Minimum = 0;
                progressBar1.Maximum = sourceFiles.Count;
                progressBar1.Value = 0;

                // Synchronize files
                foreach (string sourceFilePath in sourceFiles)
                {
                    progressBar1.Value += 1;
                    progressBar1.Refresh();

                    string relativePath = GetRelativePath(textBoxSource.Text, sourceFilePath);
                    string targetFilePath = Path.Combine(textBoxTarget.Text, relativePath);

                    if (!File.Exists(targetFilePath))
                    {
                        addFiles.Add(sourceFilePath);
                        listBoxAdd.Items.Add(sourceFilePath);
                        listBoxAdd.Refresh();
                    }
                    else if (File.GetLastWriteTime(sourceFilePath) > File.GetLastWriteTime(targetFilePath))
                    {
                        modifyFiles.Add(sourceFilePath);
                        listBoxModify.Items.Add(sourceFilePath);
                        listBoxModify.Refresh();
                    }
                    else
                    {
                        foreach (string targetFile in targetFiles)
                        {
                            relativePath = GetRelativePath(textBoxTarget.Text, targetFile);
                            targetFilePath = Path.Combine(textBoxSource.Text, relativePath);

                            if (!File.Exists(sourceFilePath))
                            {
                                deleteFiles.Add(targetFilePath);
                                listBoxDelete.Items.Add(targetFilePath);
                                listBoxDelete.Refresh();
                            }
                        }
                    }
                }

                if (addFiles.Count + modifyFiles.Count + deleteFiles.Count == 0)
                {
                    labelFileSync.Text = "The target folder is up to date";
                    labelFileSync.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            try
            {
                labelFileSync.Text = "-";

                if (addFiles.Count == 0 && modifyFiles.Count == 0 && deleteFiles.Count == 0)
                {
                    labelFileSync.Text = "No files synced";
                    labelFileSync.Refresh();
                    return;
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = addFiles.Count + modifyFiles.Count + deleteFiles.Count;
                progressBar1.Value = 0;

                var dir = "";

                foreach (var file in addFiles)
                {
                    var targetFile = Path.Combine(textBoxTarget.Text, GetRelativePath(textBoxSource.Text, file));

                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                    labelFileSync.Text = "Copying " + file;
                    labelFileSync.Refresh();

                    dir = Path.GetDirectoryName(targetFile);

                    if (!Directory.Exists(targetFile))
                    {
                        if (dir != null)
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }

                    File.Copy(file, targetFile);
                }

                foreach (var file in modifyFiles)
                {
                    var targetFile = Path.Combine(textBoxTarget.Text, GetRelativePath(textBoxSource.Text, file));

                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                    labelFileSync.Text = "Copying " + file;
                    labelFileSync.Refresh();

                    File.Copy(file, targetFile, true);
                }

                foreach (var file in deleteFiles)
                {
                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                    labelFileSync.Text = "Deleting " + file;
                    labelFileSync.Refresh();

                    FileSystem.DeleteFile(file,
                      UIOption.OnlyErrorDialogs,
                      RecycleOption.SendToRecycleBin);
                }

                labelFileSync.Text = "Finished";
                labelFileSync.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string GetRelativePath(string basePath, string fullPath)
        {
            // Ensure the paths are properly normalized
            basePath = Path.GetFullPath(basePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            fullPath = Path.GetFullPath(fullPath);

            return Path.GetRelativePath(basePath, fullPath);
        }
    }
}