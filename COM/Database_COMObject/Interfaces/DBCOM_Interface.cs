using System;
using System.Runtime.InteropServices;

namespace Database_COMObject.Interfaces
{
    [Guid("694C1820-04B6-4988-928F-FD858B95C880")]
    public interface DBCOM_Interface
    {
        [DispId(1)]
        void Init(string userID, string password);
        [DispId(2)]
        bool ExecuteSelectCommand(string selCommand);
        [DispId(3)]
        bool NextRow();
        [DispId(4)]
        void ExecuteNonSelectCommand(string insCommand);
        [DispId(5)]
        string GetColumnData(int pos);
    }
}
