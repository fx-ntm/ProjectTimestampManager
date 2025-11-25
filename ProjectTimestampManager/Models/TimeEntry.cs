using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimestampManager.Models
{
    /// <summary>
    /// TimeEntry - Model for table db.time_entries, represents a time entry for a project
    /// </summary>
    internal class TimeEntry
    {
        /// <summary>
        /// Id - Primary Key of the time entry
        /// </summary>
        public required int Id { get; set; }
        /// <summary>
        /// ProjectId - Foreign Key of a project, referring to db.projects.id
        /// </summary>
        public required int ProjectId { get; set; }
        /// <summary>
        /// EntryDate - The date of the time entry
        /// </summary>
        public required DateTime EntryDate { get; set; }
        /// <summary>
        /// StartTime - The start time of the time entry
        /// </summary>
        public required DateTime StartTime { get; set; }
        /// <summary>
        /// EndTime - The end time of the time entry
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// DurationMinutes - The duration of the time entry in minutes
        /// </summary>
        public int? DurationMinutes { get; set; }
    }
}
