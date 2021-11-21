using AM.ApplicationServices.Messaging.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationServices.Interfaces
{
    public interface IAssignmentsService
    {
        GetAssignmentsResponse GetAll();
        GetAssignmentResponse GetById(GetAssignmentRequest request);
        InsertAssignmentResponse Insert(InsertAssignmentRequest request);
        DeleteAssignmentResponse Delete(DeleteAssignmentRequest request);
        UpdateAssignmentResponse Update(UpdateAssignmentRequest request);
    }
}
