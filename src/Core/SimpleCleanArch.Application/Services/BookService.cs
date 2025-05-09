using AutoMapper;
using SimpleCleanArch.Application.Common.Exceptions;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;

namespace SimpleCleanArch.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(
            IBookRepository bookRepository, 
            IMapper mapper,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetTop10BooksAsync()
        {
            var books = await _bookRepository.GetTop10Async();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }


        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"Book with ID {id} not found.");

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> GetBookBySlugAsync(string slug)
        {
            var book = await _bookRepository.GetBookBySlugAsync(slug);
            if (book == null)
                throw new NotFoundException($"Book with slug '{slug}' not found.");

            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByCategoryIdAsync(int categoryId)
        {
            var books = await _bookRepository.GetBooksByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            // Validate that the author exists
            var author = await _authorRepository.GetByIdAsync(bookCreateDto.AuthorId);
            if (author == null)
                throw new NotFoundException($"Author with ID {bookCreateDto.AuthorId} not found.");

            // Validate that the category exists
            var category = await _categoryRepository.GetByIdAsync(bookCreateDto.CategoryId);
            if (category == null)
                throw new NotFoundException($"Category with ID {bookCreateDto.CategoryId} not found.");

            var book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(int id, BookUpdateDto bookUpdateDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
                throw new NotFoundException($"Book with ID {id} not found.");

            // Validate that the author exists if provided
            if (bookUpdateDto.AuthorIds != null && bookUpdateDto.AuthorIds.Count > 0)
            {
                var authorId = bookUpdateDto.AuthorIds[0];
                var author = await _authorRepository.GetByIdAsync(authorId);
                if (author == null)
                    throw new NotFoundException($"Author with ID {authorId} not found.");
            }

            // Validate that the category exists if provided
            if (bookUpdateDto.CategoryIds != null && bookUpdateDto.CategoryIds.Count > 0)
            {
                var categoryId = bookUpdateDto.CategoryIds[0];
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category == null)
                    throw new NotFoundException($"Category with ID {categoryId} not found.");
            }

            _mapper.Map(bookUpdateDto, existingBook);
            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"Book with ID {id} not found.");

            await _bookRepository.DeleteAsync(book);
        }
    }
}