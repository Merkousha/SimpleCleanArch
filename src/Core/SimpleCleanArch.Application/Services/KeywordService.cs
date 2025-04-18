using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;

namespace SimpleCleanArch.Application.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IKeywordRepository _keywordRepository;
        private readonly IMapper _mapper;

        public KeywordService(IKeywordRepository keywordRepository, IMapper mapper)
        {
            _keywordRepository = keywordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KeywordDto>> GetAllKeywordsAsync()
        {
            var keywords = await _keywordRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<KeywordDto>>(keywords);
        }

        public async Task<KeywordDto> GetKeywordByIdAsync(int id)
        {
            var keyword = await _keywordRepository.GetByIdAsync(id);
            if (keyword == null)
                throw new NotFoundException($"Keyword with ID {id} not found.");

            return _mapper.Map<KeywordDto>(keyword);
        }

        public async Task<IEnumerable<KeywordDto>> GetKeywordsByBookIdAsync(int bookId)
        {
            var keywords = await _keywordRepository.GetKeywordsByBookIdAsync(bookId);
            return _mapper.Map<IEnumerable<KeywordDto>>(keywords);
        }

        public async Task<KeywordDto> CreateKeywordAsync(KeywordCreateDto keywordCreateDto)
        {
            var keyword = new Keyword
            {
                Word = keywordCreateDto.Word
            };
            
            await _keywordRepository.AddAsync(keyword);
            
            return _mapper.Map<KeywordDto>(keyword);
        }

        public async Task UpdateKeywordAsync(KeywordDto keywordDto)
        {
            var existingKeyword = await _keywordRepository.GetByIdAsync(keywordDto.Id);
            if (existingKeyword == null)
                throw new NotFoundException($"Keyword with ID {keywordDto.Id} not found.");

            _mapper.Map(keywordDto, existingKeyword);
            await _keywordRepository.UpdateAsync(existingKeyword);
        }

        public async Task DeleteKeywordAsync(int id)
        {
            var keyword = await _keywordRepository.GetByIdAsync(id);
            if (keyword == null)
                throw new NotFoundException($"Keyword with ID {id} not found.");

            await _keywordRepository.DeleteAsync(keyword);
        }
    }
} 