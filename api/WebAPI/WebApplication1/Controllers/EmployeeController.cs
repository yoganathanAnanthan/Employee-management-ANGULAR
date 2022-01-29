using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select EmployeeId,EmployeeName,DepId,
                convert(varchar(10),DateOfJoining,120) as DateOfJoining,
                PhotoFileName,
                PhoneNumber,
                EmailAddress,
                Position,
                Salary
                from
                dbo.Employee
                ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                    insert into dbo.Employee values
                    (
                    '" + emp.EmployeeName + @"'
                    ,'" + emp.DateOfJoining + @"'
                    ,'" + emp.PhotoFileName + @"'
                    ,'" + emp.PhoneNumber + @"'
                    ,'" + emp.EmailAddress + @"'
                    ,'" + emp.Position + @"'
                    ,'" + emp.Salary + @"'
                    ,'" + emp.DepId + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!!";
            }
            catch (Exception)
            {
                return "Fail to Add!!!";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"
                    update dbo.Employee set 
                    EmployeeName='" + emp.EmployeeName + @"'
                    ,DepId='" + emp.DepId + @"'
                    ,DateOfJoining='" + emp.DateOfJoining + @"'
                    ,PhotoFileName='" + emp.PhotoFileName + @"'
                    ,PhoneNumber= '" + emp.PhoneNumber + @"'
                    ,EmailAddress= '" + emp.EmailAddress + @"'
                    ,Position= '" + emp.Position + @"'
                    ,Salary= '" + emp.Salary + @"'
                    where EmployeeId=" + emp.EmployeeId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!!";
            }
            catch (Exception)
            {
                return "Fail to Update!!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Employee
                    where EmployeeId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Delete Successfully!!!";
            }
            catch (Exception)
            {
                return "Fail to Delete!!!";
            }
        }


        [Route("api/Employee/GetAllDepartmentId")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentId() 
        {
            string query = @"
                    select DepartmentId from dbo.Department
                    ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        [Route("api/Employee/SaveFile")]
        public string SaveFile() 
        {
            try 
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalpath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalpath);

                return filename;
            }
            catch (Exception)
            {
                return "anonymous.jpg";
            }
        }
    }
}
