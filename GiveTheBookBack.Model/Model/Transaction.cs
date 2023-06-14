using GiveTheBookBack.Domain.Enums;

namespace GiveTheBookBack.Domain.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public int GiverRef { get; set; }        
        public int RecipientRef { get; set; }  
        public State State { get; set; }
        public int BookRef { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; }
    }
}
