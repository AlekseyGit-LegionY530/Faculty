﻿namespace Faculty.BusinessLayer.ModelsDto
{
    /// <summary>
    /// Entity Group.
    /// </summary>
    public class GroupDto
    {
        /// <summary>
        /// Unique identificator curator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Entity specialization.
        /// </summary>
        public string SpecializationName { get; set; }

        /// <summary>
        /// Foreign key for specialization entity.
        /// </summary>
        public int SpecializationId { get; set; }
    }
}
