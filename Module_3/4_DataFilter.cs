using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Module_3
{
    delegate bool DataFilterDelegate(string dataItem, string filter);

    class Filtered
    {
        private string inputText;

        public Filtered()
        {
            inputText = "Нет даты";
        }

        // метод для фильтрации данных по дате
        private bool FilterDate(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }
        // метод для фильтрации данных по ключевым словам
        private bool FilterKeyword(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }
        // метод для применения фильтра к данным с использованием делегата
        private void DataFilter(List<string> dataList, DataFilterDelegate filterDelegate, string filter)
        {
            var filteredData = dataList.Where(item => filterDelegate(item, filter)).ToList();

            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
        }
        public void OutputData()
        {
            Console.Write("Сколько дат вы хотите ввести: ");
            int dataCount = int.Parse(Console.ReadLine());
            List<string> dataList = new List<string>();

            while (true)
            {
                Console.WriteLine("Выберите действие (1 - Ввести дату, 2 - Фильтровать данные, 3 - Выход): ");
                int choiceNumber = int.Parse(Console.ReadLine());
                switch (choiceNumber)
                {
                    case 1:
                        for(int i = 0; i < dataCount; i++)
                        { 
                            Console.Write("Введите дату (дд.мм.гггг): ");
                            inputText = Console.ReadLine();
                            if (!Regex.IsMatch(inputText, @"^\d{2}\.\d{2}\.\d{4}$"))
                            {
                                Console.WriteLine("Некорректный формат даты");
                            }
                        }
                        dataList.Add(inputText);
                        break;
                    case 2:
                        Console.WriteLine("Выберите фильтр (1 - По дате, 2 - По ключевым словам): ");
                        int filterChoice = int.Parse(Console.ReadLine());
                        switch (filterChoice)
                        {
                            case 1:
                                Console.Write("Введите дату для фильтрации: ");
                                string dateFilter = Console.ReadLine();
                                if (Regex.IsMatch(inputText, @"^\d{2}\.\d{2}\.\d{4}$"))
                                {
                                    DataFilter(dataList, FilterDate, dateFilter);
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                                break;
                            case 2:
                                Console.Write("Введите ключевое слово для фильтрации: ");
                                string keywordFilter = Console.ReadLine();
                                DataFilter(dataList, FilterKeyword, keywordFilter);
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор");
                                break;
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        
    }

}
