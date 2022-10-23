using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book> // without : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] titles)
        {
            books = new List<Book>(titles);
        }
        //public IEnumerator<Book> GetEnumerator()
        //{
        //    for (int i = 0; i < this.books.Count; i++)
        //    {
        //        yield return this.books[i];
        //    }
        //}

        // ONLY FOR  JUDGE

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;

        }

    }

}
