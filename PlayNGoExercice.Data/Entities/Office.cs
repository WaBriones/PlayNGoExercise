using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PlayNGoExercice.Data.Entities
{
    [Table("Office")]
    public partial class Office
    {
        public Office()
        {
            Pantries = new HashSet<Pantry>();
			PantryStocks = new HashSet<PantryStock>();
			Orders = new HashSet<Orders>();
		}

		[Key]
		public int OfficeId { get; set; }

        [StringLength(300)]
        public string OfficeName { get; set; }
		
        public virtual ICollection<Pantry> Pantries { get; set; }

		public virtual ICollection<PantryStock> PantryStocks { get; set; }

		public virtual ICollection<Orders> Orders { get; set; }
	}
}
