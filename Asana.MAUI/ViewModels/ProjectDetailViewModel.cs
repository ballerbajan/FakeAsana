using Asana.Library.Models;
using Asana.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.MAUI.ViewModels
{
    public class ProjectDetailViewModel
    {
        public Project? Model { get; set; }

        public ProjectDetailViewModel()
        {
            Model = new Project();
        }

        public ProjectDetailViewModel(int id)
        {
            Model = ToDoServiceProxy.Current.Projects.FirstOrDefault(p => p.Id == id) ?? new Project();
        }

        public ProjectDetailViewModel(Project? model)
        {
            Model = model ?? new Project();
        }

        public void AddOrUpdateProject()
        {
            ToDoServiceProxy.Current.AddOrUpdateProject(Model);
        }
    }
}
