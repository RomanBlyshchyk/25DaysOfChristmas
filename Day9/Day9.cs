using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Day9
    {
        static void Main(string[] args)
        {
        }
    }


    /*
        Garbage:
            <>, empty garbage.
            <random characters>, garbage containing random characters.
            <<<<>, because the extra < are ignored.
            <{!>}>, because the first > is canceled.
            <!!>, because the second ! is canceled, allowing the > to terminate the garbage.
            <!!!>>, because the second ! and the first > are canceled.
            <{o"i!a,<{i<a>, which ends at the first >.

        Groups:
            {}, 1 group.
            {{{}}}, 3 groups.
            {{},{}}, also 3 groups.
            {{{},{},{{}}}}, 6 groups.
            {<{},{},{{}}>}, 1 group (which itself contains garbage).
            {<a>,<a>,<a>,<a>}, 1 group.
            {{<a>},{<a>},{<a>},{<a>}}, 5 groups.
            {{<!>},{<!>},{<!>},{<a>}}, 2 groups (since all but the last > are canceled).
    */
}
