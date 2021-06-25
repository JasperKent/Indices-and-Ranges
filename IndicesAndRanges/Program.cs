using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace IndicesAndRanges
{
    class MyCollection : IEnumerable<string>
    {
        private List<string> _values = new List<string>();

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)_values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_values).GetEnumerator();
        }

        public void Add(string value) => _values.Add(value);

        public int Count => _values.Count;
        public string this[int idx] => _values[idx];

        public List<string> Slice(int start, int length) => _values.Skip(start).Take(length).ToList();
    }

    class Program
    {
        static void Main()
        {
            var names = new MyCollection { "Thomas", "Richard", "Harriet", "Charlotte", "Harpo", "Groucho", "Chico", "Zeppo", "Gummo" };
            
            var bob = new StringBuilder();

            var range = 2..^5;

            foreach (var name in names[range])
            {
                bob.Append(name).Append(", ");
            }

            var result = bob.ToString();

            Console.WriteLine(result[..^2]);

            Console.WriteLine(names[^5]);
        }
    }
}
