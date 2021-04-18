namespace Cars_MVVM.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoffeeModel : DbContext
    {
        public CoffeeModel()
            : base("name=CoffeeModel")
        {
        }

        public virtual DbSet<Coffee> Coffees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
