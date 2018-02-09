using Database_COMObject.Interfaces;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Database_COMObject
{
    [Guid("9E5E5FB2-219D-4ee7-AB27-E4DBED8E123E")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(DBCOM_Events))]
    public class DBCOM_Class : DBCOM_Interface
    {
        private SqlConnection connection = null;
        private SqlDataReader reader = null;

        public DBCOM_Class()
        {

        }

        public void ExecuteNonSelectCommand(string insCommand)
        {
          
        }

        public bool ExecuteSelectCommand(string selCommand)
        {
            throw new NotImplementedException();
        }

        public string GetColumnData(int pos)
        {
            throw new NotImplementedException();
        }

        public void Init(string userID, string password)
        {
            try
            {
                string myConnectString = "user id=" + userID + ";password=" + password +
                    ";Database=NorthWind;Server=SKYWALKER;Connect Timeout=30";
                connection = new SqlConnection(myConnectString);
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool NextRow()
        {
            throw new NotImplementedException();
        }
    }
}
