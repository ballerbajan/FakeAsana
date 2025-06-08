using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var projects = new List<Project>();
            var currentProject = 0;
            // var is like var is js and auto in c
            //var toDos = new List<ToDo>();
            int choiceInt;
            var itemCount = 0;
            var projItemCount = 0;
            
            var firstProj = new Project { Name = "Default", Description = "Default", Id = ++projItemCount};

            

            projects.Add(firstProj);

            do
            {
                Console.WriteLine($"\nCurrent Project:\n{projects[currentProject].Name}");
                Console.WriteLine("Choose a new menu option");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDos");
                Console.WriteLine("5. List all Outstanding ToDos");
                Console.WriteLine("6. Create a Project");
                Console.WriteLine("7. Delete a Project");
                Console.WriteLine("8. Update a Project");
                Console.WriteLine("9. List all Projects");
                Console.WriteLine("10. Change Current Project");
                Console.WriteLine("11. List all ToDos in a given Project");
                Console.WriteLine("12. Exit");


                // we read the whole line
                var choice = Console.ReadLine() ?? "12";
                
                // then we try to parse it, choice stores the string, choice int outputs if we are gucci
                if (int.TryParse(choice, out choiceInt))
                {

                    switch (choiceInt)
                    {
                        case 1:
                            // create todo for current project
                            var toDo = new ToDo();
                            Console.Write("Name: ");
                            toDo.Name = Console.ReadLine();
                            Console.Write("Description: ");
                            toDo.Description = Console.ReadLine();
                            toDo.IsCompleted = false;
                            toDo.Id = ++itemCount;
                            projects[currentProject].Add(toDo);

                            

                            break;
                        case 2:
                            // delete todo
                            projects[currentProject].PrintToDos();
                            Console.WriteLine("ToDo to Delete: ");
                            // gets the id to delete
                            var toDoChoice = int.Parse(Console.ReadLine() ?? "0");

                            projects[currentProject].Remove(toDoChoice);

                            break;
                        case 3:
                            // update todo
                            projects[currentProject].PrintToDos();
                            Console.WriteLine("ToDo to Update: ");
                            var toDoChoiceUpdate = int.Parse(Console.ReadLine() ?? "0");

                            projects[currentProject].Update(toDoChoiceUpdate);
                            
                            break;
                        case 4:
                            // print ALL todos

                            //foreach (var toDo in toDos)
                            //{
                            //    Console.WriteLine(toDo);
                            //}
                            // cant modify this list during foreach loop since during the loop it
                            // already has its bounds set, so chainging the number of things in the
                            // list will throw an exception
                
                            // passes every item from the list to console.writeline
                            //toDos.ForEach(Console.WriteLine);
                            // longer version of same thing
                            // not needed since there is only one thing (element in list) to pass
                            //toDos.ForEach(t=>Console.WriteLine(t));

                            //projects[currentProject].PrintToDos();
                            projects.ForEach(p=>p.PrintToDos());
                            break;
                        case 5:
                            // list outstanding
                           
                            Console.WriteLine($"Completed in Current Project {projects[currentProject].Name}: {projects[currentProject].CompletePercent}%");
                            projects[currentProject].ListOuttandingTodos();

                            break;
                        case 6:
                            // create a project
                            var proj = new Project();
                            Console.Write("Name: ");
                            proj.Name = Console.ReadLine();
                            Console.Write("Description: ");
                            proj.Description = Console.ReadLine();
                            proj.Id = ++projItemCount;

                            projects.Add(proj);
                            break;
                        case 7:
                            // delete a project
                            projects.ForEach(Console.WriteLine);

                            Console.WriteLine("Project to Delete: ");
                            var projDelChoice = int.Parse(Console.ReadLine() ?? "0");

                            var reference = projects.FirstOrDefault(t => t.Id == projDelChoice);
                            if (reference != null)
                            {
                                projects.Remove(reference);
                                currentProject = 0;
                            
                            }
                           
                            break;
                        case 8:
                            // update a project

                            projects.ForEach(Console.WriteLine);

                            Console.WriteLine("Project to Update: ");
                            var projUpChoice = int.Parse(Console.ReadLine() ?? "0");

                            var referenceUpdate = projects.FirstOrDefault(t => t.Id == projUpChoice);

                            if (referenceUpdate != null)
                            {
                                Console.Write("Name: ");
                                referenceUpdate.Name = Console.ReadLine();
                                Console.Write("Description: ");
                                referenceUpdate.Description = Console.ReadLine();
                            }                 
                            break;
                        case 9:
                            // list ALL projects
                            projects.ForEach(Console.WriteLine);
                            break;
                        case 10:
                            // switch projects
                            projects.ForEach(Console.WriteLine);
                            Console.WriteLine("Project to Swap to: ");

                            var projSwapChoice = int.Parse(Console.ReadLine() ?? "0");

                            var referenceSwap = projects.FirstOrDefault(t => t.Id == projSwapChoice);

                            if (referenceSwap != null)
                            {
                                currentProject = projects.IndexOf(referenceSwap);
                            }

                            break;
                        case 11:
                            // list all todos in given project
                            projects[currentProject].PrintToDos();
                            break;
                        case 12:
                            // exit
                            Console.WriteLine("exiting");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine($"err {choice} is not valid");
                }
                //if (toDos.Any()) // if there is anything in the list then run
                //{
                //    // automatically calls tostring here so overload works
                //    Console.WriteLine(toDos.Last());
                //}
            }while (choiceInt!=12);
        }
    }
}