using TddTaskManagement.Application.DTOs;

namespace TddTaskManagement.Application.Services
{
    public class BookService
    {
        public BookDto Create(BookDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto);
            ArgumentException.ThrowIfNullOrWhiteSpace(bookDto.Title);

            var result = new BookDto()
            {
                Title = bookDto.Title,
            };

            return result;
        }
    }
}