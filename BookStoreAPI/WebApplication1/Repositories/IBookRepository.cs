using BookStore.DataLayer;
using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddBook(Books book);
        Task UpdateBook(int id, BookModel bookModel);
        Task UpdateBookPatch(JsonPatchDocument bookModel, int id);
        Task DeleteBook(int id);
    }
}
