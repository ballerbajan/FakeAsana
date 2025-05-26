using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class ToDo
    {
        //public string Name {
        //    get {
        //        return Name;
        //    }
        //    set
        //    {
        //        if (Name != value) { 
        //            Name = value;
        //        }
        //    }
        //}

        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Priority { get; set; }

        // overrides the to string function
        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }

}
