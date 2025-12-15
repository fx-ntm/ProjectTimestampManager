using ProjectTimestampManager.Models;
using ProjectTimestampManager.Services;
using System.Drawing;

namespace ProjectTimestampManager
{
    public partial class ProjectSelectionForm : Form
    {
        private ProjectService projectService;
        private TimeEntryService timeEntryService;
        private List<Project> projects;

        public ProjectSelectionForm()
        {
            InitializeComponent();
            projectService = new ProjectService();
            timeEntryService = new TimeEntryService();
            projects = new List<Project>();

            // Enable owner-draw for red text on high usage projects
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += ListBox1_DrawItem;

            this.Load += ProjectSelectionForm_Load;
        }

        /// <summary>
        /// Custom draw for ListBox - red text for projects at 90% capacity
        /// </summary>
        private void ListBox1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= projects.Count) return;

            e.DrawBackground();

            Project project = projects[e.Index];
            int usedMinutes = timeEntryService.GetTotalMinutesForProject(project.Id);
            int allocatedMinutes = project.AllocatedHours * 60;
            bool isHighUsage = allocatedMinutes > 0 && usedMinutes >= (allocatedMinutes * 0.9);

            Color textColor = isHighUsage ? Color.Red : e.ForeColor;
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(project.Name, e.Font!, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        private void ProjectSelectionForm_Load(object? sender, EventArgs e)
        {
            LoadProjects();
        }

        /// <summary>
        /// Load all projects from the database into the ListBox
        /// </summary>
        private void LoadProjects()
        {
            listBox1.Items.Clear();
            projects = projectService.GetAllProjects();
            foreach (Project project in projects)
            {
                listBox1.Items.Add(project.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Close the Program button click
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// New Project button click to open the ProjectCreator form
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ProjectCreator projectCreator = new ProjectCreator();
            projectCreator.FormClosed += ProjectCreator_FormClosed;
            projectCreator.Show();
        }

        /// <summary>
        /// Event handler for when ProjectCreator form is closed to refresh the project list
        /// </summary>
        private void ProjectCreator_FormClosed(object? sender, FormClosedEventArgs e)
        {
            LoadProjects();
        }

        /// <summary>
        /// Open button click to opens the TimeTracking form for the selected project
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                // Get the selected project from the list
                Project selectedProject = projects[listBox1.SelectedIndex];
                TimeTracking timeTracking = new TimeTracking(selectedProject);
                timeTracking.Show();
            }
            else
            {
                MessageBox.Show("Please select a project to open.", "No Project Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void juhjhToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Menu: Open Project
        /// </summary>
        private void viewProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        /// <summary>
        /// Menu: Create Project
        /// </summary>
        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        /// <summary>
        /// Menu: Finish Project
        /// </summary>
        private void finishProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a project to finish.", "No Project Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Project selectedProject = projects[listBox1.SelectedIndex];
            
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to finish the project '{selectedProject.Name}'?\nThis will set its deadline to now.",
                "Confirm Finish Project",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                projectService.UpdateProjectDeadline(selectedProject.Id, DateTime.Now);
                LoadProjects();
                MessageBox.Show("Project finished successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Menu: View Finished Projects
        /// </summary>
        private void finishedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishedProjectsForm form = new FinishedProjectsForm();
            form.ShowDialog(this);
        }
    }
}
