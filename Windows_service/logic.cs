using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_service.Model;

namespace Windows_service
{
    public static class logic
    {
        public static Model1 db = new Model1();

        public static void WriteErrorLog(string message)
        {

            //creating a file to store errors
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ":" + message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                var errors = ex.ToString();


            }

        }
        public static List<Company_Profile> GetEarnerss()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM [Windowss].[dbo].[Company_Profile] where Isprocessed=0";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.CommandTimeout = 0;
            reader = sqlCmd.ExecuteReader();
            
            var accDetails = new List<Company_Profile>();
            while (reader.Read())
            {
                var accountDetails = new Company_Profile
                {
                    //ProfileID = Convert.ToInt32(reader.GetValue(0)),
                    CompanyName = reader.GetValue(1).ToString(),
                    Location = reader.GetValue(2).ToString(),
                    Email = reader.GetValue(3).ToString(),
                    website = reader.GetValue(4).ToString(),
                    Address = reader.GetValue(5).ToString(),
                    Isprocessed = false,
                };
                accDetails.Add(accountDetails);
            }
            myConnection.Close();
            return accDetails;
        }
        public static void getdetails()
        {
            var c = GetEarnerss().ToList();
            foreach (var ppc in c)
            {
                try
                {
                    Company_Profile_Approved dd = new Company_Profile_Approved();
                    //dd.ProfileID = ppc.ProfileID;
                    dd.CompanyName=ppc.CompanyName;
                    dd.Location=ppc.Location;
                    dd.Email=ppc.Email;
                    dd.Address=ppc.Address;
                    dd.website = ppc.website;
                    dd.Isprocessed = true;
                    db.Company_Profile_Approved.Add(dd);
                    db.SaveChanges();
                    
                    SqlConnection myConnection = new SqlConnection();
                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("update [Windowss].[dbo].[Company_Profile] set Isprocessed=1", myConnection);

                    if ((myConnection.State == ConnectionState.Open))
                        myConnection.Close();
                    myConnection.Open();
                    cmd.ExecuteNonQuery();

                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.ToString());
                    continue;
                }

            }
        }
        public static void validate()
        {
           
                try
                {
                   getdetails();
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.ToString());
                    
                }

            }
        }


    }

