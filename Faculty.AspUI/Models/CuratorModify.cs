﻿using System.ComponentModel.DataAnnotations;

namespace Faculty.AspUI.Models
{
    /// <summary>
    /// Entity Curator.
    /// </summary>
    public class CuratorModify
    {
        /// <summary>
        /// Unique identificator curator.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Surname curator.
        /// </summary>
        [Required(ErrorMessage = "SurnameRequired")]
        [StringLength(50, ErrorMessage = "SurnameLength")]
        public string Surname { get; set; }

        /// <summary>
        /// Name curator.
        /// </summary>
        [Required(ErrorMessage = "NameRequired")]
        [StringLength(50, ErrorMessage = "NameLength")]
        public string Name { get; set; }

        /// <summary>
        /// Doublename curator.
        /// </summary>
        [Required(ErrorMessage = "DoublenameRequired")]
        [StringLength(50, ErrorMessage = "DoublenameLength")]
        public string Doublename { get; set; }

        /// <summary>
        /// Phone curator.
        /// </summary>
        [Required(ErrorMessage = "PhoneRequired")]
        [Phone(ErrorMessage = "PhoneFormat")]
        public string Phone { get; set; }
    }
}
