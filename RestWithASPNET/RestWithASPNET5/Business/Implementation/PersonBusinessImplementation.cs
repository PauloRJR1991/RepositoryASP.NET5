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
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parser(_repository.FindByID(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parser(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parser(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
