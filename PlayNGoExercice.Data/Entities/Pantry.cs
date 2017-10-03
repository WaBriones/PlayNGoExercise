using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PlayNGoExercice.Data.Entities
{
    [Table("Pantry")]
    public partial class Pantry
    {
        [Key]
        public int PantryId { get; set; }

		[ForeignKey("Office")]
        public int OfficeId { get; set; }

        [StringLength(300)]
        public string PantryName { get; set; }

        public virtual Office Office { get; set; }
    }
}
