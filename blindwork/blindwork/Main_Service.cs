using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blindwork
{
    [EnableCors(allowedMethods: "GET, POST, PUT, DELETE, OPTIONS", allowedHeaders: "Accept,Content-Type,Authorization")]
    public class Main_Service:Service
    {
        //login
        public MemberModel Post(LoginRequest req)
        {
            return MemberModel.Login(req.cellphone, req.confirmation_code);
        }
        //purchase for the first time
        public OrderModel Post(PurchaseRequest req)
        {
            throw new NotImplementedException();
        }
        //get all personal orders

    }
}