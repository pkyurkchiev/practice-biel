using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Assignments;
using AM.ApplicationServices.ViewModels;
using AM.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Implementations
{
    public class AssignmentService : ServiceBase, IAssignmentService
    {
        public AssignmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public GetAssignmentsResponse GetAll()
        {
            GetAssignmentsResponse response = new GetAssignmentsResponse();
            List<AssignmentViewModel> assignmentViewModels = new List<AssignmentViewModel>();

            try
            {
                var assignments = _unitOfWork.Assignments.GetAll();
                foreach (var item in assignments)
                {
                    assignmentViewModels.Add(new AssignmentViewModel
                    {
                        Title = item.Title,
                        Description = item.Description,
                        StatedOn = item.StartedOn,
                        EndedOn = item.EndedOn,
                        IsActive = item.IsActive
                    });
                }
                response.Assignments = assignmentViewModels;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public GetAssignmentResponse GetById(GetAssignmentRequest request)
        {
            GetAssignmentResponse response = new GetAssignmentResponse();

            try
            {
                var assignment = _unitOfWork.Assignments.GetById(request.Id);
                response.Assignment = new AssignmentViewModel {
                    Title = assignment.Title,
                    Description = assignment.Description,
                    StatedOn = assignment.StartedOn,
                    EndedOn = assignment.EndedOn,
                    IsActive = assignment.IsActive
                };
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }
    }
}
