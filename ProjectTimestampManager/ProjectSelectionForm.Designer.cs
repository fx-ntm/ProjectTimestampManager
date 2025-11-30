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
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 25);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 0;
            label1.Text = "Project Timestamp Manager";
            label1.Click += label1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 98);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(157, 94);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 2;
            label2.Text = "Available Projects";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(323, 80);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 3;
            label3.Text = "Manage ...";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(323, 107);
            button1.Name = "button1";
            button1.Size = new Size(137, 23);
            button1.TabIndex = 4;
            button1.Text = "New Project";
            button1.UseVisualStyleBackColor = true;
            // 
            // ProjectSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 450);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "ProjectSelectionForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}
