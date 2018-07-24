/*****************************************************************************
* Written by Adithya Ganapathy(axg172330) at The University of Texas at Dallas for 
* CS 6360 Database Design starting October 23, 2017.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
     /**************************************************************************
     * Class that performs the role of an entity.Object of this class is passed
     * as a parameter to the business layer and data layer of the application.
     **************************************************************************/
    class Contact_ManagerEntity
    {
        public int ID
        {
            get;set;
        }
        public string First_Name
        {
            get;set;
        }
        public string Last_Name
        {
            get;set;
        }
        public string Minit
        {
            get;set;
        }
        public string dateofbirth
        {
            get;set;
        }
        public string number
        {
            get; set;
        }
        public string emailid
        {
            get; set;
        }
        public string occupation
        {
            get; set;
        }
        public string gender
        {
            get; set;
        }
        public string street
        {
            get; set;
        }
        public string city
        {
            get;set;
        }
        public string state
        {
            get;set;
        }
        public string zipcode
        {
            get;set;
        }
        public string country
        {
            get;set;
        }
    }
}
