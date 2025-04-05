using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Book
    {
        private string bookid;
        private string name;
        private string categoryid;
        private string author;
        private int price;
        private string image;

        public string BookID { get; set; }
        public string BookName { get; set; }
        public string CategoryID { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string BookImage { get; set; }

        public Book()
        {
            
        }

        public Book(string bookid, string name, string categoryid, string author, int price, string image)
        {
            this.BookID = bookid;
            this.BookName = name;
            this.CategoryID = categoryid;
            this.Author = author;
            this.Price = price;
            this.image = image;
        }




        //      BookID VARCHAR(50) PRIMARY KEY,
        //      BookName NVARCHAR(100) NOT NULL,
        //      CategoryID VARCHAR(10) FOREIGN KEY REFERENCES BookCategory(CategoryID),
        //Author NVARCHAR(100) NOT NULL,
        //      Price INT NOT NULL,
        //BookImage NVARCHAR(255)
    }
}
