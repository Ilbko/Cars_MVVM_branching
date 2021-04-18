namespace Cars_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coffee")]
    public partial class Coffee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Cost_price { get; set; }

        public double Price { get; set; }

        public int Gram_per_serving { get; set; }

        [Required]
        [StringLength(50)]
        public string Grain_type { get; set; }

        [Required]
        [StringLength(50)]
        public string Country_of_origin { get; set; }

        [Required]
        [StringLength(50)]
        public string Info { get; set; }
    }
}
