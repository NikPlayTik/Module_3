using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module_3
{
    public class Task
    {
        public string Description;
        public Action TaskDelegate;
    }

    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(string description, Action taskDelegate)
        {
            tasks.Add(new Task
            {
                Description = description,
                TaskDelegate = taskDelegate
            });
        }

        public void ExecuteTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Выполняется задача: {task.Description}");
                task.TaskDelegate();
            }
        }

        public void Output()
        {
            TaskManager taskManager = new TaskManager();

            taskManager.AddTask("Отправить уведомление", () => Console.WriteLine("Уведомление отправлено!"));
            taskManager.AddTask("Запись в журнал", () => Console.WriteLine("Запись в журнал выполнена!"));

            taskManager.ExecuteTasks();

            Console.ReadLine();
        }
    }
}
