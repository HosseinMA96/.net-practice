using ASPNETCoreApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        //This method returns all employees
        [HttpGet]
       // [Route("getAllEmployees")]
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
                    employee.EmpId = Convert.ToInt32(dt.Rows[i]["EmpId"]);
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

        
        //This method returns one employee with specific Empid
        [HttpGet("{Empid}")]
        public string GetSingleEmployee(int Empid)
        {
        

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Employees WHERE Empid = {Empid}", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();
            string returning_result = "";

            if (dt.Rows.Count > 0)
              {

                
                Employee employee = new Employee();
                employee.EmpId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                employee.Empname = Convert.ToString(dt.Rows[0]["EmpName"]);
                employee.Password = Convert.ToString(dt.Rows[0]["Password"]);


                returning_result = JsonConvert.SerializeObject(employee);
              }
            

            else
            {
                response.StatusCodde = 100;
                response.ErrorMessage = "No data found";
                returning_result = JsonConvert.SerializeObject(response);
            }

            return returning_result;
        }



        [HttpPost]
        public string AddEmployee(Employee employee)
        {

            Response response = new Response();
            var returning_result = "";

            try
            {
             
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                con.Open();

          

                var insert_command = $"INSERT INTO Employees (EmpId, EmpName, Password) VALUES  (\'{employee.EmpId}\', \'{employee.Empname}\', \'{employee.Password}\');";

                SqlDataAdapter adapter = new SqlDataAdapter();

                var command = new SqlCommand(insert_command, con);
                adapter.InsertCommand = new SqlCommand(insert_command, con);



                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
	        	con.Close();

                response.StatusCodde = 200;
                response.ErrorMessage = "Employee added successfully";
                returning_result = JsonConvert.SerializeObject(response);



            }

            catch (Exception e)
            {
                response.StatusCodde = 500;
                response.ErrorMessage = "Failed to add to database";
                returning_result = JsonConvert.SerializeObject(response);
            }
            return returning_result;
        }


        [HttpDelete("{Empid}")]
        public string DeleteEmployee(int Empid)
        {

            Response response = new Response();
            var returning_result = "";

            try
            {
                var get_str = GetSingleEmployee(Empid);
                JObject get_json = JObject.Parse(get_str);
                Debug.WriteLine(get_json);



                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                con.Open();



                var delete_command = $"DELETE FROM Employees WHERE EmpId = {Empid};";

                SqlDataAdapter adapter = new SqlDataAdapter();

                var command = new SqlCommand(delete_command, con);
                adapter.DeleteCommand = new SqlCommand(delete_command, con);
                //Debug.WriteLine(insert_command);

                adapter.DeleteCommand.ExecuteNonQuery();

                command.Dispose();
                con.Close();

                response.StatusCodde = 202;
                response.ErrorMessage = "Employee deleted successfully.";
                returning_result = JsonConvert.SerializeObject(response);



            }

            catch (Exception e)
            {
                response.StatusCodde = 404;
                response.ErrorMessage = "Resource does not exist.";
                returning_result = JsonConvert.SerializeObject(response);
            }
            return returning_result;
        }


    }
}
