using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.ViewModel
{
    public class ListBookForListVm
    {
        public List<BookForListVm> BookList { get; set; }
        public int Count { get; set; }
    }
}
