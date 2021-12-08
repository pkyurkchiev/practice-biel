using LM.ApplicationServices.Interfaces;
using LM.ApplicationServices.Messaging.Library;
using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.ApplicationServices.Implementations
{
    public class LibraryService : BaseService, ILibraryService
    {
        private readonly ILogger<LibraryService> _logger;

        public LibraryService(IUnitOfWork unitOfWork, ILogger<LibraryService> logger) : base(unitOfWork)
        {
            _logger = logger;
        }

        public GetLibraryResponse GetAll()
        {
            GetLibraryResponse response = new();
            List<BookViewModel> bookViewModels = new();
            try
            {
                var library = _unitOfWork.Library.GetAll();
                foreach (var item in library)
                {
                    bookViewModels.Add(new BookViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        StartedOn = item.StartedOn,
                        EndedOn = item.EndedOn,
                        OwnerFullName = item.User == null ? "" : item.User.FirstName + " " + item.User.LastName,
                        IsActive = item.IsActive
                    });
                }
                response.Library = bookViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a select error!");
                response.BuildException(ex);
            }

            return response;
        }

        public GetBookResponse GetById(GetBookRequest request)
        {
            GetBookResponse response = new();
            try
            {
                var book = _unitOfWork.Library.GetById(request.Id);
                if (book != null)
                {
                    response.Book = new BookViewModel
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        StartedOn = book.StartedOn,
                        EndedOn = book.EndedOn,
                        OwnerFullName = book.User == null ? "" : book.User.FirstName + " " + book.User.LastName,
                        IsActive = book.IsActive
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a select error!");
                response.BuildException(ex);
            }

            return response;
        }

        public InsertBookResponse Insert(InsertBookRequest request)
        {
            InsertBookResponse response = new();
            try
            {
                int? ownedBy = null;
                if (request.BookProperties.OwnedBy != 0)
                    ownedBy = request.BookProperties.OwnedBy;

                Library book = new()
                {
                    Title = request.BookProperties.Title,
                    Description = request.BookProperties.Description,
                    StartedOn = request.BookProperties.StartedOn,
                    EndedOn = request.BookProperties.EndedOn,
                    OwnedBy = ownedBy,
                    IsActive = true
                };

                _unitOfWork.Library.Insert(book);
                _unitOfWork.SaveChanges();

                response.Book = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    StartedOn = book.StartedOn,
                    EndedOn = book.EndedOn,
                    OwnerFullName = book.User != null ? book.User.FirstName + " " + book.User.LastName : "",
                    IsActive = book.IsActive
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a insert error!");
                response.BuildException(ex);
            }
            return response;
        }

        public UpdateBookResponse Update(UpdateBookRequest request)
        {
            UpdateBookResponse response = new();
            try
            {
                var book = _unitOfWork.Library.GetById(request.Id);
                book.Title = request.BookProperties.Title ?? book.Title;
                book.Description = request.BookProperties.Description ?? book.Description;

                _unitOfWork.Library.Update(book);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a update error!");
                response.BuildException(ex);
            }
            return response;
        }

        public DeleteBookResponse Delete(DeleteBookRequest request)
        {
            DeleteBookResponse response = new();

            try
            {
                _unitOfWork.Library.Delete(request.Id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a delete error!");
                response.BuildException(ex);
            }
            return response;
        }
    }
}
