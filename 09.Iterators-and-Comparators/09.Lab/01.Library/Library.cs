using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
        private List<Book> books { get; set; }
        public Library(params Book[] titles)
        {
            books = new List<Book>(titles);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }
    }
}
