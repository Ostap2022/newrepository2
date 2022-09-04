using Dapper;
using Artsofte.Properties;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Artsofte.Controllers

{

    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public Guid Department { get; set; }

    }
}







