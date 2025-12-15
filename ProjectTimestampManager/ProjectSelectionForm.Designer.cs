namespace ProjectTimestampManager
{
    partial class ProjectSelectionForm
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
            label1 = new Label();
            listBox1 = new ListBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            menuStrip1 = new MenuStrip();
            juhjhToolStripMenuItem = new ToolStripMenuItem();
            ujhggToolStripMenuItem = new ToolStripMenuItem();
            viewProjectsToolStripMenuItem = new ToolStripMenuItem();
            createProjectToolStripMenuItem = new ToolStripMenuItem();
            finishProjectToolStripMenuItem = new ToolStripMenuItem();
            finishedProjectToolStripMenuItem = new ToolStripMenuItem();
            version10ToolStripMenuItem = new ToolStripMenuItem();
            gitHubFxntmToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(100, 29);
            label1.Name = "label1";
            label1.Size = new Size(225, 21);
            label1.TabIndex = 0;
            label1.Text = "Project Timestamp Manager";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 201);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(413, 94);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(262, 80);
            button1.Name = "button1";
            button1.Size = new Size(163, 71);
            button1.TabIndex = 4;
            button1.Text = "New Project";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(172, 15);
            label2.TabIndex = 5;
            label2.Text = "Please select an existing project";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 6;
            label3.Text = "or create a new project";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 183);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 7;
            label4.Text = "Project list";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(25, 346);
            button2.Name = "button2";
            button2.Size = new Size(114, 44);
            button2.TabIndex = 8;
            button2.Text = "Open";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(283, 346);
            button3.Name = "button3";
            button3.Size = new Size(114, 44);
            button3.TabIndex = 9;
            button3.Text = "Close the Program";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { juhjhToolStripMenuItem, ujhggToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(437, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // juhjhToolStripMenuItem
            // 
            juhjhToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewProjectsToolStripMenuItem, finishProjectToolStripMenuItem, createProjectToolStripMenuItem, finishedProjectToolStripMenuItem });
            juhjhToolStripMenuItem.Name = "juhjhToolStripMenuItem";
            juhjhToolStripMenuItem.Size = new Size(56, 20);
            juhjhToolStripMenuItem.Text = "Project";
            juhjhToolStripMenuItem.Click += juhjhToolStripMenuItem_Click;
            // 
            // ujhggToolStripMenuItem
            // 
            ujhggToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { version10ToolStripMenuItem, gitHubFxntmToolStripMenuItem });
            ujhggToolStripMenuItem.Name = "ujhggToolStripMenuItem";
            ujhggToolStripMenuItem.Size = new Size(40, 20);
            ujhggToolStripMenuItem.Text = "Info";
            // 
            // viewProjectsToolStripMenuItem
            // 
            viewProjectsToolStripMenuItem.Name = "viewProjectsToolStripMenuItem";
            viewProjectsToolStripMenuItem.Size = new Size(180, 22);
            viewProjectsToolStripMenuItem.Text = "Open Project ...";
            viewProjectsToolStripMenuItem.Click += viewProjectsToolStripMenuItem_Click;
            // 
            // createProjectToolStripMenuItem
            // 
            createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
            createProjectToolStripMenuItem.Size = new Size(180, 22);
            createProjectToolStripMenuItem.Text = "Create Project";
            createProjectToolStripMenuItem.Click += createProjectToolStripMenuItem_Click;
            // 
            // finishProjectToolStripMenuItem
            // 
            finishProjectToolStripMenuItem.Name = "finishProjectToolStripMenuItem";
            finishProjectToolStripMenuItem.Size = new Size(180, 22);
            finishProjectToolStripMenuItem.Text = "Finish Project ...";
            finishProjectToolStripMenuItem.Click += finishProjectToolStripMenuItem_Click;
            // 
            // finishedProjectToolStripMenuItem
            // 
            finishedProjectToolStripMenuItem.Name = "finishedProjectToolStripMenuItem";
            finishedProjectToolStripMenuItem.Size = new Size(180, 22);
            finishedProjectToolStripMenuItem.Text = "Finished Projects";
            finishedProjectToolStripMenuItem.Click += finishedProjectToolStripMenuItem_Click;
            // 
            // version10ToolStripMenuItem
            // 
            version10ToolStripMenuItem.Name = "version10ToolStripMenuItem";
            version10ToolStripMenuItem.Size = new Size(180, 22);
            version10ToolStripMenuItem.Text = "Version 1.0";
            // 
            // gitHubFxntmToolStripMenuItem
            // 
            gitHubFxntmToolStripMenuItem.Name = "gitHubFxntmToolStripMenuItem";
            gitHubFxntmToolStripMenuItem.Size = new Size(180, 22);
            gitHubFxntmToolStripMenuItem.Text = "GitHub @ fx-ntm";
            // 
            // ProjectSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Name = "ProjectSelectionForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem juhjhToolStripMenuItem;
        private ToolStripMenuItem ujhggToolStripMenuItem;
        private ToolStripMenuItem viewProjectsToolStripMenuItem;
        private ToolStripMenuItem createProjectToolStripMenuItem;
        private ToolStripMenuItem finishProjectToolStripMenuItem;
        private ToolStripMenuItem finishedProjectToolStripMenuItem;
        private ToolStripMenuItem version10ToolStripMenuItem;
        private ToolStripMenuItem gitHubFxntmToolStripMenuItem;
    }
}
