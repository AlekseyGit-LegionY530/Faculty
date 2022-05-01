﻿using System;

namespace Faculty.Common.Dto.Faculty
{
    /// <summary>
    /// Dto Faculty.
    /// </summary>
    public class FacultyDisplayDto
    {
        /// <summary>
        /// Unique faculty id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date start education student. 
        /// </summary>
        public DateTime StartDateEducation { get; set; }

        /// <summary>
        /// Count year education student.
        /// </summary>
        public int CountYearEducation { get; set; }

        /// <summary>
        /// Surname student.
        /// </summary>
        public string StudentSurname { get; set; }

        /// <summary>
        /// Name group.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Surname curator.
        /// </summary>
        public string CuratorSurname { get; set; }
    }
}