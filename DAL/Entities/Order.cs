namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderContents = new HashSet<OrderContent>();
        }

        [Key]
        public int id_order { get; set; }

        public DateTime createdDate_order { get; set; }

        public int status_order { get; set; }

        public int client_order { get; set; }

        public decimal sumPrice_order { get; set; }

        public int pickupDistrict_order { get; set; }

        [Required]
        [StringLength(50)]
        public string pickupAddress_order { get; set; }

        public DateTime pickupDate_order { get; set; }

        public int deliveryDistrict_order { get; set; }

        [Required]
        [StringLength(50)]
        public string deliveryAddress_order { get; set; }

        public DateTime deliveryDate_order { get; set; }

        public int? courier_order { get; set; }

        public int? transport_order { get; set; }

        [StringLength(200)]
        public string comment_order { get; set; }

        public virtual Client Client { get; set; }

        public virtual Courier Courier { get; set; }

        public virtual District District { get; set; }

        public virtual District District1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContents { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Transport Transport { get; set; }
    }
}
