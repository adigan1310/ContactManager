/******************************************************************************
* Contact Manager
* 
* This program performs the operations of a contact manager. You can create 
* new contact, update any detail of a contact and also you can delete a contact.
* It also allows you to search a particular contact and displays it in a list.
* 
* The program automatically assigns an unique ID for every contact created and 
* it will be stored in the database. There are several tables interlinked together
* and they are identified through this unique ID. The program also checks whether
* a record is already available in the database or not and if not available then inserts it.
* 
* The mandatory fields for creating a contact will be highlighted in Red and it 
* also does the validation for each field before entering into the database.
* 
* The program allows the user to search a contact by street,city,state,zipcode and 
* country but the data that is displayed for the adress would be the concatenated value 
* of all the columns.
* 
* The program will also does a validation for entering the date of birth for a contact. 
* the minimal birth year that can be entered is 1900 and the maximum birth date that can
* be entered is the current date.
*
* Written by Adithya Ganapathy(axg172330) at The University of Texas at Dallas for 
* CS 6360 Database Design starting October 23, 2017.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ContactManager
{
    public partial class Contact_Manager : Form
    {
        /**************************************************************************
        * Initializes object for entity and business layer class.
        **************************************************************************/
        Contact_ManagerBL bL = new Contact_ManagerBL();
        Contact_ManagerEntity entity = new Contact_ManagerEntity();

        /**************************************************************************
        * Initializes the Components and loads the current date for Date Time Picker
        **************************************************************************/
        public Contact_Manager()
        {
            InitializeComponent();
            Datetime.Value = DateTime.Now;
            Gendertext.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /**************************************************************************
        * Once the component is loaded called the function to load the data
        * and header.
        **************************************************************************/
        private void Contact_Manager_Load(object sender, EventArgs e)
        {
            Gendertext.DataSource = bL.getGenderItems();
            Load_Data();
            Load_Header();
        }

        /**************************************************************************
        * Loads the header columns for the DataView 
        **************************************************************************/
        public void Load_Header()
        {
            DataView.Columns[0].HeaderText = ConfigurationManager.ConnectionStrings["FName"].ConnectionString.ToString();
            DataView.Columns[1].HeaderText = ConfigurationManager.ConnectionStrings["MI"].ConnectionString.ToString();
            DataView.Columns[1].Width = 40;
            DataView.Columns[2].HeaderText = ConfigurationManager.ConnectionStrings["LName"].ConnectionString.ToString();
            DataView.Columns[3].HeaderText = ConfigurationManager.ConnectionStrings["DOB"].ConnectionString.ToString();
            DataView.Columns[4].HeaderText = ConfigurationManager.ConnectionStrings["Gender"].ConnectionString.ToString();
            DataView.Columns[5].HeaderText = ConfigurationManager.ConnectionStrings["Addr"].ConnectionString.ToString();
            DataView.Columns[6].HeaderText = ConfigurationManager.ConnectionStrings["PNum"].ConnectionString.ToString();
            DataView.Columns[7].HeaderText = ConfigurationManager.ConnectionStrings["Email"].ConnectionString.ToString();
            DataView.Columns[8].HeaderText = ConfigurationManager.ConnectionStrings["Occ"].ConnectionString.ToString();
        }

        /**************************************************************************
        * Loads all the data present in contact manager database to the DataView
        **************************************************************************/
        public void Load_Data()
        {
            DataView.DataSource = bL.getData().Tables[0].DefaultView;
            DataView.AllowUserToAddRows = false;
            Status.Text = "Status : " + DataView.Rows.Count.ToString() + " rows displayed";
        }

        /**************************************************************************
        * Loads the records that is searched by the user to the DataView
        **************************************************************************/
        public void LoadSearch_Data()
        {
            DataView.DataSource = bL.SearchData(entity).Tables[0].DefaultView;
            if(DataView.Rows.Count == 0)
            {
                MessageBox.Show("No Records Found...","Search Result");
                Load_Data();
            }
            else
            {
                DataView.AllowUserToAddRows = false;
                Status.Text = "Status : " + DataView.Rows.Count.ToString() + " rows displayed";
            }
            
        }

        /**************************************************************************
        * Gets all the details from the UI. Checks mandatory fields entry and also 
        * validates the entered data and inserts the new contact into the database.
        * If any entry is missed or data is invalid, a message is popped up to inform
        * the user to correct or enter it.
        **************************************************************************/
        private void Add_Click(object sender, EventArgs e)
        {
            string output;List<int> result;
            entity.First_Name = Fnametext.Text;
            entity.First_Name = entity.First_Name.Replace("'", "''");
            entity.Last_Name = Lastnametext.Text;
            entity.Last_Name = entity.Last_Name.Replace("'", "''");
            entity.Minit = MItext.Text;
            entity.dateofbirth = Datetime.Text;
            entity.gender = Gendertext.Text;
            entity.street = Streettext.Text.ToString().Replace(',', ' ');
            entity.city = CityText.Text;
            entity.state = Statetext.Text;
            entity.zipcode = Ziptext.Text;
            entity.country = Countrytext.Text;
            entity.emailid = Emailtext.Text;
            entity.number = Numbertext.Text;
            entity.occupation = Occupationtext.Text;
            result = bL.EmptyValidation(entity);
            if (result.All(x => x == 0))
            {
                HighlightShow(result);
                output = bL.DataValidation(entity);
                if (output == "")
                {
                    if (!bL.DataPresentValidation(entity))
                    {
                        entity.First_Name = entity.First_Name.Replace("''", "'");
                        entity.Last_Name = entity.Last_Name.Replace("''", "'");
                        bL.addData(entity);
                        Load_Data();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(ConfigurationManager.ConnectionStrings["Redundnacy"].ConnectionString.ToString(), ConfigurationManager.ConnectionStrings["InsertError"].ConnectionString.ToString());
                    }

                }
                else
                {
                    MessageBox.Show(output, ConfigurationManager.ConnectionStrings["ValidTitle"].ConnectionString.ToString());
                }
            }
            else
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["Emptypopup"].ConnectionString.ToString(), ConfigurationManager.ConnectionStrings["ErrorTitle"].ConnectionString.ToString());
                HighlightShow(result);
            }
        }

        /**************************************************************************
        * Changes the mandatoy field label to red if value is not entered and changes
        * to black when the data is entered.
        **************************************************************************/
        public void HighlightShow(List<int> result)
        {
            if (result[0] == 1)
                Gender.ForeColor = Color.Red;
            else
                Gender.ForeColor = Color.Black;
            if (result[1] == 1)
                Fname.ForeColor = Color.Red;
            else
                Fname.ForeColor = Color.Black;
            if (result[2] == 1)
                Lname.ForeColor = Color.Red;
            else
                Lname.ForeColor = Color.Black;
            if (result[3] == 1)
                Address.ForeColor = Color.Red;
            else
                Address.ForeColor = Color.Black;
            if (result[4] == 1)
                State.ForeColor = Color.Red;
            else
                State.ForeColor = Color.Black;
            if (result[5] == 1)
                City.ForeColor = Color.Red;
            else
                City.ForeColor = Color.Black;
            if (result[6] == 1)
                Zipcode.ForeColor = Color.Red;
            else
                Zipcode.ForeColor = Color.Black;
            if (result[7] == 1)
                Number.ForeColor = Color.Red;
            else
                Number.ForeColor = Color.Black;
            if (result[8] == 1)
                Email.ForeColor = Color.Red;
            else
                Email.ForeColor = Color.Black;

        }

        /**************************************************************************
        * Function to reset all the fields to blank and its default value.
        **************************************************************************/
        public void Clear()
        {
            Fnametext.Text = "";
            Lastnametext.Text = "";
            MItext.Text = "";
            Datetime.ResetText();
            Gendertext.SelectedIndex = 0;
            Streettext.Text = "";  
            Emailtext.Text = "";
            Numbertext.Text = "";
            Occupationtext.Text = "";
            Streettext.Text = "";
            CityText.Text = "";
            Statetext.Text = "";
            Ziptext.Text = "";
            Countrytext.Text = "";
            Save.Visible = false;
            Add.Visible = true;
        }

        /**************************************************************************
        * Loads the values of a row in DataView to the corresponding Textboxes.
        **************************************************************************/
        private void DataView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Fnametext.Text = DataView.Rows[e.RowIndex].Cells[0].Value.ToString();
            MItext.Text = DataView.Rows[e.RowIndex].Cells[1].Value.ToString();
            Lastnametext.Text = DataView.Rows[e.RowIndex].Cells[2].Value.ToString();
            Datetime.Value = Convert.ToDateTime(DataView.Rows[e.RowIndex].Cells[3].Value);
            Gendertext.Text = DataView.Rows[e.RowIndex].Cells[4].Value.ToString();
            string[] words;
            words = DataView.Rows[e.RowIndex].Cells[5].Value.ToString().Split(',');
            Streettext.Text = words[0];
            CityText.Text = words[1];
            Statetext.Text = words[2];
            Ziptext.Text = words[3];
            if (words.Length == 5)
                Countrytext.Text = words[4];
            Numbertext.Text = DataView.Rows[e.RowIndex].Cells[6].Value.ToString();
            Emailtext.Text = DataView.Rows[e.RowIndex].Cells[7].Value.ToString();
            Occupationtext.Text = DataView.Rows[e.RowIndex].Cells[8].Value.ToString();
            getRecordID(e);
            Save.Visible = true;
            Add.Visible = false;
        }

        /**************************************************************************
        * Obtains the ID of a record
        **************************************************************************/
        public void getRecordID(DataGridViewCellEventArgs e)
        {
            entity.First_Name = DataView.Rows[e.RowIndex].Cells[0].Value.ToString();
            entity.Last_Name = DataView.Rows[e.RowIndex].Cells[2].Value.ToString();
            entity.number = DataView.Rows[e.RowIndex].Cells[6].Value.ToString();
            entity.ID = bL.getID(entity);
        }

        /**************************************************************************
        * Clear Button click function thats calls clear function.
        **************************************************************************/
        private void ClearData_Click(object sender, EventArgs e)
        {
            Load_Data();
            Clear();
            
        }

        /**************************************************************************
        * Gets all the details from the UI. Validates the entered data and updates 
        * the modified contact into the database.
        * If any field entry is invalid, a message is popped up to inform
        * the user to correct it.
        **************************************************************************/
        private void Save_Click(object sender, EventArgs e)
        {
            string output;List<int> result;
            entity.First_Name = Fnametext.Text;
            entity.Last_Name = Lastnametext.Text;
            entity.Minit = MItext.Text;
            entity.dateofbirth = Datetime.Text;
            entity.gender = Gendertext.Text;
            entity.street = Streettext.Text;
            entity.city = CityText.Text;
            entity.state = Statetext.Text;
            entity.zipcode = Ziptext.Text;
            entity.country = Countrytext.Text;
            entity.emailid = Emailtext.Text;
            entity.number = Numbertext.Text;
            entity.occupation = Occupationtext.Text;
            result = bL.EmptyValidation(entity);
            if (result.All(x => x == 0))
            {
                HighlightShow(result);
                output = bL.DataValidation(entity);
                if (output == "")
                {
                    bL.saveData(entity);
                    Load_Data();
                    Clear();
                }
                else
                {
                    MessageBox.Show(output, ConfigurationManager.ConnectionStrings["Emptypopup"].ConnectionString.ToString());
                }
            }
            else
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["Emptypopup"].ConnectionString.ToString());
                HighlightShow(result);
            }
            
        }

        /**************************************************************************
        * Calls Function to obtain record id on single click of a cell in DataView.
        **************************************************************************/
        private void DataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getRecordID(e);
        }

        /**************************************************************************
        * Delete Button click function that deletes the selected record.
        **************************************************************************/
        private void Delete_Click(object sender, EventArgs e)
        {
            bL.deleteData(entity);
            Load_Data();
            Clear();
        }

        /**************************************************************************
        * Search Button click function thats searches for a record from the database
        * based on the values entered by the user.
        **************************************************************************/
        private void Search_Click(object sender, EventArgs e)
        {
            string output;
            entity.First_Name = Fnametext.Text;
            entity.First_Name = entity.First_Name.Replace("'", "''");
            entity.Last_Name = Lastnametext.Text;
            entity.Last_Name = entity.Last_Name.Replace("'", "''");
            entity.Minit = MItext.Text;
            entity.Minit = entity.Minit.Replace("'", "''");
            if (Datetime.Value.Date < DateTime.Now.Date)
                entity.dateofbirth = Datetime.Value.Year.ToString();
            else
                entity.dateofbirth = "";
            if (Gendertext.Text == "Select")
                entity.gender = "";
            else
                entity.gender = Gendertext.Text;
            entity.street = Streettext.Text;
            entity.street = entity.street.Replace("'", "''");
            entity.city = CityText.Text;
            entity.state = Statetext.Text;
            entity.zipcode = Ziptext.Text;
            entity.country = Countrytext.Text;
            entity.emailid = Emailtext.Text;
            entity.number = Numbertext.Text;
            entity.occupation = Occupationtext.Text;
            output = bL.InjectionValidation(entity);
            if(output == "")
            {
                LoadSearch_Data();
                Clear();
            }
            else
            {
                MessageBox.Show(output, ConfigurationManager.ConnectionStrings["Emptypopup"].ConnectionString.ToString());
            }
            
        }

    }
}
