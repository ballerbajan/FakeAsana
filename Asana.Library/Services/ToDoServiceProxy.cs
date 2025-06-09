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
        public List<Project> projects { get; set; } = new List<Project>();
        // this would be changed via a function that sets the current project so it is private
        // why have an int for curr proje why not just a reference to the project?
      
        private Project? currentProject;

        public Project? CurrentProject
        {
            get
            {
                // if current proj is not set, return the first project
                return currentProject ?? projects.FirstOrDefault();
            }
            private set
            {
                currentProject = value;
            }
        }

        private static ToDoServiceProxy? instance;

        private ToDoServiceProxy()
        {
            if (instance == null)
            {
                var firstProj = new Project { Name = "Default", Description = "Default", Id = nextProjectKey };
                projects.Add(firstProj);
                currentProject = firstProj;
            }
        }

        private int nextProjectKey
        {
            // everytime this int is fetched the code inside of it runs
            get
            {
                if (projects.Any())
                {
                    return projects.Select(p => p.Id).Max() + 1;
                }
                return 1;
            } 
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

        public void ChangeCurrentProject(int projectId)
        {
            var project = projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                CurrentProject = project;
            }
            else if (projectId == 0)
            {
                // if projectId is 0, switch to the first project
                CurrentProject = projects[0];
            }
            else
            {
                throw new ArgumentException("Project not found");
            }
        }

        public void AddProj(Project n)
        {
            n.Id = nextProjectKey;
            projects.Add(n);
        }
    }
}