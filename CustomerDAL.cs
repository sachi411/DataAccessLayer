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
    
    public class CustomerDAL
    {
        SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDALDB"].ToString());
        public int AddCustomerDetails(Customer objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddCusDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                cmd.Parameters.AddWithValue("@first_name", objBO.First_Name);
                cmd.Parameters.AddWithValue("@middle_name", objBO.Middle_Name);
                cmd.Parameters.AddWithValue("@last_name", objBO.Last_Name);
                cmd.Parameters.AddWithValue("@address", objBO.Address);
                cmd.Parameters.AddWithValue("@email", objBO.Email);
                cmd.Parameters.AddWithValue("@phone", objBO.Phone);
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
                return 0;
            }
        }
        public int DeleteCustomerDetails(Customer objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCusDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Customer ID does not exists");
                }
                return res;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateCustomerFirstName(Customer objBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCusFirstName", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                cmd.Parameters.AddWithValue("@first_name", objBO.First_Name);
                scon.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                scon.Close();
                if (res == 0)
                {
                    throw new Exception("Customer ID does not exists");
                }
                return res;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateCustomerMiddleName(Customer objBO)
        {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateCusMiddleName", scon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                    cmd.Parameters.AddWithValue("@middle_name", objBO.Middle_Name);
                    scon.Open();
                    int res = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    scon.Close();
                    if (res == 0)
                    {
                    throw new Exception("Customer ID does not exists");
                    }
                return res;
                }
                catch
                {
                return 0;
                }
        }
        public int UpdateCustomerLastName(Customer objBO)
        {
                    try 
                    { 
                         SqlCommand cmd = new SqlCommand("sp_UpdateCusLastName", scon);
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                         cmd.Parameters.AddWithValue("@last_name", objBO.Last_Name);
                         scon.Open();
                         int res = cmd.ExecuteNonQuery();
                         cmd.Dispose();
                         scon.Close();
                         if (res == 0)
                         {
                            throw new Exception("Customer ID does not exists");
                         }
                         return res;
                    }
                    catch
                     {
                     return 0;
                     }
        }
        public int UpdateCustomerPhone(Customer objBO)
        {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("sp_UpdateCusPhone", scon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                            cmd.Parameters.AddWithValue("@phone", objBO.Phone);
                            scon.Open();
                            int res = cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            scon.Close();
                            if (res == 0)
                            {
                               throw new Exception("Customer ID does not exists");
                            }
                        return res;
                        }
                        catch
                        {
                        return 0;
                        }
        }
        public int UpdateCustomerAddress(Customer objBO)
        {
                            try
                            {
                                SqlCommand cmd = new SqlCommand("sp_UpdateCusAddress", scon);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                                cmd.Parameters.AddWithValue("@address", objBO.Address);
                                scon.Open();
                                int res = cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                scon.Close();
                                 if (res == 0)
                                 {
                                    throw new Exception("Customer ID does not exists");
                                 }
                             return res;
                            }
                             catch
                            {
                             return 0;
                            }


        }
        public int UpdateCustomerEmail(Customer objBO)
        {
                                try
                                {
                                    SqlCommand cmd = new SqlCommand("sp_UpdateCusEmail", scon);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
                                    cmd.Parameters.AddWithValue("@email", objBO.Email);
                                    scon.Open();
                                    int res = cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                    scon.Close();
                                return res;
                                }
                                catch
                                {
                                 return 0;
                                }



        }
        public DataSet ShowCustomerDetails()
        {
                SqlCommand cmd = new SqlCommand("sp_ShowCusDetails", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                scon.Open();
                DataSet dsDept = new DataSet();
                SqlDataAdapter daDept = new SqlDataAdapter(cmd);
                daDept.Fill(dsDept);
                cmd.Dispose();
                scon.Close();
            return dsDept;

        }
        public DataSet ShowSpecificCustomerDetailsByID(Customer objBO)
        {
            SqlCommand cmd = new SqlCommand("sp_ShowSpecificCusByID", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customer_id", objBO.Customer_ID);
            scon.Open();
            DataSet dsDept = new DataSet();
            SqlDataAdapter daDept = new SqlDataAdapter(cmd);
            daDept.Fill(dsDept);
            cmd.Dispose();
            scon.Close();
            return dsDept;

        }
        public DataSet ShowSpecificCustomerDetailsByPhone(Customer objBO)
        {
            SqlCommand cmd = new SqlCommand("sp_ShowSpecificCusByPhone", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@phone", objBO.Phone);
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
