using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAuthorsByBookIdAsync(int bookId);
        Task<AuthorDto> CreateAuthorAsync(AuthorCreateDto authorCreateDto);
        Task UpdateAuthorAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task DeleteAuthorAsync(int id);
    }
}