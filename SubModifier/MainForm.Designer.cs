using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace SubModifier
{
    partial class MainForm
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
            this.Controls.Clear();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpen_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenSubtitle_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenFolder_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLanguaje_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.espanolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitles_DataGridView = new System.Windows.Forms.DataGridView();
            this.btn_Transform = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtitles_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // file_ToolStripMenuItem
            // 
            this.file_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpen_ToolStripMenuItem,
            this.fileLanguaje_ToolStripMenuItem});
            this.file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            resources.ApplyResources(this.file_ToolStripMenuItem, "file_ToolStripMenuItem");
            // 
            // fileOpen_ToolStripMenuItem
            // 
            this.fileOpen_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenSubtitle_ToolStripMenuItem,
            this.fileOpenFolder_ToolStripMenuItem});
            this.fileOpen_ToolStripMenuItem.Name = "fileOpen_ToolStripMenuItem";
            resources.ApplyResources(this.fileOpen_ToolStripMenuItem, "fileOpen_ToolStripMenuItem");
            // 
            // fileOpenSubtitle_ToolStripMenuItem
            // 
            this.fileOpenSubtitle_ToolStripMenuItem.Name = "fileOpenSubtitle_ToolStripMenuItem";
            resources.ApplyResources(this.fileOpenSubtitle_ToolStripMenuItem, "fileOpenSubtitle_ToolStripMenuItem");
            this.fileOpenSubtitle_ToolStripMenuItem.Click += new System.EventHandler(this.fileOpenSubtitle_ToolStripMenuItem_Click);
            // 
            // fileOpenFolder_ToolStripMenuItem
            // 
            this.fileOpenFolder_ToolStripMenuItem.Name = "fileOpenFolder_ToolStripMenuItem";
            resources.ApplyResources(this.fileOpenFolder_ToolStripMenuItem, "fileOpenFolder_ToolStripMenuItem");
            this.fileOpenFolder_ToolStripMenuItem.Click += new System.EventHandler(this.fileOpenFolder_ToolStripMenuItem_Click);
            // 
            // fileLanguaje_ToolStripMenuItem
            // 
            this.fileLanguaje_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.espanolToolStripMenuItem});
            this.fileLanguaje_ToolStripMenuItem.Name = "fileLanguaje_ToolStripMenuItem";
            resources.ApplyResources(this.fileLanguaje_ToolStripMenuItem, "fileLanguaje_ToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // espanolToolStripMenuItem
            // 
            this.espanolToolStripMenuItem.Name = "espanolToolStripMenuItem";
            resources.ApplyResources(this.espanolToolStripMenuItem, "espanolToolStripMenuItem");
            this.espanolToolStripMenuItem.Click += new System.EventHandler(this.espanolToolStripMenuItem_Click);
            // 
            // subtitles_DataGridView
            // 
            this.subtitles_DataGridView.AllowUserToAddRows = false;
            this.subtitles_DataGridView.AllowUserToDeleteRows = false;
            this.subtitles_DataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.subtitles_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.subtitles_DataGridView, "subtitles_DataGridView");
            this.subtitles_DataGridView.Name = "subtitles_DataGridView";
            this.subtitles_DataGridView.ReadOnly = true;
            this.subtitles_DataGridView.RowHeadersVisible = false;
            this.subtitles_DataGridView.RowTemplate.Height = 24;
            // 
            // btn_Transform
            // 
            resources.ApplyResources(this.btn_Transform, "btn_Transform");
            this.btn_Transform.Name = "btn_Transform";
            this.btn_Transform.UseVisualStyleBackColor = true;
            this.btn_Transform.Click += new System.EventHandler(this.btn_Transform_Click);
            // 
            // btn_Clear
            // 
            resources.ApplyResources(this.btn_Clear, "btn_Clear");
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Transform);
            this.Controls.Add(this.subtitles_DataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtitles_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpen_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenSubtitle_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenFolder_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileLanguaje_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem espanolToolStripMenuItem;
        private DataGridView subtitles_DataGridView;
        private Button btn_Transform;
        private Button btn_Clear;
    }
}

