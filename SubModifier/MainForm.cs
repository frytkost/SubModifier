using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SubModifier.BusinessLogic;
using SubModifier.Entities;

namespace SubModifier
{
    public partial class MainForm : Form
    {
        private string _suportedFilesExtentions;
        private SubtitleManager _subtitleManager = new SubtitleManager();

        private readonly ResourceManager _resourceManager =
            new ResourceManager("SubModifier.MainForm", typeof(MainForm).Assembly);

        private List<Subtitle> _subtitles;

        public BindingList<Info> Data { get; }

        private string SuportedFilesExtentions
        {
            get
            {
                if (string.IsNullOrEmpty(_suportedFilesExtentions))
                {
                    string suportedExtensionsConfig = Utils.Configs.HardCodeConfigs.SuportedExtensions;
                    string[] suportedExtensions = suportedExtensionsConfig.Split(',');
                    StringBuilder builder = new StringBuilder();
                    foreach (string extension in suportedExtensions)
                    {
                        builder.Append("*.");
                        builder.Append(extension);
                        builder.Append(";");
                    }

                    builder.Remove(builder.Length - 1, 1);
                    _suportedFilesExtentions = builder.ToString();
                }

                return _suportedFilesExtentions;
            }
        }

        public MainForm()
        {
            Data = new BindingList<Info>();
            InitializeComponent();

            subtitles_DataGridView.AllowUserToAddRows = false;
        }

        private void SwitchLanguage(string languageCode)
        {
            switch (languageCode)
            {
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    InitializeComponent();
                    break;
                case "es":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                    InitializeComponent();
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    InitializeComponent();
                    break;
            }
        }

        private void fileOpenSubtitle_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filterText = _resourceManager.GetString(Utils.Resources.ResourceKeys.OpenSubtitleFileDialogTitle);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // ReSharper disable once LocalizableElement
                Filter = $"{filterText} | {SuportedFilesExtentions}",
                Title = _resourceManager.GetString(Utils.Resources.ResourceKeys.OpenSubtitleFileDialogTitle)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Subtitle subtitle = new Subtitle(openFileDialog.FileName);
                UpdateGrid(new List<Subtitle> {subtitle});
                //_subtitleManager.TransformSubtitle(subtitle);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchLanguage("en");
            UpdateGrid(_subtitles);
        }

        private void espanolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchLanguage("es");
            UpdateGrid(_subtitles);
        }


        private void UpdateGrid(List<Subtitle> subtitles)
        {
            _subtitles = subtitles ?? new List<Subtitle>();

            subtitles_DataGridView.Rows.Clear();
            Data.Clear();
            bool showSuccess = false;
            foreach (var subtitle in _subtitles)
            {
                Data.Add(new Info
                {
                    Id = subtitle.Id,
                    Name = subtitle.Name,
                    Transform = subtitle.Transform,
                    Success = subtitle.Success
                });

                if (subtitle.Success != null)
                {
                    showSuccess = true;
                }
            }

            subtitles_DataGridView.DataSource = Data;
            bool showScroll = Data.Count >= 13;

            foreach (DataGridViewColumn column in subtitles_DataGridView.Columns)
            {
                switch (column.DataPropertyName)
                {
                    case "Id":
                        column.Visible = false;
                        break;
                    case "Name":
                        int extraSpace = showSuccess ? 2 * 56 : 56;
                        int lockSpace = 3;
                        int scrollSpace = showScroll ? 18 : 0;
                        column.Width = subtitles_DataGridView.Width - extraSpace - lockSpace - scrollSpace;
                        column.Visible = Data.Count > 0;
                        break;
                    case "Transform":
                        column.Width = 56;
                        column.Visible = Data.Count > 0;
                        break;
                    case "Success":
                        column.Width = 56;
                        column.Visible = showSuccess;
                        break;
                }
                column.Resizable = DataGridViewTriState.False;
            }
        }

        private void fileOpenFolder_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog
            {
                Description = _resourceManager.GetString(Utils.Resources.ResourceKeys.OpenSubtitleFileDialogTitle),
                ShowNewFolderButton = false
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dinfo = new DirectoryInfo(folderDialog.SelectedPath);
                string[] multipleStrings = SuportedFilesExtentions.Split(';');
                List<Subtitle> subtitles = new List<Subtitle>();
                List<FileInfo> allFiles = new List<FileInfo>();

                foreach (string filter in multipleStrings)
                {
                    FileInfo[] files = dinfo.GetFiles(filter);
                    allFiles.AddRange(files);
                }

                foreach (FileInfo file in allFiles)
                {
                    Subtitle subtitle = new Subtitle(file.FullName);
                    subtitles.Add(subtitle);
                }

                UpdateGrid(subtitles);
                //_subtitleManager.TransformSubtitle(subtitle);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            UpdateGrid(new List<Subtitle>());
            subtitles_DataGridView.DataSource = null;
        }

        private void btn_Transform_Click(object sender, EventArgs e)
        {
            if (subtitles_DataGridView.DataSource is BindingList<Info> dataSource)
            {
                foreach (Info info in dataSource)
                {
                    var subtitle = _subtitles.FirstOrDefault(x => x.Id == info.Id);
                    if (subtitle != null)
                    {
                        subtitle.Transform = info.Transform;
                    }
                }

                _subtitleManager.TransformSubtitles(_subtitles.ToList());
                UpdateGrid(_subtitles);
            }
        }
    }

    public class Info
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Transform { get; set; }
        public bool? Success { get; set; }
    }
}