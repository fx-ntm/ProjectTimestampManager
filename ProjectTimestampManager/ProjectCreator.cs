using System;
using System.Windows.Forms;
using ProjectTimestampManager.Services;

namespace ProjectTimestampManager
{
    public partial class ProjectCreator : Form
    {
        /// <summary>
        /// Service for project operations
        /// </summary>
        private ProjectService projectService;

        public ProjectCreator()
        {
            InitializeComponent();
            projectService = new ProjectService();
        }

        /// <summary>
        /// Button click to create a new project
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string projectName = textBox1.Text.Trim();
            int allocatedHours = (int)numericUpDown1.Value;
            DateTime deadline = dateTimePicker1.Value;
            if (string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Please enter a project name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (allocatedHours <= 0)
            {
                MessageBox.Show("Please enter a valid number of allocated hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (deadline < DateTime.Now)
            {
                MessageBox.Show("Deadline must be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try {
                projectService.AddProject(projectName, allocatedHours, deadline);
            } catch (Exception ex) {
                MessageBox.Show($"Error creating project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Project created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
