using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public object Giver { get; set; }
        public object Recipient { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
    }
}
