using ServiceStack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blindwork
{
    [EnableCors(allowedMethods: "GET, POST, PUT, DELETE, OPTIONS", allowedHeaders: "Accept,Content-Type,Authorization")]
    public class Main_Service:Service
    {
        ////login,也用于注册，如果返回为false就是为发送完验证码，需要带上验证码再发送一次请求才能完成注册登陆过程,也可用于登陆
        //public object Post(JudementLogin req)
        //{
        //    //判断是第一次购买还是已有账号
        //    if (MemberModel.Judgment(req.cellphone, req.fullname, req.email, req.confirmation_code))
        //    {
        //        return new MemberModel(req.cellphone);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //获得用户
        public MemberModel Get(GetMemberRequest req)
        {
            var token = base.Request.Headers["Authorization"];
            MemberModel member = MemberModel.GetMemberByToken(token);
            return member;
            //throw new NotImplementedException();
            //return MemberModel.Login(req.cellphone, req.confirmation_code);
        }

        //purchase for the first time
        public OrderModel Post(PurchaseRequest req)
        {
            var token = base.Request.Headers["Authorization"];
            MemberModel member = new MemberModel();
            if (!string.IsNullOrEmpty(token))
            {
                member = MemberModel.GetMemberByToken(token);
            }
            else if (string.IsNullOrEmpty(token))
            {
                member = MemberModel.SignUpMember(req.cellphone, req.fullname, req.confirmation_code);
            }
            int address_id = AddressModel.CreateAddress(member.member_id, req.address, req.city, req.province);
            OrderModel order = OrderModel.CreateOrder(req.order_id, member.member_id, address_id, req.amount, req.delivery_date_scheduled);

            return order;
        }
  
        //wechat login
        public MemberModel Post(WXLoginRequest req)
        {
            MemberModel mm = MemberModel.GetMemberByWechat(req.wechatid);
            return mm;
        }

        //支付
        public OrderModel Post(PaymentRequest req)
        {
            var token = base.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(ConfigurationManager.AppSettings["empty_token"].ToString());
            MemberModel mm = MemberModel.GetMemberByToken(token);
            OrderModel order = OrderModel.PaymentRequest(req.order_id, mm.member_id, req.status);
            return order;
        }

        //获得所有订单
        public Orders Get(GetAllOrdersRequest req)
        {
            var token = base.Request.Headers["Authorization"];
            if(string.IsNullOrEmpty(token))
                throw new ArgumentNullException(ConfigurationManager.AppSettings["empty_token"].ToString());
            MemberModel mm = MemberModel.GetMemberByToken(token);
            var orders = OrderModel.GetAllOrders(mm.member_id);
            return orders;
        }

        //disabled一个order
        public OrderModel Post(CancelOrderRequest req)
        {
            var token = base.Request.Headers["Authorization"];
            if(string.IsNullOrEmpty(token))
                throw new ArgumentNullException(ConfigurationManager.AppSettings["empty_token"].ToString());
            MemberModel mm = MemberModel.GetMemberByToken(token);
            OrderModel order = OrderModel.DisabledOrders(mm.member_id, req.order_id);
            return order;
        }
    }
}