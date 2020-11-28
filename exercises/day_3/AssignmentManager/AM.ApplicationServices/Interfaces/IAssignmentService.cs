using AM.ApplicationServices.Messaging.Assignments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.ApplicationServices.Interfaces
{
    public interface IAssignmentService
    {
        GetAssignmentsResponse GetAll();
        GetAssignmentResponse GetById(GetAssignmentRequest request);
        InsertAssignmentResponse Insert(InsertAssignmentRequest request);
        DeleteAssignmentResponse Delete(DeleteAssignmentRequest request);
        UpdateAssignmentResponse Update(UpdateAssignmentRequest request);
    }
}
