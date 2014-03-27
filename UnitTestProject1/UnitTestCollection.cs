using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;


namespace UnitTestProject1
{
    public class Book : IEquatable<Book>
    {
        public string Name {set; get; }
        public string Writter { set; get; }

        public Book(string _Name, string _Writter)
        {
            Name = _Name;
            Writter = _Writter;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Book objAsBook = obj as Book;
            if (objAsBook == null) return false;
            else return Equals(objAsBook);
        }

        public bool Equals(Book book)
        {
            return (this.Name == book.Name) &&
                (this.Writter == book.Writter);
        }

    }
    [TestClass]
    public class UnitTestCollection
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Book> phoneBooklist = new List<Book>(100);
            phoneBooklist.Add(new Book("aaa", "bbb"));
            Book pb = new Book("yyy", "xxx");
            phoneBooklist.Add(pb);
            phoneBooklist.Add(new Book( "lll","xxx") );
            bool cont = phoneBooklist.Contains(pb);
            if (cont)
            {
               Debug.WriteLine("fount book" + pb.Name);
            }

      //      pb = new Book("zzz", "yyy");
            cont = phoneBooklist.Contains(new Book("zzz", "yyy"));
            if (!cont)
            {
                Debug.WriteLine("not fount book zzz");
            }
            Debug.WriteLine("size array = " + phoneBooklist.Count.ToString());
            Debug.WriteLine("Capacity = " + phoneBooklist.Capacity.ToString());
            int index = phoneBooklist.BinarySearch(pb);
            Debug.WriteLine("book index = " + index.ToString());
            phoneBooklist.Insert(phoneBooklist.Count, new Book("aaaa", "bbbbb"));
            index = phoneBooklist.BinarySearch(pb);
        }
    }
}
