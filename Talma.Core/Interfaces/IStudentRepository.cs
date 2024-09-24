using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talma.Core.Entities;
using Talma.Core.Models;

namespace Talma.Core.Interfaces
{
    public interface IStudentRepository
    {
        Response ListStudents();
        Response GetStudent(StudentByIdRequest obj);
        Response RegStudent(StudentCreateRequest obj);
        Response UpdStudent(StudentUpdateRequest obj);
        Response DelStudent(StudentByIdRequest obj);
    }
}
