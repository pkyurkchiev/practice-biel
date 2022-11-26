using AM.ApplicationServices.Interfaces;
using AM.ApplicationServices.Messaging.Assignments;
using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Implementations
{
    public class AssignmentsService : BaseService, IAssignmentsService
    {
        private readonly ILogger<AssignmentsService> _logger;

        public AssignmentsService(IUnitOfWork unitOfWork, ILogger<AssignmentsService> logger) : base(unitOfWork)
        {
            _logger = logger;
        }

        public GetAssignmentsResponse GetAll()
        {
            GetAssignmentsResponse response = new();
            List<AssignmentViewModel> assignmentViewModels = new();
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
                        StartedOn = item.StartedOn,
                        EndedOn = item.EndedOn,
                        OwnerFullName = item.User == null ? "" : item.User.FirstName + " " + item.User.LastName,
                        IsActive = item.IsActive
                    });
                }
                response.Assignments = assignmentViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a select error!");
                response.BuildException(ex);
            }

            return response;
        }

        public GetAssignmentResponse GetById(GetAssignmentRequest request)
        {
            GetAssignmentResponse response = new();
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
                        StartedOn = assignment.StartedOn,
                        EndedOn = assignment.EndedOn,
                        OwnerFullName = assignment.User == null ? "" : assignment.User.FirstName + " " + assignment.User.LastName,
                        IsActive = assignment.IsActive
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

        public InsertAssignmentResponse Insert(InsertAssignmentRequest request)
        {
            InsertAssignmentResponse response = new();
            try
            {
                Assignment assignment = new()
                {
                    Title = request.AssignmentProperties.Title,
                    Description = request.AssignmentProperties.Description,
                    StartedOn = request.AssignmentProperties.StartedOn,
                    EndedOn = request.AssignmentProperties.EndedOn,
                    OwnedBy = request.AssignmentProperties.OwnedBy,
                    IsActive = true
                };

                _unitOfWork.Assignments.Insert(assignment);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We have a insert error!");
                response.BuildException(ex);
            }
            return response;
        }

        public UpdateAssignmentResponse Update(UpdateAssignmentRequest request)
        {
            UpdateAssignmentResponse response = new();
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
                _logger.LogError(ex, "We have a update error!");
                response.BuildException(ex);
            }
            return response;
        }

        public DeleteAssignmentResponse Delete(DeleteAssignmentRequest request)
        {
            DeleteAssignmentResponse response = new();

            try
            {
                _unitOfWork.Assignments.Delete(request.Id);
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
