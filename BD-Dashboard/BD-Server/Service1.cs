using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using System.Data;

namespace BD_Server
{
    public class Service1:Service
    {
        public object Any(RequestDTO request)
        {
            return new ResponseDTO { Result = "Hello, " + request.Name };
        }

        //this is to clear all the data from the DB and go again, this is for testing period, after that we will remove this func
        public object DELETE(reqDTO_SensorData request)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "delete from sensor_data";
            dbo.ExecuteNonQuery();
            return new ResponseDTO { Result = "sensor_data cleared" };
        }
        
        public object POST(reqDTO_SensorData request)
        {
            string rawdata = request.data;
            if (string.IsNullOrEmpty(rawdata))
                return new ResponseDTO { Result = "Data is empty" };
            string[] array1 = rawdata.Split(',');

            double temp = Convert.ToDouble(array1[0].ToString());
            double humidity = Convert.ToDouble(array1[1].ToString());
            double co2lvl = Convert.ToDouble(array1[2].ToString());

            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "insert into sensor_data (data_type,data_value,station_id) values ('temp'," + temp.ToString() + ",2);";
            dbo.SqlComm += "insert into sensor_data (data_type,data_value,station_id) values ('humid'," + humidity.ToString() + ",2);";
            dbo.SqlComm += "insert into sensor_data (data_type,data_value,station_id) values ('CO2'," + co2lvl.ToString() + ",2);";
            dbo.ExecuteNonQuery();
            return new ResponseDTO { Result = "Saved with data:" + request.data };
        }
        

        public object GET(reqDTO_SensorData request)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from sensor_data";
            DataTable dt = new DataTable();
            dbo.GetDataTable(dt);
            RspsDTO_Data result = new RspsDTO_Data();
            result.sensor_data_list = new List<Sensor_Data>();
            foreach(DataRow dr in dt.Rows)
            {
                Sensor_Data data = new Sensor_Data();
                data.data_id = (int)dr["data_id"];
                data.data_type = dr["data_type"].ToString();
                data.data_value = Convert.ToDouble( dr["data_value"].ToString());
                data.record_date = dr["record_date"].ToString();
                data.station_id = (int)dr["station_id"];
                result.sensor_data_list.Add(data);
            }
            return result;
        }




        //sensor interval
        public object GET(reqDTO_SensorInterval request)
        {
            return "6";
        }




    }
}
