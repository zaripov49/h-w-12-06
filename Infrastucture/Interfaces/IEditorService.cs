using Domain.ApiResponse;
using Domain.DTOs.EditorDTO;

namespace Infrastucture.Interfaces;

public interface IEditorService
{
    Task<Response<List<GetEditorDTO>>> GetAllEditorsAsync();
    Task<Response<GetEditorDTO>>? GetEditorByIdAsync(int id);
    Task<Response<string>> CreateEditorAsync(CreateEditorDTO createEditorDTO);
    Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDTO updateEditorDTO);
    Task<Response<string>> DeleteEditorAsync(int id);
}
