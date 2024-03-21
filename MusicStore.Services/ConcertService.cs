using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepository;
        private readonly ILogger<ConcertService> _logger;
        private readonly IMapper _mapper;

        public ConcertService(
            IConcertRepository concertRepository,
            ILogger<ConcertService> logger,
            IMapper mapper
        )
        {
            _concertRepository = concertRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneric<ICollection<ConcertDtoResponse>>> ListAsync(string? filter, int page, int rows)
        {
            var response = new BaseResponseGeneric<ICollection<ConcertDtoResponse>>();
            try
            {
                var concerts = await _concertRepository.ListAsync(filter, page, rows);
                response.Data = _mapper.Map<ICollection<ConcertDtoResponse>>(concerts);
                response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar los conciertos");
                response.ErrorMessage = "Error al listar los conciertos";
            }

            return response;

        }

        public async Task<BaseResponseGeneric<ConcertDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<ConcertDtoResponse>();

            try
            {
                var concert = await _concertRepository.GetAsync(id);
                if(concert == null)
                {
                    response.ErrorMessage = "No se encontro el concierto";
                    return response;
                }

                response.Data = _mapper.Map<ConcertDtoResponse>(concert);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el concierto");
                response.ErrorMessage = "Error al obtener los conciertos";
            }

            return response;
        }


        public async Task<BaseResponseGeneric<int>> AddAsync(ConcertDtoRequest concert)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                var entity = _mapper.Map<Concert>(concert);
                response.Data = await _concertRepository.AddAsync(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el concierto");
                response.ErrorMessage = "Error al guardar el concierto";
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ConcertDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _concertRepository.GetAsync(id);
                
                if(entity == null)
                {
                    response.ErrorMessage = "No se encuentra el concierto";
                    return response;
                }

                _mapper.Map(request, entity);

                await _concertRepository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el concierto");
                response.ErrorMessage = "Error al actualizar el concierto";
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _concertRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al borrar el concierto");
                response.ErrorMessage = "Error al borrar el concierto";
            }

            return response;
        }

        public async Task<BaseResponse> FinalizeAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _concertRepository.FinalizeAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al borrar el concierto");
                response.ErrorMessage = "Error al borrar el concierto";
            }

            return response;
        }

    }
}
