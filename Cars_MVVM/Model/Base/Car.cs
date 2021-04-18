namespace Cars_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cars")]
    public partial class Cars
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int Engine_volume { get; set; }

        public double Consumption { get; set; }

        [Column(TypeName = "date")]
        public DateTime Release { get; set; }

        public int Prise { get; set; }
    }
}
