using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blindwork
{
    ///// <summary> 
    ///// 购买  已死
    ///// </summary>
    //[Route("/purchase")]
    //public class PurchaseRequest : IReturn<OrderModel>
    //{
    //    public int address_id { get; set; }
    //    public string cellphone { get; set; }
    //    public string address { get; set; }
    //    public string city { get; set; }
    //    public string province { get; set; }
    //    public double delivery_date_scheduled { get; set; }
    //    public int amount { get; set; }
    //    public int applied_code_id { get; set; }
    //    public string zipcode { get; set; }
    //}

    /// <summary>
    /// 购买
    /// </summary>
    [Route("/purchase")]
    public class PurchaseRequest : IReturn<OrderModel>
    {
        public int order_id { get; set; }
        public string cellphone { get; set; }
        public string confirmation_code { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string fullname { get; set; }
        public double delivery_date_scheduled { get; set; }
        public int amount { get; set; }
    }

    /// <summary>
    /// 支付
    /// </summary>
    [Route("/purchase/pay")]
    public class PaymentRequest : IReturn<OrderModel>
    {
        public int order_id { get; set; }
        /// <summary>
        /// 这里传入成功了还是失败了等等支付的结果
        /// </summary>
        public bool status { get; set; }
    }
    /// <summary>
    /// 获取所有订单
    /// </summary>
    [Route("/purchase/getall")]
    public class GetAllOrdersRequest : IReturn<Orders>
    {

    }
    /// <summary>
    /// 取消订单
    /// </summary>
    [Route("/purchase/cancel")]
    public class CancelOrderRequest : IReturn<OrderModel>
    {
        public int order_id { get; set; }
    }


    //这里来处理传回list<OrderModel>
    public class Orders
    {
        public List<OrderModel> myorders { get; set; }

    }

}