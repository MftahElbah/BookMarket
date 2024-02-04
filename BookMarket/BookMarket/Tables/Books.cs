using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
namespace BookMarket.Tables
{
    public class Books
    {
        [PrimaryKey,AutoIncrement] 
        public int BookId { get; set; }
        public string BookName {  get; set; }

        public string AuthorName {  get; set; }

        public float Price { get; set; }

        public byte[] BookPic { get; set; }
    }
}
