using AutoMapper;
using BookStore.DataLayer;
using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.ToListAsync();
            return _mapper.Map <List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var record = await _context.Books.Where(x=> x.id == id).FirstOrDefaultAsync();
            return _mapper.Map<BookModel>(record);
        }
        
        public async Task<int> AddBook(Books book)
        {
            _context.Books.Add(book);
             await _context.SaveChangesAsync();

            return book.id;
        }

        public async Task UpdateBook(int id ,BookModel bookModel)
        {
            var book = new Books
            {
                id = id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateBookPatch(JsonPatchDocument bookModel, int id)
        {
            var book = await _context.Books.FindAsync(id);
            bookModel.ApplyTo(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(int id)
        {
            var book = new Books { id = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
