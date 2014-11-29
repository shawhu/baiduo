using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;


namespace BD_Server
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class RequestDTO
    {
        public string Name { get; set; }
    }

    //get sensor data
    [Route("/sensor")]
    [Route("/sensor/{data}")]
    public class reqDTO_SensorData
    {
        public string data { get; set; }
    }

}