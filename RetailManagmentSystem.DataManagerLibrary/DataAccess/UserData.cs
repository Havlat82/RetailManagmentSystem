using RetailManagmentSystem.DataManagerLibrary.Internal.DataAccess;
using RetailManagmentSystem.DataManagerLibrary.Models;
using System.Collections.Generic;

namespace RetailManagmentSystem.DataManagerLibrary.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            var p = new { Id = id };
            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "RetailManagmentSystem.Data");
            return output;
        }
    }
}
