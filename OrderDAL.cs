using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Console;
using static System.Convert;
using System.Configuration;
using BusinessObject;



namespace DataAccessLayer
{
    public class OrderDAL
    {
        SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDALDB"].ToString());
        public int AddOrderDetails(Order objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddOrdDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@order_id", objBO.Order_ID);
                cmd.Parameters.AddWithValue("@order_date", objBO.Order_Date);
                cmd.Parameters.AddWithValue("@order_amount", objBO.Order_Amount);
                cmd.Parameters.AddWithValue("@shippment_date", objBO.Shippment_Date);
                cmd.Parameters.AddWithValue("@delivered_date", objBO.Delivered_Date);
                cmd.Parameters.AddWithValue("@order_status", objBO.Order_status);
                cmd.Parameters.AddWithValue("@paid_status", objBO.Paid_status);
                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Customer ID already exists");
                }
                return res;
            }
            catch
            {
                throw;
            }
        }
        public int UpdateOrderAmount(Order objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateOrdAmount", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@order_id", objBO.Order_ID);
                //cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Order ID already exists");
                }
                return res;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteOrderDetails(Order objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteOrdDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@order_id", objBO.Order_ID);
                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Order ID does not exists");
                }
                return res;
            }
            catch
            {
                throw;
            }
        }
        public int UpdateOrderDetailsbeforeNew(Order ordD)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStatus", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@product_id", proD.Product_ID);
                //cmd.Parameters.AddWithValue("@quantity_ordered", lin.Quantity_ordered);
                cmd.Parameters.AddWithValue("@shippment_date", ordD.Shippment_Date);
                cmd.Parameters.AddWithValue("@delivered_date", ordD.Delivered_Date);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Order ID already exists");
                }
                return res;
            }
            catch
            {
                throw;
            }

        }
        public DataSet ShowOrderDetails()
        {
            SqlCommand cmd = new SqlCommand("sp_ShowOrdDetails", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            scon.Open();
            DataSet dsDept = new DataSet();
            SqlDataAdapter daDept = new SqlDataAdapter(cmd);
            daDept.Fill(dsDept);
             
            cmd.Dispose();
            scon.Close();
            return dsDept;

        }
    }
}
