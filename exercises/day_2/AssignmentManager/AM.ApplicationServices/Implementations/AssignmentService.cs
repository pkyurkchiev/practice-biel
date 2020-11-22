using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Assignments;
using AM.ApplicationServices.ViewModels;
using AM.Data.Entities;
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
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        StatedOn = item.StartedOn,
                        EndedOn = item.EndedOn,
                        OwnerFullName = item.User != null ? item.User.FirstName + " " + item.User.LastName : "",
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

                if (assignment != null)
                {
                    response.Assignment = new AssignmentViewModel
                    {
                        Id = assignment.Id,
                        Title = assignment.Title,
                        Description = assignment.Description,
                        StatedOn = assignment.StartedOn,
                        EndedOn = assignment.EndedOn,
                        OwnerFullName = assignment.User != null ? assignment.User.FirstName + " " + assignment.User.LastName : "",
                        IsActive = assignment.IsActive
                    };
                }
                else
                {
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    response.StatusDescription = "Assignment not found";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public InsertAssignmentResponse Insert(InsertAssignmentRequest request)
        {
            InsertAssignmentResponse response = new InsertAssignmentResponse();

            try
            {
                var assignment = new Assignment
                {
                    Title = request.AssignmentProperties.Title,
                    Description = request.AssignmentProperties.Description,
                    StartedOn = request.AssignmentProperties.StatedOn,
                    EndedOn = request.AssignmentProperties.EndedOn,
                    OwnedBy = request.AssignmentProperties.OwnerBy,
                    IsActive = true
                };

                _unitOfWork.Assignments.Insert(assignment);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public DeleteAssignmentResponse Delete(DeleteAssignmentRequest request)
        {
            DeleteAssignmentResponse response = new DeleteAssignmentResponse();

            try
            {
                _unitOfWork.Assignments.Delete(request.Id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }

            return response;
        }

        public UpdateAssignmentResponse Update(UpdateAssignmentRequest request)
        {
            UpdateAssignmentResponse response = new UpdateAssignmentResponse();

            try
            {
                var assignment = _unitOfWork.Assignments.GetById(request.Id);
                assignment.Title = request.AssignmentProperties.Title ?? assignment.Title;
                assignment.Description = request.AssignmentProperties.Description ?? assignment.Description;

                _unitOfWork.Assignments.Update(assignment);
                _unitOfWork.SaveChanges();
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
