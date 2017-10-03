namespace PlayNGoExercice.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Office")]
    public partial class Office
    {
        public Office()
        {
            Pantries = new HashSet<Pantry>();
        }

		[Key]
		public int OfficeId { get; set; }

        [StringLength(300)]
        public string OfficeName { get; set; }
		
        public virtual ICollection<Pantry> Pantries { get; set; }
    }
}
