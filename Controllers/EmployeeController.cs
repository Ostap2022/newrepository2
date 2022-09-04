using Dapper;
using Artsofte.Properties;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Artsofte.Properties;

namespace Artsofte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        [HttpPost]
        public void CreateEmployee([FromBody] Employee employee)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {

                var sqls = $"exec CreateEmploee @Name = '{employee.Name}',  @Surname = '{employee.Surname}',@Age = '{employee.Age}',@Department = '{employee.Department}',@Gender = '{employee.Gender}',@Id = '{employee.Id}' ; ";

                db.Execute(sqls, CommandType.StoredProcedure);
        }   }
        [HttpGet]
        public List<Employee> Get()
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                return  db.Query<Employee>("select * from Employees").ToList();
            }
        }

        [HttpPut]
        public void Update([FromBody] Employee employee)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";


            using (IDbConnection db = new SqlConnection(connnectionString))
            {

                var sqls = $"exec UpdateEmployee @Name = '{employee.Name}',  @Surname = '{employee.Surname}',@Age = '{employee.Age}',@Department = '{employee.Department}',@Gender = '{employee.Gender}',@Id = '{employee.Id}' ; ";

                db.Execute(sqls, CommandType.StoredProcedure);
            }
        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                db.Execute($"delete from Employees where Id = {id}");
            }
        }
















        /// var db = new ApplicationContext();
        ///var newemployee = new Employee()
        // {
        //  Name = employees.Name,
        // Surname = employees.Surname,
        //Age = employees.Age,
        //Gender = employees.Gender,
        //Department = employees.Department

        //};
        ///db.Employees.Add( newemployee);
        ///db.SaveChanges();














    }
}
