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
                if (_toDoList.Count == 0)
                    return 0;
                int total = _toDoList.Count;
                int completed = _toDoList.Count(t => t.IsCompleted == true);

                return (float)completed / total * 100;
            } 
        }

        // we will have a private backing for ToDo so that we dont have to show all todo's
        // or when we need to convert to observable it doesnt take forever
        //private List<ToDo>? _toDoList;
        private List<ToDo> _toDoList = new List<ToDo>();

        public List<ToDo> ToDos
        {
            get
            {
                return _toDoList.Take(100).ToList();
            }
            private set
            {
                if (value != _toDoList)
                {
                    _toDoList = value;
                }
            }
        }

        //public List<ToDo> ToDos { get; set; }

        // Adds a todo to internal todo list
        //public void Add(ToDo t)
        //{
        //    if (t.Id == 0)
        //        t.Id = NextKey; // sets the id to the next key
        //    _toDoList.Add(t);
        //}

        // update a todo in a project
        //public ToDo? Update(ToDo? todo)
        //{
        //    return todo;
        //}


        public ToDo? AddOrUpdate(ToDo? toDo)
        {
            if (toDo != null && toDo.Id == 0)
            {
                toDo.Id = NextKey;
                _toDoList.Add(toDo);
            }

            return toDo;
        }

        // deletes by reference
        public bool Remove(ToDo? toDo)
        {
            if (toDo == null)
            {
                return false;
            }

            _toDoList.Remove(toDo);
            return true;
        }

        // list todos in project
        public void PrintToDos()
        {
            _toDoList.ForEach(Console.WriteLine);
        }

        public ToDo? GetById(int id)
        {
            return _toDoList.FirstOrDefault(t => t.Id == id);
        }

        // list outstanding todos
        public void ListOuttandingTodos()
        {
            _toDoList.Where(t => (t != null) && !(t?.IsCompleted ?? false))
                                .ToList()
                                .ForEach(Console.WriteLine);
        }
        // string override for printing
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description}";
        }

        // automatic id generation for toDos
        private int NextKey
        {
            get
            {
                // here i can call a function within project that does exactly this, but
                // this should be doing everything the class file should only be properties?
                if (_toDoList.Any())
                {
                    return _toDoList.Select(t => t.Id).Max() + 1;
                }
                return 1;
            }
        }
    }
}
