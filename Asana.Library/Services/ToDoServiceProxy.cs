using Asana.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Services
{
    public class ToDoServiceProxy
    {
        public List<Project> Projects { get; set; }
        // this would be changed via a function that sets the current project so it is private
        // why have an int for curr proje why not just a reference to the project?
      
        private static ToDoServiceProxy? instance;

        //[TODO] can make it so that the default project cannot be deleted
        private Project? currentProject;

        public Project CurrentProject
        {
            get
            {
                if (currentProject == null)
                {
                    currentProject = Projects.FirstOrDefault();
                }
                // if current proj is not set, return the first project
                return currentProject;
            }
            private set
            {
                currentProject = value;
            }
        }

        private ToDoServiceProxy()
        {
            Projects = new List<Project>();
            var firstProj = new Project { Name = "Default", Description = "Default", Id = NextProjectKey };
            firstProj.AddOrUpdate(new ToDo { 
                Name = "First ToDo", 
                Description = "This is the first todo", 
                IsCompleted = false,
                DueDate = DateTime.Today
            });
            firstProj.AddOrUpdate(new ToDo
            {
                Name = "Second ToDo",
                Description = "This is the second todo",
                IsCompleted = true,
                DueDate = DateTime.Today


            });
            firstProj.AddOrUpdate(new ToDo
            {

                Name = "Third ToDo",
                Description = "This is the third todo",
                IsCompleted = false,
                DueDate = DateTime.Today

            });
            firstProj.AddOrUpdate(new ToDo
            {

                Name = "Fourth ToDo",
                Description = "This is the fourth todo",
                IsCompleted = true,
                DueDate = DateTime.Today
            });

            Projects.Add(firstProj);
            ChangeCurrentProject(0);
            
        }
        public static ToDoServiceProxy Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ToDoServiceProxy();
                }

                return instance;
            }
        }
        private int NextProjectKey
        {
            // everytime this int is fetched the code inside of it runs
            get
            {
                if (Projects.Any())
                {
                    return Projects.Select(p => p.Id).Max() + 1;
                }
                return 1;
            } 
        }

        public void ChangeCurrentProject(int projectId)
        {
            var project = Projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                CurrentProject = project;
            }
            else if (projectId == 0)
            {
                // if projectId is 0, switch to the first project
                CurrentProject = Projects[0];
            }
            else
            {
                throw new ArgumentException("Project not found");
            }
        }

        public Project? AddOrUpdateProject(Project? n)
        {
            if (n != null && n.Id == 0)
            {
                n.Id = NextProjectKey;
                Projects.Add(n);
            }
            return n;
        }

        public void RemoveProject(Project? n)
        {
            if (n != null && Projects.Contains(n))
            {
                Projects.Remove(n);
            }

            ChangeCurrentProject(0);
        }

        //public Project? GetProjectById(int projectId)
        //{

        //}
    }
}