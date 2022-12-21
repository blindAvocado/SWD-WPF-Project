namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manager
    {
        [Key]
        public int id_manager { get; set; }

        [Required]
        [StringLength(50)]
        public string name_manager { get; set; }

        [Required]
        [StringLength(50)]
        public string email_manager { get; set; }

        [Required]
        [StringLength(32)]
        public string login_manager { get; set; }

        [Required]
        [StringLength(32)]
        public string password_manager { get; set; }
    }
}
