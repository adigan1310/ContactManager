namespace ContactManager
{
    partial class Contact_Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact_Manager));
            this.Fname = new System.Windows.Forms.Label();
            this.Fnametext = new System.Windows.Forms.TextBox();
            this.MI = new System.Windows.Forms.Label();
            this.MItext = new System.Windows.Forms.TextBox();
            this.Lname = new System.Windows.Forms.Label();
            this.Lastnametext = new System.Windows.Forms.TextBox();
            this.Dob = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.Label();
            this.Datetime = new System.Windows.Forms.DateTimePicker();
            this.Gendertext = new System.Windows.Forms.ComboBox();
            this.Occupation = new System.Windows.Forms.Label();
            this.Occupationtext = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.Label();
            this.Streettext = new System.Windows.Forms.TextBox();
            this.Number = new System.Windows.Forms.Label();
            this.Numbertext = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.Emailtext = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.Delete = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearData = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.City = new System.Windows.Forms.Label();
            this.CityText = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.Label();
            this.Statetext = new System.Windows.Forms.TextBox();
            this.Zipcode = new System.Windows.Forms.Label();
            this.Ziptext = new System.Windows.Forms.TextBox();
            this.Country = new System.Windows.Forms.Label();
            this.Countrytext = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fname
            // 
            this.Fname.AutoSize = true;
            this.Fname.Location = new System.Drawing.Point(10, 30);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(57, 13);
            this.Fname.TabIndex = 0;
            this.Fname.Text = "First Name";
            // 
            // Fnametext
            // 
            this.Fnametext.BackColor = System.Drawing.SystemColors.Window;
            this.Fnametext.Location = new System.Drawing.Point(73, 27);
            this.Fnametext.Name = "Fnametext";
            this.Fnametext.Size = new System.Drawing.Size(100, 20);
            this.Fnametext.TabIndex = 1;
            // 
            // MI
            // 
            this.MI.AutoSize = true;
            this.MI.Location = new System.Drawing.Point(179, 30);
            this.MI.Name = "MI";
            this.MI.Size = new System.Drawing.Size(19, 13);
            this.MI.TabIndex = 2;
            this.MI.Text = "MI";
            // 
            // MItext
            // 
            this.MItext.Location = new System.Drawing.Point(205, 27);
            this.MItext.Name = "MItext";
            this.MItext.Size = new System.Drawing.Size(34, 20);
            this.MItext.TabIndex = 2;
            // 
            // Lname
            // 
            this.Lname.AutoSize = true;
            this.Lname.Location = new System.Drawing.Point(245, 30);
            this.Lname.Name = "Lname";
            this.Lname.Size = new System.Drawing.Size(58, 13);
            this.Lname.TabIndex = 4;
            this.Lname.Text = "Last Name";
            // 
            // Lastnametext
            // 
            this.Lastnametext.Location = new System.Drawing.Point(309, 27);
            this.Lastnametext.Name = "Lastnametext";
            this.Lastnametext.Size = new System.Drawing.Size(100, 20);
            this.Lastnametext.TabIndex = 3;
            // 
            // Dob
            // 
            this.Dob.AutoSize = true;
            this.Dob.Location = new System.Drawing.Point(415, 30);
            this.Dob.Name = "Dob";
            this.Dob.Size = new System.Drawing.Size(68, 13);
            this.Dob.TabIndex = 6;
            this.Dob.Text = "Date Of Birth";
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Location = new System.Drawing.Point(615, 30);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(42, 13);
            this.Gender.TabIndex = 8;
            this.Gender.Text = "Gender";
            // 
            // Datetime
            // 
            this.Datetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Datetime.Location = new System.Drawing.Point(494, 27);
            this.Datetime.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.Datetime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Datetime.Name = "Datetime";
            this.Datetime.Size = new System.Drawing.Size(115, 20);
            this.Datetime.TabIndex = 4;
            this.Datetime.Value = new System.DateTime(2017, 10, 22, 0, 0, 0, 0);
            // 
            // Gendertext
            // 
            this.Gendertext.FormattingEnabled = true;
            this.Gendertext.Location = new System.Drawing.Point(664, 26);
            this.Gendertext.Name = "Gendertext";
            this.Gendertext.Size = new System.Drawing.Size(100, 21);
            this.Gendertext.TabIndex = 5;
            // 
            // Occupation
            // 
            this.Occupation.AutoSize = true;
            this.Occupation.Location = new System.Drawing.Point(245, 71);
            this.Occupation.Name = "Occupation";
            this.Occupation.Size = new System.Drawing.Size(62, 13);
            this.Occupation.TabIndex = 9;
            this.Occupation.Text = "Occupation";
            // 
            // Occupationtext
            // 
            this.Occupationtext.Location = new System.Drawing.Point(309, 68);
            this.Occupationtext.Name = "Occupationtext";
            this.Occupationtext.Size = new System.Drawing.Size(100, 20);
            this.Occupationtext.TabIndex = 7;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(10, 113);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(35, 13);
            this.Address.TabIndex = 11;
            this.Address.Text = "Street";
            // 
            // Streettext
            // 
            this.Streettext.Location = new System.Drawing.Point(73, 110);
            this.Streettext.Name = "Streettext";
            this.Streettext.Size = new System.Drawing.Size(100, 20);
            this.Streettext.TabIndex = 9;
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(415, 71);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(78, 13);
            this.Number.TabIndex = 13;
            this.Number.Text = "Phone Number";
            // 
            // Numbertext
            // 
            this.Numbertext.Location = new System.Drawing.Point(494, 68);
            this.Numbertext.Name = "Numbertext";
            this.Numbertext.Size = new System.Drawing.Size(115, 20);
            this.Numbertext.TabIndex = 8;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(10, 71);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 14;
            this.Email.Text = "Email";
            // 
            // Emailtext
            // 
            this.Emailtext.Location = new System.Drawing.Point(73, 68);
            this.Emailtext.Name = "Emailtext";
            this.Emailtext.Size = new System.Drawing.Size(166, 20);
            this.Emailtext.TabIndex = 6;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(546, 145);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(86, 23);
            this.Add.TabIndex = 15;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // DataView
            // 
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Location = new System.Drawing.Point(25, 174);
            this.DataView.Name = "DataView";
            this.DataView.Size = new System.Drawing.Size(769, 249);
            this.DataView.TabIndex = 18;
            this.DataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellClick);
            this.DataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellContentDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(42, 17);
            this.Status.Text = "Status:";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(638, 145);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(546, 145);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(86, 23);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "Double Click a Row to Edit a Contact\r\n\r\n";
            // 
            // ClearData
            // 
            this.ClearData.Location = new System.Drawing.Point(719, 145);
            this.ClearData.Name = "ClearData";
            this.ClearData.Size = new System.Drawing.Size(75, 23);
            this.ClearData.TabIndex = 17;
            this.ClearData.Text = "Clear";
            this.ClearData.UseVisualStyleBackColor = true;
            this.ClearData.Click += new System.EventHandler(this.ClearData_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(465, 145);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 14;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(179, 113);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(24, 13);
            this.City.TabIndex = 22;
            this.City.Text = "City";
            // 
            // CityText
            // 
            this.CityText.Location = new System.Drawing.Point(212, 110);
            this.CityText.Name = "CityText";
            this.CityText.Size = new System.Drawing.Size(100, 20);
            this.CityText.TabIndex = 10;
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Location = new System.Drawing.Point(318, 113);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(32, 13);
            this.State.TabIndex = 23;
            this.State.Text = "State";
            // 
            // Statetext
            // 
            this.Statetext.Location = new System.Drawing.Point(356, 110);
            this.Statetext.Name = "Statetext";
            this.Statetext.Size = new System.Drawing.Size(100, 20);
            this.Statetext.TabIndex = 11;
            // 
            // Zipcode
            // 
            this.Zipcode.AutoSize = true;
            this.Zipcode.Location = new System.Drawing.Point(462, 113);
            this.Zipcode.Name = "Zipcode";
            this.Zipcode.Size = new System.Drawing.Size(46, 13);
            this.Zipcode.TabIndex = 24;
            this.Zipcode.Text = "Zipcode";
            // 
            // Ziptext
            // 
            this.Ziptext.Location = new System.Drawing.Point(518, 110);
            this.Ziptext.Name = "Ziptext";
            this.Ziptext.Size = new System.Drawing.Size(91, 20);
            this.Ziptext.TabIndex = 12;
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Location = new System.Drawing.Point(615, 113);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(43, 13);
            this.Country.TabIndex = 25;
            this.Country.Text = "Country";
            // 
            // Countrytext
            // 
            this.Countrytext.Location = new System.Drawing.Point(664, 110);
            this.Countrytext.Name = "Countrytext";
            this.Countrytext.Size = new System.Drawing.Size(100, 20);
            this.Countrytext.TabIndex = 13;
            // 
            // Contact_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(806, 472);
            this.Controls.Add(this.Countrytext);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.Ziptext);
            this.Controls.Add(this.Zipcode);
            this.Controls.Add(this.Statetext);
            this.Controls.Add(this.State);
            this.Controls.Add(this.CityText);
            this.Controls.Add(this.City);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.ClearData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Emailtext);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Numbertext);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.Streettext);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Occupationtext);
            this.Controls.Add(this.Occupation);
            this.Controls.Add(this.Gendertext);
            this.Controls.Add(this.Datetime);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.Dob);
            this.Controls.Add(this.Lastnametext);
            this.Controls.Add(this.Lname);
            this.Controls.Add(this.MItext);
            this.Controls.Add(this.MI);
            this.Controls.Add(this.Fnametext);
            this.Controls.Add(this.Fname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contact_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Manager";
            this.Load += new System.EventHandler(this.Contact_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Fname;
        private System.Windows.Forms.TextBox Fnametext;
        private System.Windows.Forms.Label MI;
        private System.Windows.Forms.TextBox MItext;
        private System.Windows.Forms.Label Lname;
        private System.Windows.Forms.TextBox Lastnametext;
        private System.Windows.Forms.Label Dob;
        private System.Windows.Forms.Label Gender;
        private System.Windows.Forms.DateTimePicker Datetime;
        private System.Windows.Forms.ComboBox Gendertext;
        private System.Windows.Forms.Label Occupation;
        private System.Windows.Forms.TextBox Occupationtext;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.TextBox Streettext;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.TextBox Numbertext;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox Emailtext;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClearData;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.TextBox CityText;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.TextBox Statetext;
        private System.Windows.Forms.Label Zipcode;
        private System.Windows.Forms.TextBox Ziptext;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.TextBox Countrytext;
    }
}

