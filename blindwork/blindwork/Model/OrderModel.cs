using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace blindwork
{
    public class OrderModel
    {
        public int order_id { get; set; }
        public int amount { get; set; }
        public double delivery_date_scheduled { get; set; }
        public double delivery_date_actual { get; set; }
        public double gross_price { get; set; }
        public bool status { get; set; }
        public bool disabled { get; set; }
        public MemberModel member { get; set; }
        public AddressModel address { get; set; }
        public int applied_code_id { get; set; }

        internal OrderModel(int order_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_order where order_id = @order_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@order_id", order_id));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.order_id = (int)dr["order_id"];
                    this.member = new MemberModel((int)dr["member_id"]);
                    this.address = new AddressModel((int)dr["address_id"]);
                    this.amount = (int)dr["amount"];
                    this.delivery_date_scheduled = Common.DateTime2Double((DateTime)dr["delivery_date_scheduled"]);
                    if (!string.IsNullOrEmpty(dr["delivery_date_actual"].ToString()))
                        this.delivery_date_actual = Common.DateTime2Double((DateTime)dr["delivery_date_actual"]);
                    this.gross_price = Convert.ToDouble(dr["gross_price"]);
                    if (!string.IsNullOrEmpty(dr["applied_code_id"].ToString()))
                        this.applied_code_id = (int)dr["applied_code_id"];
                    this.status = (bool)dr["status"];
                    this.disabled = (bool)dr["disabled"];
                }
            }
        }


        public OrderModel()
        {
            // TODO: Complete member initialization
        }

       /* //下订单
        internal static OrderModel PurchaseRequest(int member_id, string address, string city, string province, double delivery_date_scheduled, int amount, int applied_code_id,string zipcode,int address_id)
        {
            double gross_price = amount * 30;
            if (address_id > 0)
            {
                //把订单写到数据库中再得到订单id
                int order_id = OrderModel.CreateOrder(member_id, address_id, amount, delivery_date_scheduled, gross_price, applied_code_id);

                return new OrderModel(order_id);
            }
            else
            {
                //把地址写到数据库中再得到地址id
                address_id = AddressModel.CreateAddress(member_id, address, city, province);
                //把订单写到数据库中再得到订单id
                int order_id = OrderModel.CreateOrder(member_id, address_id, amount, delivery_date_scheduled, gross_price, applied_code_id);
                return new OrderModel(order_id);
            }
            
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="address_id"></param>
        /// <param name="amount"></param>
        /// <param name="delivery_date_scheduled"></param>
        /// <param name="gross_price"></param>
        /// <param name="applied_code_id"></param>
        /// <returns></returns>
        internal static int CreateOrder(int member_id, int address_id, int amount, double delivery_date_scheduled, double gross_price, int applied_code_id)
        {
            
            SqlDataObject dbo = new SqlDataObject();
            
            dbo.SqlComm = "insert into t_order(member_id,amount,delivery_date_scheduled,gross_price,applied_code_id) values (@member_id,@amount,@delivery_date_scheduled,@gross_price,@applied_code_id)";

            dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id), new SqlParameter("@amount", amount), new SqlParameter("@delivery_date_scheduled", Common.Double2DateTime(delivery_date_scheduled)), new SqlParameter("gross_price", gross_price), new SqlParameter("@applied_code_id", applied_code_id));

            return SqlDataObject.GetIdentity("order_id");
        }*/

        /// <summary>
        /// 创建订单和修改订单
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="member_id"></param>
        /// <param name="address_id"></param>
        /// <param name="amount"></param>
        /// <param name="delivery_date_scheduled"></param>
        /// <returns></returns>
        internal static OrderModel CreateOrder(int order_id, int member_id, int address_id, int amount, double delivery_date_scheduled)
        {
            double gross_price = amount * 30;
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_order where order_id=@order_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@order_id", order_id));
            if (dt.Rows.Count == 0)
            {
                dbo.SqlComm = "insert into t_order(member_id,address_id,amount,delivery_date_scheduled,gross_price) values (@member_id,@address_id,@amount,@delivery_date_scheduled,@gross_price)";
                dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id), new SqlParameter("@address_id", address_id), new SqlParameter("@amount", amount), new SqlParameter("@delivery_date_scheduled", Common.Double2DateTime(delivery_date_scheduled)), new SqlParameter("@gross_price", gross_price));

                dbo.SqlComm = "select * from t_order where member_id = @member_id and address_id = @address_id and amount = @amount and delivery_date_scheduled = @delivery_date_scheduled and gross_price = @gross_price order by order_id desc";
                dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id), new SqlParameter("@address_id", address_id), new SqlParameter("@amount", amount), new SqlParameter("@delivery_date_scheduled", Common.Double2DateTime(delivery_date_scheduled)), new SqlParameter("@gross_price", gross_price));
                DataRow dr = dt.Rows[0];
                return new OrderModel((int)dr["order_id"]);
            }
            else
            {
                dbo.SqlComm = "update t_order set member_id = @member_id,address_id = @address_id,amount = @amount,delivery_date_scheduled = @delivery_date_scheduled,gross_price = @gross_price where order_id = @order_id";
                dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id), new SqlParameter("@address_id", address_id), new SqlParameter("@amount", amount), new SqlParameter("@delivery_date_scheduled", Common.Double2DateTime(delivery_date_scheduled)), new SqlParameter("@gross_price", gross_price), new SqlParameter("@order_id",order_id));
                return new OrderModel(order_id);
            }
        }

        internal static OrderModel PaymentRequest(int order_id, int member_id, bool status)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_order where order_id = @order_id and member_id = @member_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@order_id", order_id),new SqlParameter("@member_id",member_id));
            if (dt.Rows.Count == 0)
                throw new ArgumentException("order_id或member_id错误");
            dbo.SqlComm = "update t_order set status = @status where order_id = @order_id";
            dbo.ExecuteNonQuery(new SqlParameter("@order_id", order_id), new SqlParameter("@status", status));
            return new OrderModel(order_id);
        }


        internal static Orders GetAllOrders(int member_id)
        {
            Orders orders = new Orders();
            orders.myorders = OrderModel.GetAllOrder(member_id);
            return orders;
        }

        private static List<OrderModel> GetAllOrder(int member_id)
        {
            List<OrderModel> orders = new List<OrderModel>();
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_order where member_id = @member_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OrderModel order = new OrderModel();
                    order.order_id = (int)dr["order_id"];
                    order.member = new MemberModel((int)dr["member_id"]);
                    order.address = new AddressModel((int)dr["address_id"]);
                    order.amount = (int)dr["amount"];
                    order.delivery_date_scheduled = Common.DateTime2Double((DateTime)dr["delivery_date_scheduled"]);
                    if (!string.IsNullOrEmpty(dr["delivery_date_actual"].ToString()))
                        order.delivery_date_actual = Common.DateTime2Double((DateTime)dr["delivery_date_actual"]);
                    order.gross_price = Convert.ToDouble(dr["gross_price"]);
                    if (!string.IsNullOrEmpty(dr["applied_code_id"].ToString()))
                        order.applied_code_id = (int)dr["applied_code_id"];
                    order.status = (bool)dr["status"];
                    order.disabled = (bool)dr["disabled"];
                    orders.Add(order);
                }
                return orders;
            }
            return orders;
        }


        internal static OrderModel DisabledOrders(int member_id, int order_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_order where member_id = @member_id and order_id = @order_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id), new SqlParameter("@order_id", order_id));
            if (dt.Rows.Count > 0)
            {
                dbo.SqlComm = "update t_order set disabled = 1 where member_id = @member_id and order_id = @order_id";
                dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id), new SqlParameter("@order_id", order_id));
                return new OrderModel(order_id);
            }
            throw new ArgumentNullException("member_id或order_id错误");
        }
    }

}