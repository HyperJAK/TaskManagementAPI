using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassFormWithDb.Classes
{
    public class Category
    {
        public int Category_id { get; set; }
        public String Name { get; set; }

        public Category() { }

        public Category(string name)
        {
            this.Name=name;
        }

        public Category(int id, string name)
        {
            this.Category_id = id;
            this.Name=name;
        }
    }
}
