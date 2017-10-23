namespace InventoryEngine.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryEvent")]
    public partial class InventoryEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryEvent()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int InventoryEventKey { get; set; }

        [Required]
        [StringLength(50)]
        public string InventoryEventName { get; set; }

        [Required]
        public string InventoryEventDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime TerminationDate { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
