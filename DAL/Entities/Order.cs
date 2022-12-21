namespace DAL
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

        public DateTime date_order { get; set; }

        public int client_order { get; set; }

        [Required]
        public string address_order { get; set; }

        public DateTime deliveryDate_order { get; set; }

        public int status_order { get; set; }

        public int payment_order { get; set; }

        public int? courier_order { get; set; }

        public int? transport_order { get; set; }

        public virtual Client Client { get; set; }

        public virtual Courier Courier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContents { get; set; }

        public virtual OrderStatus OrderStatu { get; set; }

        public virtual Transport Transport { get; set; }
    }
}
