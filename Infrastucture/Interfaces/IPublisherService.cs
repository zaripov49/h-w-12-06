using Domain.ApiResponse;
using Domain.DTOs.PublisherDTO;

namespace Infrastucture.Interfaces;

public interface IPublisherService
{
    Task<Response<List<GetPublisherDTO>>> GetAllPublishersAsync();
    Task<Response<GetPublisherDTO>>? GetPublisherByIdAsync(int id);
    Task<Response<string>> CreatePublisherAsync(CreatePublisherDTO createPublisherDTO);
    Task<Response<string>> UpdatePublisherAsync(int id, UpdatePublisherDTO updatePublisherDTO);
    Task<Response<string>> DeletePublisherAsync(int id);
}
