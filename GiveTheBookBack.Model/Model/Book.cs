using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public int UserRef { get; set; }
        public User User { get ; set; }
        public Transaction Transaction { get; set; }
    }
}
