using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.AuthorDTO;
using Domain.Enntities;
using Infrastucture.Data;
using Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Services;

public class AuthorService(DataContext context, Mapper mapper) : IAuthorService
{
    public async Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO)
    {
        var author = mapper.Map<Author>(createAuthorDTO);

        await context.Authors.AddAsync(author);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Author Successfuly");
    }

    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            return new Response<string>("Author not Found", HttpStatusCode.NotFound);
        }

        context.Authors.Remove(author);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Author Successfuly");
    }

    public async Task<Response<List<GetAuthorDTO>>> GetAllAuthorsAsync()
    {
        var author = await context.Authors
                    .Select(a => new GetAuthorDTO
                    {
                        SSN = a.SSN,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Phone = a.Phone,
                        Address = a.Address,
                        City = a.City,
                        State = a.State,
                        Zip = a.Zip
                    }).ToListAsync();

        return new Response<List<GetAuthorDTO>>(author, "Successfuly");
    }

    public async Task<Response<GetAuthorDTO>>? GetAuthorByIdAsync(int id)
    {
        var result = await context.Authors.FindAsync(id);
        if (result == null)
        {
            return new Response<GetAuthorDTO>("Author not found", HttpStatusCode.NotFound);
        }

        var author = mapper.Map<GetAuthorDTO>(result);
        if (author == null)
        {
            return new Response<GetAuthorDTO>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetAuthorDTO>(author, "Get author successfuly");
    }

    public async Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO)
    {
        var updateAuthor = await context.Authors.FindAsync(id);
        if (updateAuthor == null)
        {
            return new Response<string>("Author not Found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateAuthorDTO, updateAuthor);

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated author Successfuly");
    }

}
