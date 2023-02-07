using RestWithASPNET5.Data.Converter.Implementation;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using RestWithASPNET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET5.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;


        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return _converter.Parser(_repository.FindByID(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parser(bookEntity);
        }

        public BookVO Update(BookVO book)
        {

            var bookEntity = _converter.Parser(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parser(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }


    }
}
