﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Faculty.AspUI.Models
{
    /// <summary>
    /// Entity Faculty.
    /// </summary>
    public class FacultyModify
    {
        /// <summary>
        /// Unique identificator faculty.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Date start education student. 
        /// </summary>
        [Required(ErrorMessage = "DateRequired")]
        public DateTime? StartDateEducation { get; set; }

        /// <summary>
        /// Count year education student.
        /// </summary>
        [Required(ErrorMessage = "YearsRequired")]
        [Range(3, 5, ErrorMessage = "YearsRange")]
        public int? CountYearEducation { get; set; }

        /// <summary>
        /// Foreign key for student entity.
        /// </summary>
        [Required(ErrorMessage = "StudentRequired")]
        public int StudentId { get; set; }

        /// <summary>
        /// Foreign key for group entity.
        /// </summary>
        [Required(ErrorMessage = "GroupRequired")]
        public int GroupId { get; set; }

        /// <summary>
        /// Foreign key for curator entity.
        /// </summary>
        [Required(ErrorMessage = "CuratorRequired")]
        public int CuratorId { get; set; }
    }
}
