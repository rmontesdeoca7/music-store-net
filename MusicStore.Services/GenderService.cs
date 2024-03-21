using AutoMapper;
using Azure.Core;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;

namespace MusicStore.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;
        private readonly ILogger<GenderService> _logger;
        private readonly IMapper _mapper;
        public GenderService(
            IGenderRepository repository, 
            ILogger<GenderService> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneric<IEnumerable<GenderDtoResponse>>> ListAsync()
        {
            var response = new BaseResponseGeneric<IEnumerable<GenderDtoResponse>>();

            try
            {
                //var data = await _repository.ListAsync();
                //response.Data = data.Select(p => new GenderDtoResponse
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Status = p.Status,
                //});
                // lo mismo de arriba pero con el mapper en una linea
                var informacion = await _repository.ListAsync();
                response.Data = _mapper.Map<IEnumerable<GenderDtoResponse>>(informacion);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Hubo un error al obtener los registros";
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<GenderDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<GenderDtoResponse>();
            try
            {
                var gender = await _repository.GetAsync(id);
                if(gender == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontro el registro";
                }
                else
                {
                    response.Data = _mapper.Map<GenderDtoResponse>(gender);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Hubo un error al obtener el registro";
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(GenderDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                var entity = _mapper.Map<Gender>(request);
                await _repository.AddAsync(entity);

                response.Data = entity.Id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Hubo un error al guardar el registro";
                _logger.LogError(ex, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, GenderDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontro el registro"; 
                }
                else
                {
                    //origen destino
                    _mapper.Map(request, entity);
                    await _repository.UpdateAsync();
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Hubo un error al actualizar el registro";
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "No se encontro el registro";
                }
                else
                {
                    await _repository.DeleteAsync(id);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Hubo un error al eliminar el registro";
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }



    }
}
