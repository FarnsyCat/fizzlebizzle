using fizzlebizzle.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fizzlebizzle.Models
{
    public class FizzleBizzleModel : IFizzleBizzle
    {
       public enum FizzBuzzBazzPredicates {
            NotEqual = 1,
            Greater = 2,
            Less = 3,
            Equal = 4
        }
        private int _fizz;
        private int _buzz;
        private int _start;
        private int _end;
        private int _bazz;
        private bool _isValid = false;
        private bool _isFizzBuzzBazz = false;
        private FizzBuzzBazzPredicates _predicate;
        

        public Predicate<int> setPredicate()
        {
            if (_predicate == FizzBuzzBazzPredicates.Equal)
            {
                return new Predicate<int>(a => a == _bazz);
            }
            else if(_predicate == FizzBuzzBazzPredicates.Greater)
            {
                return new Predicate<int>(a => a > _bazz);
            }
            else if(_predicate == FizzBuzzBazzPredicates.Less)
            {
                return new Predicate<int>(a => a < _bazz);
            }
            else if(_predicate != FizzBuzzBazzPredicates.Less)
            {
                return new Predicate<int>(a => a != _bazz);
            }
            else
            {
                return null;
            }
        }

        public FizzBuzzBazzPredicates Predicate
        {
            set { _predicate = value; }
            get { return _predicate; }
        }

        public bool isFizzBuzzBazz
        {
            set { _isFizzBuzzBazz = value; }
            get { return _isFizzBuzzBazz; }
        }

        public bool isValid
        {
            set { _isValid = value; }
            get { return _isValid; }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Fizz needs to be bigger than {1}")]
        public int Fizz
        {
            get { return _fizz; }
            set { _fizz = value; }
        }
        [Range(1, int.MaxValue, ErrorMessage = "Buzz needs to be bigger than {1}")]
        public int Buzz
        { 
            get { return _buzz; }
            set { _buzz = value; }
        }
        [Range(1, int.MaxValue, ErrorMessage = "Start needs to be bigger than {1}")]
        public int Start
        {
            get { return _start; }
            set { _start = value; } 
        }
        [Range(1, int.MaxValue, ErrorMessage = "End needs to be bigger than {1}")]
        public int End
        {
            get { return _end; }
            set { _end = value; }
        }

        public int Bazz
        {
            get { return _bazz; }
            set { _bazz = value; }
        }


        public string[] FizzBuzz(int start, int end)
        {
            int result_length = end - start + 1;
            int count = 0;
            string[] result = new string[result_length];
            for (int i = start; i <= end; i++)
            {
                if(i % _fizz == 0 && i % _buzz == 0)
                {
                    result[count] = "FizzBuzz, ";
                }
                else if(i % _fizz == 0)
                {
                    result[count] = "Fizz, ";
                }
                else if(i % _buzz == 0)
                {
                    result[count] = "Buzz, ";
                }
                else
                {
                    result[count] = i.ToString() + ", ";
                }
                count++;
            }
            result[count - 1] = result[count - 1].TrimEnd(", ".ToCharArray());
            return result;
        }

        public string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz)
        {
            int result_length = end - start + 1;
            int count = 0;
            string[] result = new string[result_length];
            for (int i = start; i <= end; i++)
            {
                if (i % _fizz == 0 && i % _buzz == 0)
                {
                    result[count] = "FizzBuzz, ";
                    if(bazz.Invoke(i))
                    {
                        result[count] = result[count].TrimEnd(", ".ToCharArray());
                        result[count] += "Bazz, ";
                    }
                }
                else if (i % _fizz == 0)
                {
                    result[count] = "Fizz, ";
                }
                else if (i % _buzz == 0)
                {
                    result[count] = "Buzz, ";
                }
                else
                {
                    result[count] = i.ToString() + ", ";
                }
                count++;
            }
            result[count - 1] = result[count - 1].TrimEnd(", ".ToCharArray());
            return result;
        }

    }
}