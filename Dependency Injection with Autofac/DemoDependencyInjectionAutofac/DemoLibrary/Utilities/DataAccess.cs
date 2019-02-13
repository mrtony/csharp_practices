using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        public void LoadData()
        {
            Console.WriteLine($"Load data from database");
        }

        public void SaveData(string data)
        {
            Console.WriteLine($"Save {data} into database");
        }
    }
}
