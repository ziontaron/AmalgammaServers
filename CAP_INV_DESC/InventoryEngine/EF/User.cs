namespace InventoryEngine.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int UserKey { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string AuthorizatorPassword { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone1 { get; set; }

        [StringLength(50)]
        public string Phone2 { get; set; }

        public byte[] Identicon { get; set; }

        public string Identicon64 { get; set; }

        public string EmailPassword { get; set; }

        public string EmailServer { get; set; }

        public string EmailPort { get; set; }

        public bool sys_active { get; set; }

        public bool is_locked { get; set; }

        public string document_status { get; set; }
    }
}
