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
    public class ProgramminglanguageController : Controller
    {
        [HttpPost]
        public void CreateProgramminglanguage([FromBody] Programminglanguage programminglanguages)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";


            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                var sqls = $"exec CreateProgrammingLang @Name = {programminglanguages.Name}"; 

                db.Execute(sqls, CommandType.StoredProcedure);
            }

           
        }
        [HttpGet]
        public List<Programminglanguage> Get()
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                return db.Query<Programminglanguage>("select * from Programminglanguages").ToList();
            }
        }

        [HttpPut]
        public void Update([FromBody] Programminglanguage programminglanguages)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";


            using (IDbConnection db = new SqlConnection(connnectionString))
            {

                var sqls = $"exec UpdateProgrammingLang @Name = '{programminglanguages.Name}', @Id ='{programminglanguages.Id}'"; 

                db.Execute(sqls, CommandType.StoredProcedure);
            }
        }
        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            string connnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;";

            using (IDbConnection db = new SqlConnection(connnectionString))
            {
                db.Execute($"delete from Programminglanguages where Id = {id}");
            }
        }


    }
}