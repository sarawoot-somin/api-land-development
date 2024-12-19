using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using API_IoT.Models;

namespace API_IoT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingUser: ControllerBase
    {
        private IConfiguration _configuration;
        public SettingUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region User
        [HttpGet]
        [Route("GetUser")]
        public JsonResult GetMember()
        {
            string query = "SELECT * FROM User_master";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("AddUser")]
        public JsonResult AddSensor([FromBody] UserModel model)
        {
            string query = @"INSERT INTO User_master
	                          VALUES (@User_ID
                              ,@User_type_ID
                              ,@First_name
                              ,@Last_name
                              ,@Email
                              ,@Phone
                              ,@Position
                              ,@Company
                              ,@License_description
                              ,@Status
                              ,@Update_status_date
                              ,@Site_address
                              ,@Country
                              ,@Create_date
                              ,@Update_date)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@User_ID", model.User_ID);
                    myCommand.Parameters.AddWithValue("@User_type_ID", model.User_type_ID);
                    myCommand.Parameters.AddWithValue("@First_name", model.First_name);
                    myCommand.Parameters.AddWithValue("@Last_name", model.Last_name);
                    myCommand.Parameters.AddWithValue("@Email", model.Email);
                    myCommand.Parameters.AddWithValue("@Phone", model.Phone);
                    myCommand.Parameters.AddWithValue("@Position", model.Position);
                    myCommand.Parameters.AddWithValue("@Company", model.Company);
                    myCommand.Parameters.AddWithValue("@License_description", model.License_description);
                    myCommand.Parameters.AddWithValue("@Status", model.Status);
                    myCommand.Parameters.AddWithValue("@Update_status_date", model.Update_status_date);
                    myCommand.Parameters.AddWithValue("@Site_address", model.Site_address);
                    myCommand.Parameters.AddWithValue("@Country", model.Country);
                    myCommand.Parameters.AddWithValue("@Create_date", DateTime.UtcNow);
                    myCommand.Parameters.AddWithValue("@Update_date",DateTime.UtcNow);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateUser")]
        public JsonResult UpdateDrone([FromBody] UserModel model)
        {
            string query = @"UPDATE User_master 
                              SET User_type_ID = @User_type_ID
                              ,First_name = @First_name
                              ,Last_name = @Last_name
                              ,Email = @Email
                              ,Phone = @Phone
                              ,Position = @Position
                              ,Company = @Company
                              ,License_description = @License_description
                              ,Status = @Status
                              ,Update_status_date = @Update_status_date
                              ,Site_address = @Site_address
                              ,Country = @Country
                              ,Update_date = @Update_date
                              WHERE User_ID = @User_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@User_ID", model.User_ID);
                    myCommand.Parameters.AddWithValue("@User_type_ID", model.User_type_ID);
                    myCommand.Parameters.AddWithValue("@First_name", model.First_name);
                    myCommand.Parameters.AddWithValue("@Last_name", model.Last_name);
                    myCommand.Parameters.AddWithValue("@Email", model.Email);
                    myCommand.Parameters.AddWithValue("@Phone", model.Phone);
                    myCommand.Parameters.AddWithValue("@Position", model.Position);
                    myCommand.Parameters.AddWithValue("@Company", model.Company);
                    myCommand.Parameters.AddWithValue("@License_description", model.License_description);
                    myCommand.Parameters.AddWithValue("@Status", model.Status);
                    myCommand.Parameters.AddWithValue("@Update_status_date", model.Update_status_date);
                    myCommand.Parameters.AddWithValue("@Site_address", model.Site_address);
                    myCommand.Parameters.AddWithValue("@Country", model.Country);
                    myCommand.Parameters.AddWithValue("@Update_date", DateTime.UtcNow);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Successfully");
        }

        [HttpDelete]
        [Route("DeleteDrone")]
        public JsonResult UpdatePhysical([FromBody] SensorModel model)
        {
            string query = @"DELETE FROM User_master
                                WHERE User_ID = @User_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@User_ID", model.Sensor_ID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Delete Successfully");
        }
        #endregion
    }
}
