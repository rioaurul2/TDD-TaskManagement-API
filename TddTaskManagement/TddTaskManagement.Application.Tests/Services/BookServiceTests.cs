using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using TddTaskManagement.Application.DTOs;
using TddTaskManagement.Application.Services;

namespace TddTaskManagement.Application.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class BookServiceTests
    {
        [Fact]
        public void Create_ShouldCreateBook_WhenValidInputsProvided()
        {
            //arrange
            BookDto book = new BookDto
            {
                Title = "Title"
            };

            var bookService = new BookService();

            //act
            var result = bookService.Create(book);

            //result
            Assert.NotNull(result);
            Assert.Equal(book.Title, result.Title);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_ShouldThrowException_WhenInvalidInputsProvided(string title)
        {
            //arrange
            BookDto bookDto = new BookDto
            {
                Title = title
            };

            var bookService = new BookService();

            //act
            var ex = Assert.Throws<ArgumentException>(() => bookService.Create(bookDto));

            //result
            Assert.Contains("Title", ex.ParamName);
        }
    }
}
