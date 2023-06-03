using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.ViewModel
{
    public class BookForListVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
    }
}
