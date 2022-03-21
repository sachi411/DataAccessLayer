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
    public class OrderLineDAL
    {
        SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDALDB"].ToString());
        public int AddOrderLineDetails(OrderLine objBO)
        {
            try
            {
            SqlCommand cmd = new SqlCommand("sp_AddOrdLineDetails", scon);
            //SqlCommand cmd1 = new SqlCommand("sp_UpdateOrdLineAmountDetails", scon);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
            cmd.Parameters.AddWithValue("@order_id", objBO.Order_ID);
            cmd.Parameters.AddWithValue("@selling_price", objBO.Selling_Price);
            cmd.Parameters.AddWithValue("@quantity_ordered", objBO.Quantity_ordered);
            cmd.Parameters.AddWithValue("@amount", objBO.Amount);
            scon.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Dispose();
            scon.Close();
            if (res == 0)
            {
                throw new Exception("Product ID already exists");
            }
            return res;
        }
            catch
            {
                return 0;
            }
        }
        public DataSet ShowOrderLineDetails()
        {
            SqlCommand cmd = new SqlCommand("sp_ShowOrdLineDetails", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            scon.Open();
            DataSet dsDept = new DataSet();
            SqlDataAdapter daDept = new SqlDataAdapter(cmd);
            daDept.Fill(dsDept);
            cmd.Dispose();
            scon.Close();
            return dsDept;

        }

        public DataSet ShowOrderLineDetailsbyid(OrderLine om)
        {
            SqlCommand cmd = new SqlCommand("sp_ShowOrdLineDetailsbyid", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order_id", om.Order_ID);
            scon.Open();
            DataSet dsDept = new DataSet();
            SqlDataAdapter daDept = new SqlDataAdapter(cmd);
            daDept.Fill(dsDept);
            cmd.Dispose();
            scon.Close();
            return dsDept;

        }
        public int UpdateProductQuan_in_hand(OrderLine obj)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateProQuantityAfterOrderLine", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order_id", obj.Order_ID);
            cmd.Parameters.AddWithValue("@product_id", obj.Product_ID);

            cmd.Parameters.AddWithValue("@quantity_ordered", obj.Quantity_ordered);
            scon.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Dispose();
            scon.Close();
            return res;
        }
    }
}
