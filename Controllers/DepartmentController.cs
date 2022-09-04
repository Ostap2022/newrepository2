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
    public class DepartmentController : Controller
    {
        [HttpPost]
        public void CreateDepartment([FromBody] Department departments)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                var sqls = $"exec CreateDepartment @Name = '{departments.Name}',  @Floor = {departments.Floor}";

                db.Execute(sqls, CommandType.StoredProcedure); 
            }

                
        }

        [HttpGet]
        public List<Department> Get()
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                return db.Query<Department>("select * from Departments").ToList();
            }
        }


        [HttpPut]
        public void Update([FromBody] Department departments)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";


            using (IDbConnection db = new SqlConnection(connnectionString))
            {

                var sqls = $"exec UpdateDepartment @Name = '{departments.Name}',  @Floor = '{departments.Floor}', @Id = '{departments.Id}'";

                db.Execute(sqls, CommandType.StoredProcedure);
            }
        }

        [HttpDelete]
        public void Delete([FromQuery] Guid id)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                db.Execute($"delete from Departments where Id = {id}");
            }
        }

    }
}
