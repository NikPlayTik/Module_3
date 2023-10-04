using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FigureOutput figureOutput = new FigureOutput();
            Notification notification = new Notification();
            TaskManager taskManager = new TaskManager();
            Filtered filtered = new Filtered();
             
            while (true)
            {
                // меню выбора
                Console.WriteLine("\t---Меню---" +
                    "\n1. Создание класса Фигура с использованием делегатов" +
                    "\n2. Система событий мобильного приложения" +
                    "\n3. Приложение для управления задачами с использованием делегатов" +
                    "\n4. Систему фильтрации данных с использованием делегатов" +
                    "\n5. Приложение для сортировки числовых данных с ввыбором методом сортировки");

                string choiceNumber = Console.ReadLine();

                switch (choiceNumber)
                {
                    case "1":
                        Console.Clear();
                        figureOutput.OutputData();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        notification.OutputData();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        taskManager.Output();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        filtered.OutputData();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();

                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
