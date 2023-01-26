using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository.Implementation
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MysqlCotext _context;

        public PersonRepositoryImplementation(MysqlCotext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public Person Update(Person person)
        {

            if (!Exists(person.id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(person.id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.id.Equals(id));
        }
    }
}
