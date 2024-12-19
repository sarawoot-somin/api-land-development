using System.ComponentModel.DataAnnotations;

namespace API_IoT.Models
{
    public class DroneModel
    {
        public string Drone_ID { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class SensorModel
    {
        public string Sensor_ID { get; set; }
        public string Sensor_name { get; set; }
        public string Description { get; set; }
        public decimal Threshold { get; set; }
        public string Threshold_unit { get; set; }
        public int Status { get; set; }

    }
    public class UserModel
    {
        public string User_ID { get; set; }
        public string User_type_ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string License_description { get; set; }
        public DateTime Update_status_date { get; set; }
        public int Status { get; set; }
        public string Site_address { get; set; }
        public string Country { get; set; }


    }
}
