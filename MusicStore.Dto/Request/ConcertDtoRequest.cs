using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Dto.Request
{
    public record ConcertDtoRequest(
        string Title,
        string Description,
        int IdGender,
        string DateEvent,
        string TimeEvent,
        string Place, 
        int TicketsQuantity,
        decimal UnitPrice
    );
}
