using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parser(PersonVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new Person
                {
                    id = origin.id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Adress = origin.Adress,
                    Gender = origin.Gender
                };

            }
        }


        public PersonVO Parser(Person origin)
        {

            if (origin == null)
            {
                return null;
            }
            else
            {
                return new PersonVO
                {
                    id = origin.id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Adress = origin.Adress,
                    Gender = origin.Gender
                };

            }
        }

        public List<PersonVO> Parser(List<Person> origin)
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
        public List<Person> Parser(List<PersonVO> origin)
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
