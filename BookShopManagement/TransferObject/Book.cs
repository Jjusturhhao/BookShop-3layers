using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
     public class Book
    {
        public string Bookid { get; set; }
        public string Bookname { get; set; }
        public string Categoryid { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public byte[] Bookimage { get; set; }

        public Book(string bookid, string bookname, string categoryid, string author, string price, byte[] bookimage)
        {
            Bookid = bookid;
            Bookname = bookname;
            Categoryid = categoryid;
            Author = author;
            Price = price;
            Bookimage = bookimage;
        }
    }
}
