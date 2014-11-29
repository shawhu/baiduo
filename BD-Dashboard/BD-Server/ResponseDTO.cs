using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD_Server
{
    public class ResponseDTO
    {
        public string Result { get; set; }
    }

    public class RspsDTO_Data
    {
        public List<Sensor_Data> sensor_data_list { get; set; }
    }


    public class Sensor_Data
    {
        public int data_id { get; set; }
        public string data_type { get; set; }
        public double data_value { get; set; }
        public string record_date { get; set; }
        public int station_id { get; set; }
    }
}