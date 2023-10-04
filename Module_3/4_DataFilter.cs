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
        public string inputText;
        public void OutputData()
        {
            Console.Write("Сколько дат вы хотите ввести: ");
            int dataCount = int.Parse(Console.ReadLine());

            List<string> dataList = new List<string>();

            for (int i = 0; i < dataCount; i++)
            {                
                do
                {
                    Console.Write("Введите дату (дд.мм.гггг): ");
                    inputText = Console.ReadLine();
                } while (!Regex.IsMatch(inputText, @"^\d{2}\.\d{2}\.\d{4}$"));

                dataList.Add(inputText);
            }    

                while (true)
            {
                Console.WriteLine("Выберите фильтр (1 - По дате, 2 - По ключевым словам, 3 - Выход): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Введите дату для фильтрации: ");
                    string filter = Console.ReadLine();
                    FilterData(dataList, FilterByDate, filter);
                }
                else if (choice == 2)
                {
                    Console.Write("Введите ключевое слово для фильтрации: ");
                    string filter = Console.ReadLine();
                    FilterData(dataList, FilterByKeyword, filter);
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                }
            }
        }

        // метод для фильтрации данных по дате
        private bool FilterByDate(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }

        // метод для фильтрации данных по ключевым словам
        private bool FilterByKeyword(string dataItem, string filter)
        {
            return dataItem.Contains(filter);
        }

        // метод для применения фильтра к данным с использованием делегата
        private void FilterData(List<string> dataList, DataFilterDelegate filterDelegate, string filter)
        {
            var filteredData = dataList.Where(item => filterDelegate(item, filter)).ToList();

            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
        }
    }

}
