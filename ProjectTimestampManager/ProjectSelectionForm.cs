using ProjectTimestampManager.Models;
using ProjectTimestampManager.Services;

namespace ProjectTimestampManager
{
    public partial class ProjectSelectionForm : Form
    {
        private ProjectService projectService;
        private List<Project> projects;

        public ProjectSelectionForm()
        {
            InitializeComponent();
            projectService = new ProjectService();
            projects = new List<Project>();
            this.Load += ProjectSelectionForm_Load;
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
    }
}
