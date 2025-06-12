using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.EditorDTO;
using Domain.Enntities;
using Infrastucture.Data;
using Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Services;

public class EditorService(DataContext context, Mapper mapper) : IEditorService
{
    public async Task<Response<string>> CreateEditorAsync(CreateEditorDTO createEditorDTO)
    {
        var editor = mapper.Map<Editor>(createEditorDTO);

        await context.Editors.AddAsync(editor);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Editor Successfuly");
    }

    public async Task<Response<string>> DeleteEditorAsync(int id)
    {
        var editor = await context.Editors.FindAsync(id);
        if (editor == null)
        {
            return new Response<string>("Editor not Found", HttpStatusCode.NotFound);
        }

        context.Editors.Remove(editor);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Editor Successfuly");
    }

    public async Task<Response<List<GetEditorDTO>>> GetAllEditorsAsync()
    {
        var editor = await context.Editors
                    .Select(a => new GetEditorDTO
                    {
                        SSN = a.SSN,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Phone = a.Phone,
                        EditorPosition = a.EditorPosition,
                        Salary = a.Salary
                    }).ToListAsync();

        return new Response<List<GetEditorDTO>>(editor, "Successfuly");
    }

    public async Task<Response<GetEditorDTO>>? GetEditorByIdAsync(int id)
    {
        var result = await context.Editors.FindAsync(id);
        if (result == null)
        {
            return new Response<GetEditorDTO>("Editor not found", HttpStatusCode.NotFound);
        }

        var editor = mapper.Map<GetEditorDTO>(result);
        if (editor == null)
        {
            return new Response<GetEditorDTO>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetEditorDTO>(editor, "Get editor successfuly");
    }

    public async Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDTO updateEditorDTO)
    {
        var updateEditor = await context.Editors.FindAsync(id);
        if (updateEditor == null)
        {
            return new Response<string>("Editor not Found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateEditorDTO, updateEditor);

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated editor Successfuly");
    }
}
