﻿using Asana.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Services
{
    public class ToDoServiceProxy
    {
        //public List<ToDo> toDos;
        public List<Project> projects;
        // this would be changed via a function that sets the current project so it is private
        private int currentProject = 0;


        private ToDoServiceProxy()
        {
            // just a project here? or a list of projects
            //toDos = new List<ToDo>();
            projects = new List<Project>();
            var firstProj = new Project { Name = "Default", Description = "Default", Id = ++projItemCount };
            projects.Add(firstProj);
        }

        private static ToDoServiceProxy? instance;

       

        private int nextProjectKey
        {
            // everytime this int is fetched the code inside of it runs
            get
            {
                if (instance == null)
                {
                    instance
                }
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
        public void CreateToDo(ToDo toDo)
        {
            if (toDo.Id == 0)
            {
                toDo.Id = nextKey;
                toDos.Add(toDo);
            }
        }

        public void DisplayToDos(bool isShowCompleted = false)
        {
            if (isShowCompleted)
            {
                toDos.ForEach(Console.WriteLine);
            }
            else
            {
                toDos.Where(t => (t != null) && !(t?.IsCompleted ?? false))
                                .ToList()
                                .ForEach(Console.WriteLine);
            }
        }

        public void DeleteToDo()
        {
            toDos.ForEach(Console.WriteLine);
            Console.Write("ToDo to Delete: ");
            var toDoChoice = int.Parse(Console.ReadLine() ?? "0");

            var reference = toDos.FirstOrDefault(t => t.Id == toDoChoice);
            if (reference != null)
            {
                toDos.Remove(reference);
            }
        }

        public void UpdateToDo()
        {
            toDos.ForEach(Console.WriteLine);
            Console.Write("ToDo to Update: ");
            var toDoChoice = int.Parse(Console.ReadLine() ?? "0");
            var updateReference = toDos.FirstOrDefault(t => t.Id == toDoChoice);

            if (updateReference != null)
            {
                Console.Write("Name:");
                updateReference.Name = Console.ReadLine();
                Console.Write("Description:");
                updateReference.Description = Console.ReadLine();
            }

        }

    }
}