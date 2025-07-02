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
    public class ProjectsPageViewModel : INotifyPropertyChanged
    {
        private ToDoServiceProxy _service;

        public ObservableCollection<ProjectDetailViewModel> Projects
        {
            get
            {
                var projects = _service.Projects.Select(t => new ProjectDetailViewModel(t));
                return new ObservableCollection<ProjectDetailViewModel>(projects);
            }
        }
        //public List<ProjectViewModel> Projects { get; set; }


        public ProjectDetailViewModel SelectedProject { get; set; }
        public int SelectedProjectId => SelectedProject.Model?.Id ?? 0;

        public ProjectsPageViewModel()
        {
            _service = ToDoServiceProxy.Current;
            //Projects = ToDoServiceProxy.Current.Projects
            //.Select(p => new ProjectViewModel { Model = p })
            //.ToList();
        }

        public void RefreshPage()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteProject()
        {
            if (SelectedProject == null)
            {
                return;
            }
            if (_service.Projects.Count <= 1)
            {
                // Cannot delete the last project this is a bandaid solution
                return;
            }
            _service.RemoveProject(SelectedProject.Model);
            NotifyPropertyChanged(nameof(Projects));
        }

        public void SwapCurrentProject()
        {
            if (SelectedProject == null)
            {
                return;
            }
            _service.ChangeCurrentProject(SelectedProjectId);
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}
