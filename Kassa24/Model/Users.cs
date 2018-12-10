namespace Kassa24.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int UserId { get; set; }

        public string SID { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public int Email { get; set; }

        public int? RoleId { get; set; }

        [StringLength(250)]
        public string Login { get; set; }

        [StringLength(250)]
        public string Password { get; set; }
    }
}
