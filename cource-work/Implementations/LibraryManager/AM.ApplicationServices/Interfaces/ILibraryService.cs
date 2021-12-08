using LM.ApplicationServices.Messaging.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Interfaces
{
    public interface ILibraryService
    {
        GetLibraryResponse GetAll();
        GetBookResponse GetById(GetBookRequest request);
        InsertBookResponse Insert(InsertBookRequest request);
        DeleteBookResponse Delete(DeleteBookRequest request);
        UpdateBookResponse Update(UpdateBookRequest request);
    }
}
