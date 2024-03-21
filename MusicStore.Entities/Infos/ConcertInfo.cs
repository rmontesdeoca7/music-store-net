using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities.Infos
{
    public class ConcertInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Place { get; set; }
        public string DateEvent { get; set; } = default!;
        public string TimeEvent { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string Description { get; set; } = default!;
        public int TicketsQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Status { get; set; } = default!;
    }
}
