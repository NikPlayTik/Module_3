using Module_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module_3
{
    // Создаем делегат для выполнения задач
    delegate void TaskDelegate(string taskName);
    class TaskManager
    {
        public event TaskDelegate TaskExecuted;
        private List<Tuple<string, TaskDelegate>> tasks = new List<Tuple<string, TaskDelegate>>();

        // Добавление задачи и делегата для выполнения
        public void AddTask(string taskName, TaskDelegate taskDelegate)
        {
            tasks.Add(new Tuple<string, TaskDelegate>(taskName, taskDelegate));
            Console.WriteLine($"Задача добавлена: {taskName}");
        }

        // Выполнение всех задач
        public void ExecuteTasks()
        {
            foreach (var task in tasks)
            {
                TaskDelegate taskDelegate = task.Item2;
                taskDelegate.Invoke(task.Item1);
            }
        }

        public void SendNotification(string taskName)
        {
            Console.WriteLine($"Отправка уведомления для задачи: {taskName}");
        }

        public void LogToJournal(string taskName)
        {
            Console.WriteLine($"Запись в журнал для задачи: {taskName}");
        }

        public void Output()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выход");

                string choiceNumber = Console.ReadLine();

                switch (choiceNumber)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Выберите действие для задачи:");
                        Console.WriteLine("1. Отправить уведомление");
                        Console.WriteLine("2. Записать в журнал");
                        Console.WriteLine("3. Назад");

                        string actionChoice = Console.ReadLine();
                        TaskDelegate taskDelegate = null;

                        // Выбор события
                        switch (actionChoice)
                        {
                            case "1":
                                taskDelegate = SendNotification;
                                break;
                            case "2":
                                taskDelegate = LogToJournal;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор действия");
                                break;
                        }

                        if (taskDelegate != null)
                        {
                            AddTask(taskName, taskDelegate);
                        }
                        break;
                    case "2":
                        ExecuteTasks();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор действия");
                        break;
                }
            }
        }
    }
}
