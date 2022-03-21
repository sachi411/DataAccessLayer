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
    public class ProductDAL
    {
        SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDALDB"].ToString());
        public int AddProductDetails(Product objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddProDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
                cmd.Parameters.AddWithValue("@product_name", objBO.Product_Name);
                cmd.Parameters.AddWithValue("@product_description", objBO.Product_Description);
                cmd.Parameters.AddWithValue("@listing_price", objBO.Listing_Price);
                cmd.Parameters.AddWithValue("@quantity_in_hand", objBO.Quantity_in_hand);
                cmd.Parameters.AddWithValue("@reorder_level", objBO.Reorder_Level);
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
                //return 0;
                return 0;
            }
        }
        public int DeleteProductDetails(Product objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Product ID does not exists");
                }
                return res;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteProductWithNoPreference()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProWithNoPreference", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Every product present now has preference");
                }
                return res;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateProductPrice(Product objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProPrice", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
                cmd.Parameters.AddWithValue("@listing_price", objBO.Listing_Price);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();

                if (res == 0)
                {
                    throw new Exception("Product ID does not exists");
                }
                return res;
            }

            catch
            {
                return 0;
            }
        }
        public int UpdateProductQuantity(Product objBO)
        {
            try { 
            SqlCommand cmd = new SqlCommand("sp_UpdateProQuantity", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
            cmd.Parameters.AddWithValue("@quantity_in_hand", objBO.Quantity_in_hand);
            scon.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Dispose();
            scon.Close();
                if (res == 0)
                {
                    throw new Exception("Product ID does not exists");
                }
                return res;
            }

            catch
            {
                return 0;
            }
        }
        public int UpdateProductQuan_in_hand(Product objBO,OrderLine obj)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateProQuantityAfterOrderLine", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
            cmd.Parameters.AddWithValue("@quantity_ordered", obj.Quantity_ordered);
            scon.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Dispose();
            scon.Close();
            return res;
        }
        public DataSet ShowProductDetails()
        {
            SqlCommand cmd = new SqlCommand("sp_ShowProDetails", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            scon.Open();
            DataSet dsDept = new DataSet();
            SqlDataAdapter daDept = new SqlDataAdapter(cmd);
            daDept.Fill(dsDept);
            cmd.Dispose();
            scon.Close();
            return dsDept;

        }
        public DataSet ShowSpecificProductDetailsByID(Product objBO)
        {
            SqlCommand cmd = new SqlCommand("sp_ShowSpecificProByID", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_id", objBO.Product_ID);
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
