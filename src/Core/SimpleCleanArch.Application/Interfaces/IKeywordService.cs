using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Interfaces
{
    public interface IKeywordService
    {
        Task<IEnumerable<KeywordDto>> GetAllKeywordsAsync();
        Task<KeywordDto> GetKeywordByIdAsync(int id);
        Task<IEnumerable<KeywordDto>> GetKeywordsByBookIdAsync(int bookId);
        Task<KeywordDto> CreateKeywordAsync(KeywordCreateDto keywordCreateDto);
        Task UpdateKeywordAsync(KeywordDto keywordDto);
        Task DeleteKeywordAsync(int id);
    }
} 