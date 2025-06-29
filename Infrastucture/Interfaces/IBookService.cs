using Domain.ApiResponse;
using Domain.DTOs.BookDTO;
using Domain.Filters;

namespace Infrastucture.Interfaces;

public interface IBookService
{
    Task<Response<List<GetBookDTO>>> GetAllBooksAsync(BookFilter bookFilter);
    Task<Response<GetBookDTO>>? GetBookByIdAsync(int id);
    Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO);
    Task<Response<string>> UpdateBookAsync(int id, UpdateBookDTO updateBookDTO);
    Task<Response<string>> DeleteBookAsync(int id);
}
