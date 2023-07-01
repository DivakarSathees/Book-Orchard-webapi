using dotnetapp.Controllers;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProject;

    public class Tests
    {
        private BooksController _booksController;
        private BookContext _dbContext;
        // private List<Book> _testBooks;

        [SetUp]
        public void Setup()
        {
            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Initialize the in-memory database with test data
            _dbContext = new BookContext(options);
            _booksController = new BooksController(_dbContext);
            // _dbContext.Database.EnsureCreated();

        //     _testBooks = new List<Book>
        //    {
        //        new Book { Id = 1, BookName = "Book 1" ,AuthorName="Author1",Genre="Thriller"},
        //        new Book { Id = 2, BookName = "Book 2" ,AuthorName="Author2",Genre="Fantasy"},
        //        new Book { Id = 3, BookName = "Book 3", AuthorName="Author3",Genre="Romance" }
        //     };
        //     _dbContext.Books.AddRange(_testBooks);

            _dbContext.Books.AddRange(new List<Book>
            {
                new Book { Id = 1, BookName = "Book 1" ,AuthorName="Author1",Genre="Thriller"},
                new Book { Id = 2, BookName = "Book 2" ,AuthorName="Author2",Genre="Fantasy"},
                new Book { Id = 3, BookName = "Book 3", AuthorName="Author3",Genre="Romance" }
           });

         _dbContext.SaveChanges();
          

            // Create the controller using the in-memory database context
       
        }

      [TearDown]
    public void TearDown()
    {
        _dbContext.Database.EnsureDeleted();
    }

        [Test]
        public async Task GetAllBooks_ReturnsListOfBooks()
        {
            // Arrange
            //var expectedBooks = new List<Book>
            //{
            //    new Book { Id = 1, BookName = "Book 1", AuthorName = "Author 1", Genre = "Genre 1" },
            //    new Book { Id = 2, BookName = "Book 2", AuthorName = "Author 2", Genre = "Genre 2" }
            //};

            //foreach (var book in expectedBooks)
            //{
            //    _dbContext.Add(book);
            //}
            //_dbContext.SaveChanges();

            // Act
            var result = await _booksController.GetBooks();
            Assert.IsInstanceOf(typeof(List<Book>), result.Value);
            Assert.AreEqual(3, result.Value.Count());
            
        }


       // [Test]
        public async Task GetBooks_ReturnsBooks_WhenBooksExist()
        {
            // Act
            var result = await _booksController.GetBooks();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = (OkObjectResult)result.Result;
            Assert.IsInstanceOf<List<Book>>(okResult.Value);

            var books = (List<Book>)okResult.Value;
            Assert.AreEqual(3, books.Count);
            //Assert.AreEqual("Book 1", books[0].Title);
            //Assert.AreEqual("Book 2", books[1].Title);
            //Assert.AreEqual("Book 3", books[2].Title);
        }

        // [TearDown]
        // public void TearDown()
        // {
        //     _dbContext.Database.EnsureDeleted();
        //     _dbContext.Dispose();
        // }

    }

    
