using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book> // : IEnumerable<Book> only for Legacy and Judge
    {
        private List<Book> books;
        public Library(params Book[] titles)
        {
            this.books = new List<Book>(titles);
            this.books.Sort();
        }
        // Yield return

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator(); // only for Judge

        //// THIS IS LEGACY!!!

        //public IEnumerator<Book> GetEnumerator()
        //{
        //    return new LibraryIterator(this.books);
        //}
        //IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    private readonly List<Book> books;
        //    private int currentIndex;

        //    public LibraryIterator(IEnumerable<Book> books)
        //    {
        //        this.Reset();
        //        this.books = new List<Book>(books);

        //    }
        //    public void Dispose() { }
        //    public bool MoveNext() => ++this.currentIndex < this.books.Count;
        //    public void Reset() => this.currentIndex = -1;
        //    public Book Current => this.books[this.currentIndex];
        //    object IEnumerator.Current => this.Current;

        //}

    }

}
