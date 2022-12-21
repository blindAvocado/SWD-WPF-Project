namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [Key]
        public int id_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string name_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string email_admin { get; set; }

        [Required]
        [StringLength(32)]
        public string login_admin { get; set; }

        [Required]
        [StringLength(32)]
        public string password_admin { get; set; }
    }
}
