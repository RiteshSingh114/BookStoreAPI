using BookStore.DataLayer;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel book)
        {
            var bookToAdd = new Books {
                Title = book.Title,
                Description = book.Description };

            var id = await _bookRepository.AddBook(bookToAdd);

            return CreatedAtAction(nameof(GetBookById), new { id = id, Controller = "book" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id ,[FromBody]BookModel book)
        {
            await _bookRepository.UpdateBook(id,book);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] JsonPatchDocument book)
        {
            await _bookRepository.UpdateBookPatch(book, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBook(id);
            return Ok();
        }


    }
}
