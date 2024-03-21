using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IConcertService
    {
        Task<BaseResponseGeneric<ICollection<ConcertDtoResponse>>> ListAsync(string? filter, int page, int rows);
        Task<BaseResponseGeneric<ConcertDtoResponse>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(ConcertDtoRequest concert);
        Task<BaseResponse> UpdateAsync(int id, ConcertDtoRequest concert);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponse> FinalizeAsync(int id);
    }
}
