﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get() 
        {
            string query = @"
                select DepartmentId,DepartmentName,ManagerId,NoOfEmp
                from
                dbo.Department
                ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using(var cmd=new SqlCommand(query,con))
            using(var da= new SqlDataAdapter(cmd)) 
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post(Department dep)
        {
            try
            {
                string query = @"
                    insert into dbo.Department values
                    (
                    '" + dep.DepartmentName + @"'
                    ,'" + dep.NoOfEmp + @"'
                    ,'" + dep.ManagerId + @"'
                    
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

        public string Put(Department dep)
        {
            try
            {
                string query = @"
                    update dbo.Department set DepartmentName=
                    '" + dep.DepartmentName + @"'
                    ,NoOfEmp='" + dep.NoOfEmp + @"'
                    ,ManagerId='" + dep.ManagerId + @"'
                    where DepartmentId=" + dep.DepartmentId + @"
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
                    delete from dbo.Department
                    where DepartmentId=" + id + @"
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
    }
}
