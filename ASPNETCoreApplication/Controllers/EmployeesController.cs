using ASPNETCoreApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;


//https://localhost:7133/api/Employees/GetAllEmployees

namespace ASPNETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public EmployeesController(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        [HttpGet]
        [Route("getAllEmployees")]
        public string GetEmployes()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Employee> employeeList = new List<Employee>();
            Response response = new Response();
            string returning_result = "";

            if (dt.Rows.Count > 0 )
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["EmpId"]);
                    employee.Empname = Convert.ToString(dt.Rows[i]["EmpName"]);
                    employee.Password = Convert.ToString(dt.Rows[i]["Password"]);

                    employeeList.Add(employee);

                }
            }

            if(employeeList.Count > 0 ) 
            {
                returning_result =  JsonConvert.SerializeObject(employeeList);
            }

            else
            {
                response.StatusCodde = 100;
                response.ErrorMessage = "No data found";
                returning_result = JsonConvert.SerializeObject(response);
            }

            return returning_result;


        }
    }
}
