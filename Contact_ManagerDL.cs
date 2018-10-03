/*****************************************************************************
* Written by Adithya Ganapathy(axg172330) at The University of Texas at Dallas for 
* CS 6360 Database Design starting October 23, 2017.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ContactManager
{
    class Contact_ManagerDL
    {
        /**************************************************************************
        * String variable that stores the database connection statement.
        **************************************************************************/
        String dbconn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();

        /**************************************************************************
        * Obtain all the records in the database and returns it.
        **************************************************************************/
        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["Getdata"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    var commandbuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["DataError"].ConnectionString.ToString());
            }

            return ds;
        }

        /**************************************************************************
        * Inserts new record in the database.
        **************************************************************************/
        public void addData(Contact_ManagerEntity entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["Adddata"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstname", entity.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@lastname", entity.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@dateofbirth", entity.dateofbirth));
                    cmd.Parameters.Add(new SqlParameter("@gender", entity.gender));
                    cmd.Parameters.Add(new SqlParameter("@street", entity.street));
                    cmd.Parameters.Add(new SqlParameter("@city", entity.city));
                    cmd.Parameters.Add(new SqlParameter("@state", entity.state));
                    cmd.Parameters.Add(new SqlParameter("@zipcode", entity.zipcode));
                    cmd.Parameters.Add(new SqlParameter("@country", entity.country));
                    cmd.Parameters.Add(new SqlParameter("@number", entity.number));
                    cmd.Parameters.Add(new SqlParameter("@email", entity.emailid));
                    cmd.Parameters.Add(new SqlParameter("@occupation", entity.occupation));
                    cmd.Parameters.Add(new SqlParameter("@minit", entity.Minit));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["InsertError"].ConnectionString.ToString());
            }
        }

        /**************************************************************************
        * Returns the list items for gender dropdown.
        **************************************************************************/
        public List<string> getGenderItems()
        {
            List<string> items = new List<string>() { ConfigurationManager.ConnectionStrings["Default"].ConnectionString.ToString(), ConfigurationManager.ConnectionStrings["GM"].ConnectionString.ToString(), ConfigurationManager.ConnectionStrings["GF"].ConnectionString.ToString() };
            return items;
        }

        /**************************************************************************
        * Returns the ID of a particular record.
        **************************************************************************/
        public int getID(Contact_ManagerEntity entity)
        {
            int id;
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["ID"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstname", entity.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@lastname", entity.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@number", entity.number));
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["IDError"].ConnectionString.ToString());
                id = 0;
            }
            return id;
        }

        /**************************************************************************
        * Updates the record in the database.
        **************************************************************************/
        public void saveData(Contact_ManagerEntity entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["Save"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstname", entity.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@lastname", entity.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@dateofbirth", entity.dateofbirth));
                    cmd.Parameters.Add(new SqlParameter("@gender", entity.gender));
                    cmd.Parameters.Add(new SqlParameter("@street", entity.street));
                    cmd.Parameters.Add(new SqlParameter("@city", entity.city));
                    cmd.Parameters.Add(new SqlParameter("@state", entity.state));
                    cmd.Parameters.Add(new SqlParameter("@zipcode", entity.zipcode));
                    cmd.Parameters.Add(new SqlParameter("@country", entity.country));
                    cmd.Parameters.Add(new SqlParameter("@number", entity.number));
                    cmd.Parameters.Add(new SqlParameter("@email", entity.emailid));
                    cmd.Parameters.Add(new SqlParameter("@occupation", entity.occupation));
                    cmd.Parameters.Add(new SqlParameter("@minit", entity.Minit));
                    cmd.Parameters.Add(new SqlParameter("@ID", entity.ID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["DataUError"].ConnectionString.ToString());
            }
        }

        /**************************************************************************
        * Deletes the selected record from the database.
        **************************************************************************/
        public void deleteData(Contact_ManagerEntity entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["Delete"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", entity.ID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["DeleteError"].ConnectionString.ToString());
            }
        }

        /**************************************************************************
        * Performs the data validation for zipcode,number,email,date of birth and 
        * gender and returns string output
        **************************************************************************/
        public string DataValidation(Contact_ManagerEntity entity)
        {
            string output;
            output = InjectionValidation(entity);
            try
            {
                var addr = new System.Net.Mail.MailAddress(entity.emailid);
            }
            catch(Exception)
            {
                output = output + ConfigurationManager.ConnectionStrings["ErrorEmail"].ConnectionString.ToString() + '\n';
            }
            Regex zipreg = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            Regex phonereg = new Regex(@"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$");
            if(zipreg.IsMatch(entity.zipcode) ==  false)
                output = output + ConfigurationManager.ConnectionStrings["ErrorZip"].ConnectionString.ToString() + '\n';
            if (phonereg.IsMatch(entity.number) == false)
                output = output + ConfigurationManager.ConnectionStrings["ErrorNumber"].ConnectionString.ToString() + '\n';
            if (Convert.ToDateTime(entity.dateofbirth).Date == DateTime.Now.Date || Convert.ToDateTime(entity.dateofbirth).Date > DateTime.Now.Date)
                output = output + ConfigurationManager.ConnectionStrings["ErrorDOB"].ConnectionString.ToString() + '\n';
            if (entity.gender == "Select")
                output = output + ConfigurationManager.ConnectionStrings["ErrorGender"].ConnectionString.ToString() + '\n';
            return output;
        }

        /**************************************************************************
        * Performs the Injection validation of all fields from the component and 
        * returns output string.
        **************************************************************************/
        public string InjectionValidation(Contact_ManagerEntity entity)
        {
            string output = "";
            if (entity.First_Name.Contains(")") || entity.First_Name.Contains("%") || entity.First_Name.Contains("(") || entity.First_Name.Contains(";"))
                output = output + "Enter Valid First Name" + '\n';
            if (entity.Last_Name.Contains(")") || entity.Last_Name.Contains("%") || entity.Last_Name.Contains("(") || entity.Last_Name.Contains(";"))
                output = output + "Enter Valid Last Name" + '\n';
            if (entity.Minit.Contains("'") || entity.Minit.Contains(")") || entity.Minit.Contains("%") || entity.Minit.Contains("(") || entity.Minit.Contains(";"))
                output = output + "Enter Valid Initial" + '\n';
            if (entity.occupation.Contains("'") || entity.occupation.Contains(")") || entity.occupation.Contains("%") || entity.occupation.Contains("(") || entity.occupation.Contains(";"))
                output = output + "Enter Valid Occupation" + '\n';
            if (entity.street.Contains("'") || entity.street.Contains(")") || entity.street.Contains("%") || entity.street.Contains("(") || entity.street.Contains(";"))
                output = output + "Enter Valid Street" + '\n';
            if (entity.city.Contains("'") || entity.city.Contains(")") || entity.city.Contains("%") || entity.city.Contains("(") || entity.city.Contains(";"))
                output = output + "Enter Valid City" + '\n';
            if (entity.state.Contains("'") || entity.state.Contains(")") || entity.state.Contains("%") || entity.state.Contains("(") || entity.state.Contains(";"))
                output = output + "Enter Valid State" + '\n';
            if (entity.country.Contains("'") || entity.country.Contains(")") || entity.country.Contains("%") || entity.country.Contains("(") || entity.country.Contains(";"))
                output = output + "Enter Valid Country" + '\n';
            return output;
        }
        /**************************************************************************
        * Checks if mandatory fields are entered or not.
        **************************************************************************/
        public List<int> EmptyValidation(Contact_ManagerEntity entity)
        {
            List<int> output = new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (entity.gender == "Select")
                output[0] = 1;
            if(entity.First_Name == "")
                output[1] = 1;
            if (entity.Last_Name == "")
                output[2] = 1;
            if (entity.street == "")
                output[3] = 1;
            if (entity.state == "")
                output[4] = 1;
            if (entity.city == "")
                output[5] = 1;
            if (entity.zipcode == "")
                output[6] = 1;
            if (entity.number == "")
                output[7] = 1;
            if (entity.emailid == "")
                output[8] = 1;
            return output;
        }

        /**************************************************************************
        * Searches for records based on the user's input and returns the data
        **************************************************************************/
        public DataSet SearchData(Contact_ManagerEntity entity)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["Searchdata"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstname", entity.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@lastname", entity.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@dateofbirth", entity.dateofbirth));
                    cmd.Parameters.Add(new SqlParameter("@gender", entity.gender));
                    cmd.Parameters.Add(new SqlParameter("@street", entity.street));
                    cmd.Parameters.Add(new SqlParameter("@city", entity.city));
                    cmd.Parameters.Add(new SqlParameter("@state", entity.state));
                    cmd.Parameters.Add(new SqlParameter("@zipcode", entity.zipcode));
                    cmd.Parameters.Add(new SqlParameter("@country", entity.country));
                    cmd.Parameters.Add(new SqlParameter("@number", entity.number));
                    cmd.Parameters.Add(new SqlParameter("@email", entity.emailid));
                    cmd.Parameters.Add(new SqlParameter("@occupation", entity.occupation));
                    cmd.Parameters.Add(new SqlParameter("@minit", entity.Minit));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    var commandbuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["SearchError"].ConnectionString.ToString());
            }

            return ds;
        }

        /**************************************************************************
        * Checks if the record is already present in the database.
        **************************************************************************/
        public bool DataPresentValidation(Contact_ManagerEntity entity)
        {
            bool output = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = ConfigurationManager.ConnectionStrings["SearchID"].ConnectionString.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstname", entity.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@lastname", entity.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@dateofbirth", entity.dateofbirth));
                    cmd.Parameters.Add(new SqlParameter("@gender", entity.gender));
                    cmd.Parameters.Add(new SqlParameter("@street", entity.street));
                    cmd.Parameters.Add(new SqlParameter("@city", entity.city));
                    cmd.Parameters.Add(new SqlParameter("@state", entity.state));
                    cmd.Parameters.Add(new SqlParameter("@zipcode", entity.zipcode));
                    cmd.Parameters.Add(new SqlParameter("@country", entity.country));
                    cmd.Parameters.Add(new SqlParameter("@number", entity.number));
                    cmd.Parameters.Add(new SqlParameter("@email", entity.emailid));
                    cmd.Parameters.Add(new SqlParameter("@occupation", entity.occupation));
                    cmd.Parameters.Add(new SqlParameter("@minit", entity.Minit));
                    int res = Convert.ToInt32(cmd.ExecuteScalar());
                    if (res == 0)
                        output  = false;
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), ConfigurationManager.ConnectionStrings["InsertError"].ConnectionString.ToString());
            }
            return output;
        }
        
    }
}
