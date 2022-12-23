namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderContent")]
    public partial class OrderContent
    {
        [Key]
        public int id_orderContent { get; set; }

        public int order_orderContent { get; set; }

        public double width_orderContent { get; set; }

        public double length_orderContent { get; set; }

        public double height_orderContent { get; set; }

        public double weight_orderContent { get; set; }

        public decimal price_orderContent { get; set; }

        public int quantity_orderContent { get; set; }

        public int cargoType_orderContent { get; set; }

        public virtual CargoType CargoType { get; set; }

        public virtual Order Order { get; set; }
    }
}
