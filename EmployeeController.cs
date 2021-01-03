/**
 * EmployeeController.cs
 * @Author : Group 7 - Deepthi Warrier, Mayuree Binjolkar, Sumitha Ravindran
 * @Date: 09/Feb/2020
 * The Controller class for the Employee. The following REST services are provided by the controller.
 * GET - Route("employeedetails/") - Employees Details - Gets all the Employees from the Employee Table
 * POST - Route("employee/") - Adds a new record to the Employee Table
 * PUT - Route("employee/{id}/{phoneNumber}") - Updates the phone Number for an employee
 * DELETE - Route("employee/delete/{id}") - Deletes the Employee Record
 */

using ADC_HW2.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ADC_HW2.Controllers
{
    public class EmployeeController : ApiController
    {
        private static SqlConnection sqlConn = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = "employeedb.cjgqlqwkkaik.us-east-1.rds.amazonaws.com",
                InitialCatalog = "EmployeeDB",
                UserID = "admin",
                Password = "nkaEZV6al5RbbtSGdx3i"
            }.ConnectionString
            );

        [ApiExplorerSettings(IgnoreApi = true)] // Controls the visiblilty
        [NonAction] // Do not wish to use HTTP Methods on this method - An Internal Method
        public DataSet executeSQL(string sqlStatement)
        {
            try
            {
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlStatement, sqlConn);
                DataSet myResultSet = new DataSet();
                sqlAdapter.Fill(myResultSet, "EmployeeDetails");
                return myResultSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get All the records in the Employee Table
        [HttpGet]
        [Route("employeedetails/")]
        public IHttpActionResult GetEmployeeDetails()
        {
            try
            {
                string query = "SELECT * from Employee";
                DataSet employeeDetails = executeSQL(query);

                // Returns all the records of the Employee Table 
                if (employeeDetails.Tables[0].Rows.Count > 0)
                    return Ok(employeeDetails);
                return BadRequest("Information unavailable at the moment.");
            }
            catch (Exception ex)
            {
                return BadRequest("Oops!!! Something went wrong. Please try after sometime." + ex.Message);
            }
        }
        
        ///@desc: Add a Record to the Employee Table
        ///@param: Employee Object.
        ///@return: HTTPRespose if it was successful or not.
        [HttpPost]
        [Route("employee/")]
        public HttpResponseMessage PostEmployee([FromBody]Employee employee)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string query = "INSERT INTO Employee VALUES(" + employee.Id + ",'" + employee.firstName + "','" + employee.lastName + "','" +
                    employee.phoneNumber + "','" + employee.emailId + "'," + employee.age + ")";

                executeSQL(query);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Status", "Employee added successfully");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("Status", "No records were added");
                return response;
            }
            return response;
        }

        //Updates the Phone Number of an Employee in the Employee
        [HttpPut]
        [Route("employee/{id}/{phoneNumber}")]
        public HttpResponseMessage UpdatePhoneNumber([FromUri]int id, [FromUri]string phoneNumber)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string query = "UPDATE Employee SET " + "phonenumber = '" + phoneNumber + "' WHERE id = " + id;

                executeSQL(query);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Status", "PhoneNumber updated successfully");                               
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("Status", "No records were updated");
                return response;
            }
            return response;
        }

        //Delete the Employee from the Employee Table
        [HttpDelete]
        [Route("employee/delete/{id}")]
        public HttpResponseMessage deleteEmployee([FromUri]int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string query = "DELETE FROM Employee WHERE id = " + id;

                executeSQL(query);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Status", "Employee deleted successfully");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("Status", "No records were deleted");
                return response;
            }
            return response;
        }
    }
}
