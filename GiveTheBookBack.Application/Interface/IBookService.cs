using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.Interface
{
    public interface IBookService
    {
        int Add(NewBookVm bookVm);
        int Delete(int id);
        ListBookForListVm GetAll();
        BookForDetailsVm Details(int id);
    }
}
