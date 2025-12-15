using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectTimestampManager.Models;
using ProjectTimestampManager.Services;

namespace ProjectTimestampManager
{
    /// <summary>
    /// Form to display finished projects
    /// </summary>
    public partial class FinishedProjectsForm : Form
    {
        private ProjectService projectService;
        private DataGridView dataGridView1;

        public FinishedProjectsForm()
        {
            InitializeFormComponents();
            projectService = new ProjectService();
            LoadFinishedProjects();
        }

        /// <summary>
        /// Generate content for the form
        /// </summary>
        private void InitializeFormComponents()
        {
            this.Text = "Finished Projects";
            this.Size = new System.Drawing.Size(500, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            dataGridView1 = new DataGridView();
            dataGridView1.Location = new System.Drawing.Point(10, 10);
            dataGridView1.Size = new System.Drawing.Size(465, 250);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add("Name", "Project Name");
            dataGridView1.Columns.Add("AllocatedHours", "Allocated Hours");
            dataGridView1.Columns.Add("Deadline", "Deadline");

            this.Controls.Add(dataGridView1);

            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Location = new System.Drawing.Point(200, 270);
            closeButton.Size = new System.Drawing.Size(80, 30);
            closeButton.Click += (s, e) => this.Close();
            this.Controls.Add(closeButton);
        }

        /// <summary>
        /// Load finished projects into the form
        /// </summary>
        private void LoadFinishedProjects()
        {
            dataGridView1.Rows.Clear();
            List<Project> allProjects = projectService.GetAllProjects();

            foreach (Project project in allProjects)
            {
                if (project.Deadline < DateTime.Now)
                {
                    dataGridView1.Rows.Add(
                        project.Name,
                        project.AllocatedHours,
                        project.Deadline.ToString("yyyy-MM-dd")
                    );
                }
            }
        }
    }
}
