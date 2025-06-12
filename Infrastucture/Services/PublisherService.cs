using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.PublisherDTO;
using Domain.Enntities;
using Infrastucture.Data;
using Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Services;

public class PublisherService(DataContext context, Mapper mapper) : IPublisherService
{
    public async Task<Response<string>> CreatePublisherAsync(CreatePublisherDTO createPublisherDTO)
    {
        var publisher = mapper.Map<Publisher>(createPublisherDTO);

        await context.Publishers.AddAsync(publisher);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Publisher Successfuly");
    }

    public async Task<Response<string>> DeletePublisherAsync(int id)
    {
        var publisher = await context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return new Response<string>("Publisher not Found", HttpStatusCode.NotFound);
        }

        context.Publishers.Remove(publisher);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Publisher Successfuly");
    }

    public async Task<Response<List<GetPublisherDTO>>> GetAllPublishersAsync()
    {
        var publisher = await context.Publishers
                    .Select(a => new GetPublisherDTO
                    {
                        Name = a.Name,
                        Address = a.Address,
                        City = a.City,
                        State = a.State
                    }).ToListAsync();

        return new Response<List<GetPublisherDTO>>(publisher, "Successfuly");
    }

    public async Task<Response<GetPublisherDTO>>? GetPublisherByIdAsync(int id)
    {
        var result = await context.Publishers.FindAsync(id);
        if (result == null)
        {
            return new Response<GetPublisherDTO>("Publisher not found", HttpStatusCode.NotFound);
        }

        var publisher = mapper.Map<GetPublisherDTO>(result);
        if (publisher == null)
        {
            return new Response<GetPublisherDTO>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetPublisherDTO>(publisher, "Get publisher successfuly");
    }

    public async Task<Response<string>> UpdatePublisherAsync(int id, UpdatePublisherDTO updatePublisherDTO)
    {
        var updatePublisher = await context.Publishers.FindAsync(id);
        if (updatePublisher == null)
        {
            return new Response<string>("Publisher not Found", HttpStatusCode.NotFound);
        }

        mapper.Map(updatePublisherDTO, updatePublisher);

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated publisher Successfuly");
    }
}
