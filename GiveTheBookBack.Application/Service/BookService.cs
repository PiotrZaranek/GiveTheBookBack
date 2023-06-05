using AutoMapper;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Add(NewBookVm bookVm)
        {
            var book = _mapper.Map<Book>(bookVm);
            return _repository.Add(book).Result;
        }

        public int Delete(int id)
        {
            var book = _repository.Get(id).Result;

            if(book != null)
            {
                return _repository.Delete(book).Result;
            }

            return 0;
        }

        public BookForDetailsVm Details(int id)
        {
            var book = _repository.Get(id).Result;

            if(book != null)
            {
                var bookVm = _mapper.Map<BookForDetailsVm>(book);
                return bookVm;
            }

            return null;
        }

        public ListBookForListVm GetAll()
        {
            var listBikeVm = _mapper.Map<List<Book>, List<BookForListVm>>(_repository.GetAll().Result);

            return new ListBookForListVm()
            {
                BookList = listBikeVm,
                Count = listBikeVm.Count
            };
        }
    }
}
