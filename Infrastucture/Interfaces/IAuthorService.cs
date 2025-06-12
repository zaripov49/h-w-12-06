using Domain.ApiResponse;
using Domain.DTOs.AuthorDTO;

namespace Infrastucture.Interfaces;

public interface IAuthorService
{
    Task<Response<List<GetAuthorDTO>>> GetAllAuthorsAsync();
    Task<Response<GetAuthorDTO>>? GetAuthorByIdAsync(int id);
    Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
    Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO);
    Task<Response<string>> DeleteAuthorAsync(int id);
}
