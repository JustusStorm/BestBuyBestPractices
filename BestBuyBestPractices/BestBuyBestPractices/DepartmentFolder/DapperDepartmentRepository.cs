using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace BestBuyBestPractices.DepartmentFolder
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {

        // properties
        private readonly IDbConnection _connection ;

        // constructors
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        // Methods
        public IEnumerable<Department> GetDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");

        }
        public void InsertDepartment(string newDepartment)
        {
            _connection.Execute(
                "INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", 
                 new { departmentName = newDepartment }
                 );
        }


    }
}
