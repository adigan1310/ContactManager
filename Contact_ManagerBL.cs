/*****************************************************************************
* Written by Adithya Ganapathy(axg172330) at The University of Texas at Dallas for 
* CS 6360 Database Design starting October 23, 2017.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ContactManager
{
    class Contact_ManagerBL
    {
        /**************************************************************************
        * Initializes object for data layer class.
        **************************************************************************/
        Contact_ManagerDL dL = new Contact_ManagerDL();

        /**************************************************************************
        * Function that returns gender list data.
        **************************************************************************/
        public List<string> getGenderItems()
        {
            return dL.getGenderItems();
        }

        /**************************************************************************
        * Function that returns the records present in the database.
        **************************************************************************/
        public DataSet getData()
        {
            return dL.getData();
        }

        /**************************************************************************
        * Function that calls insertion function in the database layer.
        **************************************************************************/
        public void addData(Contact_ManagerEntity entity)
        {
            dL.addData(entity);            
        }

        /**************************************************************************
        * Function that returns the ID of a record.
        **************************************************************************/
        public int getID(Contact_ManagerEntity entity)
        {
            return dL.getID(entity);
        }

        /**************************************************************************
        * Function that calls update function in the database layer.
        **************************************************************************/
        public void saveData(Contact_ManagerEntity entity)
        {
            dL.saveData(entity);
        }

        /**************************************************************************
        * Function that calls delete function in the database layer.
        **************************************************************************/
        public void deleteData(Contact_ManagerEntity entity)
        {
            dL.deleteData(entity);
        }

        /**************************************************************************
        * Function that returns the data validation result of fields.
        **************************************************************************/
        public string DataValidation(Contact_ManagerEntity entity)
        {
            return dL.DataValidation(entity);
        }

        /**************************************************************************
        * Function that returns the empty validation result of fields.
        **************************************************************************/
        public List<int> EmptyValidation(Contact_ManagerEntity entity)
        {
            return dL.EmptyValidation(entity);
        }

        /**************************************************************************
        * Function that calls the search function in the databse layer.
        **************************************************************************/
        public DataSet SearchData(Contact_ManagerEntity entity)
        {
            return dL.SearchData(entity);
        }

        /**************************************************************************
        * Function that calls data Validation function in the database layer.
        **************************************************************************/
        public bool DataPresentValidation(Contact_ManagerEntity entity)
        {
            return dL.DataPresentValidation(entity);
        }

        /**************************************************************************
        * Function that calls Injection Validation function in the database layer.
        **************************************************************************/
        public string InjectionValidation(Contact_ManagerEntity entity)
        {
            return dL.InjectionValidation(entity);
        }
    }

}
