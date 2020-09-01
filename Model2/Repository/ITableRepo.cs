using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models2 {
    public interface ITableRepo {
        bool CreateTable();
        bool DropTable();
        DataTable SelectAll();
        DataTable SelectById(int id);
        DataTable Search(string search);
        bool Delete(int id);
    }
}
