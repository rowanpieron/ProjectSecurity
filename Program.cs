using System;
using System.Collections.Generic;

namespace TaakbeheerApp
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string AssignedUser { get; set; }
        public bool IsCompleted { get; set; }
        public List<string> Notes { get; set; }

        public Task(string title, string description, DateTime deadline, string assignedUser)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            AssignedUser = assignedUser;
            IsCompleted = false;
            Notes = new List<string>();
        }
    }

    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(string title, string description, DateTime deadline, string assignedUser)
        {
            Task newTask = new Task(title, description, deadline, assignedUser);
            tasks.Add(newTask);
            Console.WriteLine("Taak toegevoegd: " + title);
        }

        public void MarkTaskAsCompleted(string title)
        {
            Task task = tasks.Find(t => t.Title == title);
            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine("Taak gemarkeerd als voltooid: " + title);
            }
            else
            {
                Console.WriteLine("Taak niet gevonden: " + title);
            }
        }

        public void AddNoteToTask(string title, string note)
        {
            Task task = tasks.Find(t => t.Title == title);
            if (task != null)
            {
                task.Notes.Add(note);
                Console.WriteLine("Notitie toegevoegd aan taak: " + title);
            }
            else
            {
                Console.WriteLine("Taak niet gevonden: " + title);
            }
        }

        public void DisplayTasks()
        {
            Console.WriteLine("Takenlijst:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + tasks[i].Title);
            }
        }

        public Task GetTaskByIndex(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                return tasks[index];
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            Console.WriteLine("Welkom bij de Taakbeheer-app!");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nWat wil je doen?");
                Console.WriteLine("1. Taak toevoegen");
                Console.WriteLine("2. Taak markeren als voltooid");
                Console.WriteLine("3. Notitie toevoegen aan taak");
                Console.WriteLine("4. Taken weergeven");
                Console.WriteLine("5. Afsluiten");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Voer een taaknaam in: ");
                        string title = Console.ReadLine();
                        Console.Write("Voer een taakbeschrijving in: ");
                        string description = Console.ReadLine();
                        Console.Write("Voer een deadline in (dd-mm-jjjj): ");
                        DateTime deadline = DateTime.Parse(Console.ReadLine());
                        Console.Write("Voer een toegewezen gebruiker in: ");
                        string assignedUser = Console.ReadLine();
                        taskManager.AddTask(title, description, deadline, assignedUser);
                        break;
                    case "2":
                        Console.Write("Voer de naam van de taak in die je wilt markeren als voltooid: ");
                        string taskToMark = Console.ReadLine();
                        taskManager.MarkTaskAsCompleted(taskToMark);
                        break;
                    case "3":
                        taskManager.DisplayTasks();
                        Console.Write("Kies het nummer van de taak waar je een notitie aan wilt toevoegen: ");
                        int taskIndex = int.Parse(Console.ReadLine()) - 1;
                        Task selectedTask = taskManager.GetTaskByIndex(taskIndex);
                        if (selectedTask != null)
                        {
                            Console.Write("Voer de notitie in: ");
                            string note = Console.ReadLine();
                            taskManager.AddNoteToTask(selectedTask.Title, note);
                        }
                        else
                        {
                            Console.WriteLine("Ongeldig taaknummer. Probeer opnieuw.");
                        }
                        break;
                    case "4":
                        taskManager.DisplayTasks();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }

            Console.WriteLine("Bedankt voor het gebruik van de Taakbeheer-app. Tot ziens!");
        }
    }
}
