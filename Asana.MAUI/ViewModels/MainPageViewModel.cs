using Asana.Library.Models;
using Asana.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Asana.MAUI.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ToDoServiceProxy _toDoSvc;

        public MainPageViewModel()
        {
            _toDoSvc = ToDoServiceProxy.Current;
        }

        public int SelectedToDoId => SelectedToDo.Model?.Id ?? 0;
        public ToDoDetailViewModel SelectedToDo { get; set; }

        // obserable collections are unique to maui
        public ObservableCollection<ToDoDetailViewModel> ToDos
        {
            get
            {
                var todos = _toDoSvc.CurrentProject.ToDos.Select(t => new ToDoDetailViewModel(t));
                if (!IsShowCompleted)
                {
                    // filter out completed todos
                    todos = todos.Where(t => !t?.Model?.IsCompleted ?? false);
                }
                return new ObservableCollection<ToDoDetailViewModel>(todos);
                //return new ObservableCollection<ToDo>(_toDoSvc.CurrentProject.ToDos);

            }
        }

        public bool isShowCompleted;
        public bool IsShowCompleted {
            get
            {
                return isShowCompleted;
            }
            set
            {
                if (isShowCompleted != value)
                {
                    isShowCompleted = value;
                    NotifyPropertyChanged(nameof(ToDos));
                }
                
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshPage()
        {
            NotifyPropertyChanged(nameof(ToDos));
        }

        public void DeleteToDo()
        {
            if (SelectedToDo == null)
            {
                return;
            }
            _toDoSvc.CurrentProject.Remove(SelectedToDo.Model);
            NotifyPropertyChanged(nameof(ToDos));
        }
    }
}
