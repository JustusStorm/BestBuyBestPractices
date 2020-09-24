using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices.DepartmentFolder
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();// stubbed out method
    }
}
