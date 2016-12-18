using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizzlebizzle.Library
{
    interface IFizzleBizzle
    {
        int Fizz { set; }
        int Buzz{ set; }
        string[] FizzBuzz(int start, int end);
        string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz);
    }
}
