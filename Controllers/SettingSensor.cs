using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using API_IoT.Models;

namespace API_IoT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingSensor : ControllerBase
    {
        private IConfiguration _configuration;
        public SettingSensor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Sensor
        [HttpGet]
        [Route("GetSensor")]
        public JsonResult GetSensor()
        {
            string query = "SELECT * FROM Sensor_master";
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
        [Route("AddSensor")]
        public JsonResult AddSensor([FromBody] SensorModel model)
        {
            string query = @"INSERT INTO Sensor_master
	                          VALUES (@Sensor_ID
                              ,@Sensor_name
                              ,@Description
                              ,@Threshold
                              ,@Threshold_unit
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
                    myCommand.Parameters.AddWithValue("@Sensor_ID", model.Sensor_ID);
                    myCommand.Parameters.AddWithValue("@Sensor_name", model.Sensor_name);
                    myCommand.Parameters.AddWithValue("@Description", model.Description);
                    myCommand.Parameters.AddWithValue("@Threshold", model.Threshold);
                    myCommand.Parameters.AddWithValue("@Threshold_unit", model.Threshold_unit);
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
        public JsonResult UpdateDrone([FromBody] SensorModel model)
        {
            string query = @"UPDATE IoTLand.dbo.Sensor_master 
                              SET Sensor_name = @Sensor_name
                              ,Description = @Description
                              ,Threshold = @Threshold
                              ,Threshold_unit = @Threshold_unit
                              ,Status = @Status
                              ,Update_date = @Update_date
                              WHERE Sensor_ID = @Sensor_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Sensor_ID", model.Sensor_ID);
                    myCommand.Parameters.AddWithValue("@Sensor_name", model.Sensor_name);
                    myCommand.Parameters.AddWithValue("@Description", model.Description);
                    myCommand.Parameters.AddWithValue("@Threshold", model.Threshold);
                    myCommand.Parameters.AddWithValue("@Threshold_unit", model.Threshold_unit);
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
        public JsonResult UpdatePhysical([FromBody] SensorModel model)
        {
            string query = @"DELETE FROM IoTLand.dbo.Sensor_master
                                WHERE Sensor_ID = @Sensor_ID";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IoTAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Sensor_ID", model.Sensor_ID);
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
