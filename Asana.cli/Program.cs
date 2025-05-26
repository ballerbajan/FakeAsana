using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var is like var is js and auto in c
            var toDos = new List<ToDo>();
            int choiceInt;
            do
            {
                Console.WriteLine("Choose a new menu option");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDos");
                Console.WriteLine("5. Create a Project");
                Console.WriteLine("6. Delete a Project");
                Console.WriteLine("7. Update a Project");
                Console.WriteLine("8. List all Projects");
                Console.WriteLine("9. List all ToDos in a given Project");

                // we read the whole line
                var choice = Console.ReadLine();
                // then we try to parse it, choice stores the string, choice int outputs if we are gucci
                if (int.TryParse(choice, out choiceInt))
                {

                    switch (choiceInt)
                    {
                        case 1:
                            var toDo = new ToDo();
                            Console.Write("Name: ");
                            toDo.Name = Console.ReadLine();
                            Console.Write("Description: ");
                            toDo.Description = Console.ReadLine();
                            toDos.Add(toDo);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            Console.WriteLine("exiting");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine($"err {choice} aint valid");
                }
                if (toDos.Any()) // if there is anything in the list then run
                {
                    // automatically calls tostring here so overload works
                    Console.WriteLine(toDos.Last());
                }
            }while (choiceInt!=2);
        }
        void CreateTodo()
        {

        }
    }
}