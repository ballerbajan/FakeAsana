using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class Todo
    {
        public string name {
            get {
                return name;
            }
            set
            {
                if (name != value) { 
                    name = value;
                }
            }
        }
        public string description;
        public bool isDone;
        public int priority;

        public Todo()
        {
            name = "test";
        }
      

    }

}
