using System.Collections.Generic;
using System;
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

        // we dont want our Id to be null cus tf does that mean
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Priority { get; set; }
        public int ProjectId { get; set; }

        // overrides the to string function
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description}";
        }
    }

}
