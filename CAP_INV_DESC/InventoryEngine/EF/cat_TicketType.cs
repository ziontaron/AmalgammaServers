namespace InventoryEngine.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cat_TicketType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cat_TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int TicketTypeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string TicketType { get; set; }

        [Required]
        [StringLength(100)]
        public string TicketTypeDescirption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
