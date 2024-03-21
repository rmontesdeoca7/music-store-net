using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IGenderService
    {
        Task<BaseResponseGeneric<IEnumerable<GenderDtoResponse>>> ListAsync();
        Task<BaseResponseGeneric<GenderDtoResponse>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(GenderDtoRequest gender);
        Task<BaseResponse> UpdateAsync(int id, GenderDtoRequest gender);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
