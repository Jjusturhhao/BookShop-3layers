using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public int Price { get; set; }
        public string Bookimage { get; set; }
        public int Quantity { get; set; }

        public Book() { }


        public Book(string bookid, string bookname, string categoryid, string author, int price, string bookimage)
        {
            Bookid = bookid;
            Bookname = bookname;
            Categoryid = categoryid;
            Author = author;
            Price = price;
            Bookimage = bookimage;
        }

        public Book(string bookID, string bookName, int price, int quantity)
        {
            Bookid = bookID;
            Bookname = bookName;
            Price = price; 
            Quantity = quantity;
        }
    }
}
