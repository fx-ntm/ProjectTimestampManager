using ProjectTimestampManager.Models;
using ProjectTimestampManager.Services;

namespace ProjectTimestampManager
{
    public partial class TimeTracking : Form
    {
        private bool isTracking = false;
        private int elapsedSeconds = 0;
        private Project currentProject;
        private DateTime trackingStartTime;
        private System.Windows.Forms.Timer trackingTimer;

        private TimeEntryService timeEntryService;

        /// <summary>
        /// Constructor for TimeTracking form
        /// </summary>
        /// <param name="project">The project to track time for</param>
        public TimeTracking(Project project)
        {
            InitializeComponent();
            currentProject = project;
            timeEntryService = new TimeEntryService();
            InitializeTimer();
            InitializeContent();
        }

        /// <summary>
        /// Initialize timer
        /// </summary>
        private void InitializeTimer()
        {
            trackingTimer = new System.Windows.Forms.Timer();
            trackingTimer.Interval = 1000; // 1 second
            trackingTimer.Tick += TrackingTimer_Tick;
        }

        /// <summary>
        /// Timer tick event handler to update display
        /// </summary>
        private void TrackingTimer_Tick(object? sender, EventArgs e)
        {
            elapsedSeconds++;
            UpdateElapsedTimeLabel();
        }

        /// <summary>
        /// Updates the elapsed time label
        /// </summary>
        private void UpdateElapsedTimeLabel()
        {
            int hours = elapsedSeconds / 3600;
            int minutes = (elapsedSeconds % 3600) / 60;
            if (hours > 0)
            {
                label2.Text = $"{hours} Hour{(hours > 1 ? "s" : "")} {minutes} Minute{(minutes != 1 ? "s" : "")}";
            }
            else
            {
                label2.Text = $"{minutes} Minute{(minutes != 1 ? "s" : "")}";
            }
        }

        /// <summary>
        /// Initialize the window with the content
        /// </summary>
        private void InitializeContent()
        {
            this.Text = $"Time Tracking - {currentProject.Name}";
            label4.Text = $"{currentProject.AllocatedHours} Hour{(currentProject.AllocatedHours != 1 ? "s" : "")}";
            label2.Text = "0 Minutes";
            button1.Text = "Start";
            button2.Text = "Back";

            SetupDataGridView();
            LoadTimeEntries();
            UpdateProgressBar();
        }

        /// <summary>
        /// DataGridView setup
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("EntryDate", "Entry Date");
            dataGridView1.Columns.Add("StartTime", "Start Time");
            dataGridView1.Columns.Add("EndTime", "End Time");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        /// <summary>
        /// Load time entries from DB into the DataGridView
        /// </summary>
        private void LoadTimeEntries()
        {
            dataGridView1.Rows.Clear();

            List<TimeEntry> entries = timeEntryService.GetProjectTimesByProjectId(currentProject.Id);

            foreach (TimeEntry entry in entries)
            {
                string entryDate = entry.EntryDate.ToString("yyyy-MM-dd");
                string startTime = entry.StartTime.ToString("HH:mm:ss");
                string endTime = entry.EndTime.HasValue ? entry.EndTime.Value.ToString("HH:mm:ss") : "In Progress";

                dataGridView1.Rows.Add(entryDate, startTime, endTime);
            }
        }

        /// <summary>
        /// Update the progress bar
        /// </summary>
        private void UpdateProgressBar()
        {
            int totalMinutes = GetTotalMinutesForProject();
            int allocatedMinutes = currentProject.AllocatedHours * 60;

            progressBar1.Maximum = allocatedMinutes > 0 ? allocatedMinutes : 1;
            progressBar1.Value = Math.Min(totalMinutes, allocatedMinutes);
        }

        /// <summary>
        /// Gets the total minutes tracked
        /// </summary>
        /// <returns>Total minutes tracked</returns>
        private int GetTotalMinutesForProject()
        {
            List<TimeEntry> entries = timeEntryService.GetProjectTimesByProjectId(currentProject.Id);
            int totalMinutes = 0;

            foreach (TimeEntry entry in entries)
            {
                if (entry.DurationMinutes.HasValue)
                {
                    totalMinutes += entry.DurationMinutes.Value;
                }
            }

            return totalMinutes;
        }

        /// <summary>
        /// Close the window
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (isTracking)
            {
                DialogResult result = MessageBox.Show(
                    "Timer is still running. Do you want to stop it and go back?",
                    "Timer Running",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    StopTracking();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Start/Stop Time Entry button click
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (isTracking == false)
            {
                StartTracking();
            }
            else
            {
                StopTracking();
            }
        }

        /// <summary>
        /// Start the time tracking
        /// </summary>
        private void StartTracking()
        {
            if (DateTime.Now > currentProject.Deadline)
            {
                MessageBox.Show(
                    "Cannot start tracking - project deadline has passed.",
                    "Deadline Passed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            isTracking = true;
            trackingStartTime = DateTime.Now;
            elapsedSeconds = 0;
            button1.Text = "Stop";
            button1.BackColor = Color.IndianRed;

            trackingTimer.Start();
            timeEntryService.StartTimeEntry(currentProject.Id);
            LoadTimeEntries();
        }

        /// <summary>
        /// Stop the time tracking and publish the entry
        /// </summary>
        private void StopTracking()
        {
            isTracking = false;
            trackingTimer.Stop();
            button1.Text = "Start";
            button1.BackColor = SystemColors.Control;

            TimeEntry entry = new TimeEntry
            {
                Id = 0,
                ProjectId = currentProject.Id,
                EntryDate = trackingStartTime.Date,
                StartTime = trackingStartTime,
                EndTime = null,
                DurationMinutes = null
            };
            timeEntryService.StopTimeEntry(entry);
            elapsedSeconds = 0;
            UpdateElapsedTimeLabel();
            LoadTimeEntries();
            UpdateProgressBar();
        }
    }
}
