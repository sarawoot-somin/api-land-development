using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using API_IoT.Models;

namespace API_IoT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingDrone : ControllerBase
    {
        private IConfiguration _configuration;

        public SettingDrone(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Drone
        [HttpGet]
        [Route("GetDrone")]
        public JsonResult GetDrone()
        {
            string query = "SELECT * FROM Drone_master";
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
        [Route("AddDrone")]
        public JsonResult AddDrone([FromBody] DroneModel model)
        {
            string query = @"INSERT INTO Drone_master
	                        VALUES (@Drone_ID
	                        ,@Description
                            ,@Status
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
                    myCommand.Parameters.AddWithValue("@Drone_ID", model.Drone_ID);
                    myCommand.Parameters.AddWithValue("@Description", model.Description);
                    myCommand.Parameters.AddWithValue("@Status", model.Status);
                    myCommand.Parameters.AddWithValue("@Create_date", DateTime.UtcNow);
                    myCommand.Parameters.AddWithValue("@Update_date", DateTime.UtcNow);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateDrone")]
        public JsonResult UpdateDrone([FromBody] DroneModel model)
        {
            string query = @"UPDATE IoTLand.dbo.Drone_master 
                              SET Description = @Description
                              ,Status = @Status
                              ,Update_date = @Update_date
                              WHERE Drone_ID = @Drone_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Drone_ID", model.Drone_ID);
                    myCommand.Parameters.AddWithValue("@Description", model.Description);
                    myCommand.Parameters.AddWithValue("@Status", model.Status);
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
        public JsonResult UpdatePhysical([FromBody] DroneModel model)
        {
            string query = @"DELETE FROM IoTLand.dbo.Drone_master
                                WHERE Drone_ID = @Drone_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Drone_ID", model.Drone_ID);
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
