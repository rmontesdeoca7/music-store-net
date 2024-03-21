using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    [Table("Events")]
    public class Concert : EntityBase
    {
        public Gender Gender { get; set; } = default!;
        public int GenderId { get; set; }
        [StringLength(150)]
        public string Title { get; set; } = default!;
        [StringLength(500)]
        public string Description { get; set; } = default!;
        public DateTime DateEvent { get; set; }
        public string? ImageUrl { get; set; }
        [StringLength(100)]
        public string? Place {  get; set; }
        public int TicketsQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Finalized { get; set; }

    }
}
