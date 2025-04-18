using AutoMapper;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;

namespace SimpleCleanArch.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new NotFoundException($"Author with ID {id} not found.");

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsByBookIdAsync(int bookId)
        {
            var authors = await _authorRepository.GetAuthorsByBookIdAsync(bookId);
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            await _authorRepository.AddAsync(author);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task UpdateAuthorAsync(int id, AuthorUpdateDto authorUpdateDto)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(id);
            if (existingAuthor == null)
                throw new NotFoundException($"Author with ID {id} not found.");

            _mapper.Map(authorUpdateDto, existingAuthor);
            await _authorRepository.UpdateAsync(existingAuthor);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new NotFoundException($"Author with ID {id} not found.");

            await _authorRepository.DeleteAsync(author);
        }
    }
}