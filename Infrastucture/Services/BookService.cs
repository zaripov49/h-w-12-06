using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.BookDTO;
using Domain.Enntities;
using Domain.Filters;
using Infrastucture.Data;
using Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Services;

public class BookService(DataContext context, Mapper mapper) : IBookService
{
    public async Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO)
    {
        var book = mapper.Map<Book>(createBookDTO);

        await context.Books.AddAsync(book);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Book Successfuly");
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return new Response<string>("Book not Found", HttpStatusCode.NotFound);
        }

        context.Books.Remove(book);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Book Successfuly");
    }

    public async Task<Response<List<GetBookDTO>>> GetAllBooksAsync(BookFilter bookFilter)
    {
        var validFilter = new ValidFilter(bookFilter.PageNumber, bookFilter.PageSize);
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(bookFilter.Title))
        {
            query = query.Where(b => b.Title.ToLower().Trim().Contains(bookFilter.Title.ToLower().Trim()));
        }

        if (bookFilter.MinPrice != null)
        {
            query = query.Where(b => b.Price >= bookFilter.MinPrice);
        }

        if (bookFilter.MaxPrice != null)
        {
            query = query.Where(b => b.Price <= bookFilter.MaxPrice);
        }

        var totalRecords = await query.CountAsync();

        var paged = await query
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();

        var mapped = mapper.Map<List<GetBookDTO>>(paged);
        return new Response<List<GetBookDTO>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<GetBookDTO>>? GetBookByIdAsync(int id)
    {
        var result = await context.Books.FindAsync(id);
        if (result == null)
        {
            return new Response<GetBookDTO>("Book not found", HttpStatusCode.NotFound);
        }

        var book = mapper.Map<GetBookDTO>(result);
        if (book == null)
        {
            return new Response<GetBookDTO>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetBookDTO>(book, "Get book successfuly");
    }

    public async Task<Response<string>> UpdateBookAsync(int id, UpdateBookDTO updateBookDTO)
    {
        var updateBook = await context.Books.FindAsync(id);
        if (updateBook == null)
        {
            return new Response<string>("Book not Found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateBookDTO, updateBook);

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated author Successfuly");
    }

}
