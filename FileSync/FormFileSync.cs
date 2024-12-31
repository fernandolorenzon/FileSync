using Microsoft.VisualBasic.FileIO;

namespace FileSync
{
    //TODO: fazer em uma thread separada
    //TODO: sincronizar diretórios primeiro
    //TODO: tratar exceção pra cada arquivo pra não parar
    //TODO: botão Stop

    public partial class FormFileSync : Form
    {
        List<string> sourceFiles = new List<string>();
        List<string> targetFiles = new List<string>();
        List<string> sourceFolders = new List<string>();
        List<string> targetFolders = new List<string>();
        List<string> deleteFiles = new List<string>();
        List<string> addFiles = new List<string>();
        List<string> updateFiles = new List<string>();
        List<string> addFolders = new List<string>();
        List<string> deleteFolders = new List<string>();

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
                ClearItems();

                if (!ValidateSourceAndTarget())
                {
                    labelStatus.Text = "Inform the source and the target directory";
                    return;
                }

                SetSourceTargetLists();

                SetLists();

                if (CountSyncItems() == 0)
                {
                    labelStatus.Text = "The target folder is up to date";
                    labelStatus.Refresh();
                }

                UpdateLabelsLists();
            }
            catch (Exception ex)
            {
                labelStatus.Text = "-";
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "-";

                if (CountSyncItems() == 0)
                {
                    labelStatus.Text = "No files synced";
                    labelStatus.Refresh();
                    return;
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = CountSyncItems();
                progressBar1.Value = 0;

                AddFolders();

                DeleteFolders();

                AddFiles();

                UpdateFiles();

                DeleteFiles();

                labelStatus.Text = "Finished";
                labelStatus.Refresh();
            }
            catch (Exception ex)
            {
                labelStatus.Text = "-";
                MessageBox.Show(ex.Message);
            }
        }

        private int CountSyncItems()
        {
            return addFolders.Count + deleteFolders.Count + addFiles.Count + updateFiles.Count + deleteFiles.Count;
        }

        private void DeleteFiles()
        {
            foreach (var file in deleteFiles)
            {
                progressBar1.Value += 1;
                progressBar1.Refresh();
                labelStatus.Text = "Deleting " + file;
                labelStatus.Refresh();

                FileSystem.DeleteFile(file,
                  UIOption.OnlyErrorDialogs,
                  RecycleOption.SendToRecycleBin);
            }
        }

        private void UpdateFiles()
        {
            foreach (var file in updateFiles)
            {
                var targetFile = Path.Combine(textBoxTarget.Text, GetRelativePath(textBoxSource.Text, file));

                progressBar1.Value += 1;
                progressBar1.Refresh();
                labelStatus.Text = "Copying " + file;
                labelStatus.Refresh();

                File.Copy(file, targetFile, true);
            }
        }

        private void AddFiles()
        {
            foreach (var file in addFiles)
            {
                var targetFile = Path.Combine(textBoxTarget.Text, GetRelativePath(textBoxSource.Text, file));

                progressBar1.Value += 1;
                progressBar1.Refresh();
                labelStatus.Text = "Copying " + file;
                labelStatus.Refresh();

                File.Copy(file, targetFile);
            }
        }

        private void DeleteFolders()
        {

            // Delete folders
            foreach (var folder in deleteFolders)
            {
                Directory.Delete(folder, true);
                progressBar1.Value += 1;
                progressBar1.Refresh();
                labelStatus.Text = "Deleting " + folder;
                labelStatus.Refresh();
            }
        }

        private void AddFolders()
        {

            // Create folders
            foreach (var folder in addFolders)
            {
                var targetFolder = Path.Combine(textBoxTarget.Text, GetRelativePath(textBoxSource.Text, folder));
                Directory.CreateDirectory(targetFolder);
                progressBar1.Value += 1;
                progressBar1.Refresh();
                labelStatus.Text = "Creating " + targetFolder;
                labelStatus.Refresh();
            }
        }

        private void UpdateLabelsLists()
        {
            labelAdd.Text = (addFolders.Count + addFiles.Count).ToString();
            labelModify.Text = updateFiles.Count.ToString();
            labelDelete.Text = (deleteFolders.Count + deleteFiles.Count).ToString();
        }

        private void SetSourceTargetLists()
        {
            sourceFolders = Directory.GetDirectories(textBoxSource.Text, "*", System.IO.SearchOption.AllDirectories).ToList();
            sourceFiles = Directory.GetFiles(textBoxSource.Text, "*", System.IO.SearchOption.AllDirectories).ToList();

            targetFolders = Directory.GetDirectories(textBoxTarget.Text, "*", System.IO.SearchOption.AllDirectories).ToList();
            targetFiles = Directory.GetFiles(textBoxTarget.Text, "*", System.IO.SearchOption.AllDirectories).ToList();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = sourceFiles.Count;
            progressBar1.Value = 0;
        }

        private bool ValidateSourceAndTarget()
        {
            if (textBoxSource.Text == "" || textBoxTarget.Text == "") return false;

            return true;
        }

        private void SetLists()
        {
            var relativePath = "";
            var sourcePath = "";
            var sourceDir = "";
            var targetFilePath = "";
            var targetDir = "";

            // Find directories to create
            foreach (var item in sourceFolders)
            {
                relativePath = GetRelativePath(textBoxSource.Text, item);

                targetDir = Path.Combine(textBoxTarget.Text, relativePath);

                if (!Directory.Exists(targetDir))
                {
                    addFolders.Add(item);
                    listBoxAdd.Items.Add(relativePath + "\\");
                    listBoxAdd.Refresh();
                }
            }

            // Find directories to delete
            foreach (var item in targetFolders)
            {
                relativePath = GetRelativePath(textBoxTarget.Text, item);

                sourceDir = Path.Combine(textBoxSource.Text, relativePath);

                if (!Directory.Exists(sourceDir))
                {
                    deleteFolders.Add(item);
                    listBoxDelete.Items.Add(relativePath + "\\");
                    listBoxDelete.Refresh();
                }
            }

            // Find files to add
            foreach (string item in sourceFiles)
            {
                progressBar1.Value += 1;
                progressBar1.Refresh();

                relativePath = GetRelativePath(textBoxSource.Text, item);
                targetFilePath = Path.Combine(textBoxTarget.Text, relativePath);

                if (!File.Exists(targetFilePath))
                {
                    addFiles.Add(item);
                    listBoxAdd.Items.Add(relativePath);
                    listBoxAdd.Refresh();
                }
                else if (File.GetLastWriteTime(item) > File.GetLastWriteTime(targetFilePath))
                {
                    updateFiles.Add(item);
                    listBoxUpdate.Items.Add(relativePath);
                    listBoxUpdate.Refresh();
                }
            }

            // Find files to delete
            foreach (string item in targetFiles)
            {
                relativePath = GetRelativePath(textBoxTarget.Text, item);
                sourcePath = Path.Combine(textBoxSource.Text, relativePath);

                if (!File.Exists(sourcePath))
                {
                    deleteFiles.Add(item);
                    listBoxDelete.Items.Add(relativePath);
                    listBoxDelete.Refresh();
                }
            }

            RemoveFilesToDelete();
        }

        public static string GetRelativePath(string basePath, string fullPath)
        {
            basePath = Path.GetFullPath(basePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            fullPath = Path.GetFullPath(fullPath);

            return Path.GetRelativePath(basePath, fullPath);
        }

        private void ClearItems()
        {
            labelStatus.Text = "-";
            labelStatus.Refresh();
            listBoxAdd.Items.Clear();
            listBoxAdd.Refresh();
            listBoxUpdate.Items.Clear();
            listBoxUpdate.Refresh();
            listBoxDelete.Items.Clear();
            listBoxDelete.Refresh();

            addFiles.Clear();
            updateFiles.Clear();
            deleteFiles.Clear();
            addFolders.Clear();
            deleteFolders.Clear();

            labelAdd.Text = "-";
            labelModify.Text = "-";
            labelDelete.Text = "-";
        }

        private void RemoveFilesToDelete()
        {
            foreach (var folder in deleteFolders)
            {
                deleteFiles.RemoveAll(x => x.StartsWith(folder));
            }
        }
    }
}