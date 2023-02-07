using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parser(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new Book
                {
                    id = origin.id,
                    Launch_date = origin.Launch_date,
                    Price       = origin.Price,
                    Title       = origin.Title,
                    Author      = origin.Author
                };
            }
        }
        public List<Book> Parser(List<BookVO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }

        public BookVO Parser(Book origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new BookVO
                {
                    id = origin.id,
                    Launch_date = origin.Launch_date,
                    Price = origin.Price,
                    Title = origin.Title,
                    Author = origin.Author
                };
            }
        }

        public List<BookVO> Parser(List<Book> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }
    }
}
