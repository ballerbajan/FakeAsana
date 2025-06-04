using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float CompletePercent { 
            get 
            { 
                if (ProjectToDos.Count == 0)
                    return 0;
                int total = ProjectToDos.Count;
                int completed = ProjectToDos.Count(t => t.IsCompleted == true);

                return (float)completed / total * 100;
            } 
        }

        // need to worry about ids when things get deleted here
        // can do the reference index trick to get the index and set
        // the correct current project from that
        private List<ToDo> ProjectToDos { get; set; } = new List<ToDo>();
        
        // Adds a todo to internal todo list
        public void Add(ToDo t)
        {
            ProjectToDos.Add(t);
        }
        // takes in an interger of the id to remove from the list of todos
        public bool Remove(int idToRemove)
        {
            // first is a linq method that takes in a function as a parameter.
            // first loops through the ienum which the list is, and returns the first true
            // so the lambda here, is looking at a single object in the list
            // more specifically the id
            // first or defalut gives null if not found
            var reference = ProjectToDos.FirstOrDefault(t => t.Id == idToRemove);
            if (reference != null)
            {
                ProjectToDos.Remove(reference);
                return true;
            }
            return false;
        }
        // list todos in project
        public void PrintToDos()
        {
            ProjectToDos.ForEach(Console.WriteLine);

        }

        // update a todo in a project
        public bool Update(int idToUpdate)
        {
            var referenceUpdate = ProjectToDos.FirstOrDefault(t => t.Id == idToUpdate);

            if (referenceUpdate != null)
            {
                Console.Write("Name: ");
                referenceUpdate.Name = Console.ReadLine();
                Console.Write("Description: ");
                referenceUpdate.Description = Console.ReadLine();
                return true;
            }
            return false;
        }

        // list outstanding todos
        public void ListOuttandingTodos()
        {
            ProjectToDos.Where(t => (t != null) && !(t?.IsCompleted ?? false))
                                .ToList()
                                .ForEach(Console.WriteLine);
        }
        // string override for printing
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description}";
        }
    }
}
