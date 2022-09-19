namespace DSPLinker
{
    partial class DSPLinker
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.manipulate = new System.Windows.Forms.ToolStripMenuItem();
            this.analyze = new System.Windows.Forms.ToolStripMenuItem();
            this.link = new System.Windows.Forms.ToolStripMenuItem();
            this.show = new System.Windows.Forms.ToolStripMenuItem();
            this.sorters = new System.Windows.Forms.ToolStripMenuItem();
            this.markers = new System.Windows.Forms.ToolStripMenuItem();
            this.belts = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.manipulate,
            this.show});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "open";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(37, 21);
            this.file.Text = "file";
            // 
            // open
            // 
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(180, 22);
            this.open.Text = "open";
            this.open.Click += new System.EventHandler(this.openMenuItemClicked);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(180, 22);
            this.save.Text = "save";
            this.save.Click += new System.EventHandler(this.saveMenuClicked);
            // 
            // manipulate
            // 
            this.manipulate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyze,
            this.link});
            this.manipulate.Name = "manipulate";
            this.manipulate.Size = new System.Drawing.Size(84, 21);
            this.manipulate.Text = "manipulate";
            // 
            // analyze
            // 
            this.analyze.Name = "analyze";
            this.analyze.Size = new System.Drawing.Size(119, 22);
            this.analyze.Text = "analyze";
            this.analyze.Click += new System.EventHandler(this.analyzeBlueprint);
            // 
            // link
            // 
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(119, 22);
            this.link.Text = "link";
            this.link.Click += new System.EventHandler(this.linkBlueprint);
            // 
            // show
            // 
            this.show.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sorters,
            this.markers,
            this.belts});
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(50, 21);
            this.show.Text = "show";
            // 
            // sorters
            // 
            this.sorters.Name = "sorters";
            this.sorters.Size = new System.Drawing.Size(124, 22);
            this.sorters.Text = "sorters";
            this.sorters.Click += new System.EventHandler(this.showSorters);
            // 
            // markers
            // 
            this.markers.Name = "markers";
            this.markers.Size = new System.Drawing.Size(124, 22);
            this.markers.Text = "markers";
            this.markers.Click += new System.EventHandler(this.showMarers);
            // 
            // belts
            // 
            this.belts.Name = "belts";
            this.belts.Size = new System.Drawing.Size(124, 22);
            this.belts.Text = "belts";
            this.belts.Click += new System.EventHandler(this.showBelts);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(0, 28);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(784, 534);
            this.textBox.TabIndex = 1;
            // 
            // DSPLinker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DSPLinker";
            this.Text = "DSPLinker";
            this.Load += new System.EventHandler(this.DSPLinker_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem file;
        private TextBox textBox;
        private ToolStripMenuItem manipulate;
        private ToolStripMenuItem show;
        private ToolStripMenuItem analyze;
        private ToolStripMenuItem link;
        private ToolStripMenuItem open;
        private ToolStripMenuItem save;
        private ToolStripMenuItem sorters;
        private ToolStripMenuItem markers;
        private ToolStripMenuItem belts;
    }
}