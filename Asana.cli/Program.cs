using Asana.Library.Models;
using Asana.Library.Services;
using System;

//using namespace Asana.Library.Services;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int choiceInt;

            var service = ToDoServiceProxy.Current;
            

            do
            {
                Console.WriteLine($"\nCurrent Project:\n{service.CurrentProject}");
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
                            service.CurrentProject?.AddOrUpdate(toDo);

                            break;
                        case 2:
                            // delete todo
                            service.CurrentProject.PrintToDos();
                            Console.WriteLine("ToDo to Delete: ");
                            // gets the id to delete
                            var toDoChoice = int.Parse(Console.ReadLine() ?? "0");

                            var referenceDelete = service.CurrentProject.GetById(toDoChoice);
                            if (referenceDelete != null)
                            {
                                service.CurrentProject.Remove(referenceDelete);

                            }
           
                            break;
                        case 3:
                            // update todo
                            service.CurrentProject.PrintToDos();

                            Console.WriteLine("ToDo to Update: ");
                            var toDoChoiceUpdate = int.Parse(Console.ReadLine() ?? "0");

                            var referenceUpdate = service.CurrentProject.GetById(toDoChoiceUpdate);

                            if (referenceUpdate != null)
                            {
                                Console.Write("Name: ");
                                referenceUpdate.Name = Console.ReadLine();
                                Console.Write("Description: ");
                                referenceUpdate.Description = Console.ReadLine();
                            }

                            service.CurrentProject.AddOrUpdate(referenceUpdate);
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


                            // can be made into a single call to a print function within the service
                            foreach (var p in service.Projects)
                            {
                                p.PrintToDos();
                            }
                            break;
                        case 5:
                            // list outstanding

                            Console.WriteLine($"Completed in Current Project {service.CurrentProject.Name}: {service.CurrentProject.CompletePercent}%");
                            service.CurrentProject.ListOuttandingTodos();

                            break;
                        case 6:
                            // create a project
                            var proj = new Project();
                            Console.Write("Name: ");
                            proj.Name = Console.ReadLine();
                            Console.Write("Description: ");
                            proj.Description = Console.ReadLine();
                            
                            service.AddProj(proj);
                            break;
                        case 7:
                            // delete a project

                            service.Projects.ForEach(Console.WriteLine);

                            Console.WriteLine("Project to Delete: ");
                            var projDelChoice = int.Parse(Console.ReadLine() ?? "0");

                            var reference = service.Projects.FirstOrDefault(t => t.Id == projDelChoice);
                            if (reference != null)
                            {
                                service.Projects.Remove(reference);
                                service.ChangeCurrentProject(0); // switch first project in list, defaulted value
                            }

                            break;
                        case 8:
                            // update a project

                            service.Projects.ForEach(Console.WriteLine);
                         

                            Console.WriteLine("Project to Update: ");
                            var projUpChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectToUpdate = service.Projects.FirstOrDefault(t => t.Id == projUpChoice);

                            if (projectToUpdate != null)
                            {
                                Console.Write("Name: ");
                                projectToUpdate.Name = Console.ReadLine();
                                Console.Write("Description: ");
                                projectToUpdate.Description = Console.ReadLine();
                            }
                            break;
                        case 9:
                            // list ALL projects

                            service.Projects.ForEach(Console.WriteLine);
                            break;
                        case 10:
                            // switch projects

                            service.Projects.ForEach(Console.WriteLine);
                            Console.WriteLine("Project to Swap to: ");

                            var projSwapChoice = int.Parse(Console.ReadLine() ?? "0");

                            var referenceSwap = service.Projects.FirstOrDefault(t => t.Id == projSwapChoice);

                            if (referenceSwap != null)
                            {
                                service.ChangeCurrentProject(projSwapChoice);
                            }

                            break;
                        case 11:
                            // list all todos in given project
                            service.CurrentProject?.PrintToDos();
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
    
            }while (choiceInt!=12);
        }
    }
}