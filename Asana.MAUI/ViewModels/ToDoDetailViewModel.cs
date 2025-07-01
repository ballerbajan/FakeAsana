
using Asana.Library.Models;
using Asana.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Asana.MAUI.ViewModels
{
    public class ToDoDetailViewModel
    {
        public ToDo? Model { get; set; }
        public ICommand? DeleteCommand { get; set; }
        public ToDoDetailViewModel()
        {
            Model = new ToDo();
            DeleteCommand = new Command(DoDelete);

        }

        // will add or update dependding on the id
        // get the todo by id from the current project which we can then update since this is a reference

        public ToDoDetailViewModel(int id)
        {
            Model = ToDoServiceProxy.Current.CurrentProject.GetById(id) ?? new ToDo();

            DeleteCommand = new Command(DoDelete);
        }

        public ToDoDetailViewModel(ToDo? model)
        {
            Model = model ?? new ToDo();
            DeleteCommand = new Command(DoDelete);
        }

        public void DoDelete()
        {
            ToDoServiceProxy.Current.CurrentProject.Remove(Model);
        }

        public int SelectedPriority
        {
            get
            {
                return Model?.Priority ?? 4;
            }
            set
            {
                if (Model != null && Model.Priority != value)
                {
                    Model.Priority = value;
                }
            }
        }
        public List<int> Priorities {
            get
            {
                return new List<int> { 0, 1, 2, 3, 4};
            }
        }
        
        public void AddOrUpdateToDo()
        {
            ToDoServiceProxy.Current.CurrentProject.AddOrUpdate(Model);
        }
            //public string PriorityDisplay
            //{
            //    set
            //    {
            //        if(Model == null)
            //        {
            //            return;
            //        }
            //        if(!int.TryParse(value, out int p))
            //        {
            //            Model.Priority = -9999;
            //        }
            //        else
            //        {
            //            Model.Priority = p;
            //        }
            //    }
            //    get
            //    {
            //        return Model?.Priority.ToString() ?? string.Empty;
            //    }
            //}


        }
}
