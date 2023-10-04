using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    
    public class Sort
    {
        private delegate void SortDelegate(int[] arr);
        Random random = new Random();
                
        // генерация массива случайных чисел
        public int[] GenerateRandomArray(int size)
        {            
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(101); // Генерировать случайные числа от 0 до 100
            }
            return array;
        }

        // сортировка пузырьком
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // быстрая сортировка
        public void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        // Метод для применения метода сортировки к данным с использованием делегата
        private void SortData(int[] data, SortDelegate sortMethod)
        {
            int[] copy = new int[data.Length];
            Array.Copy(data, copy, data.Length);

            sortMethod(copy);

            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(string.Join(" ", copy));
        }

        public void OutputData()
        {
            Console.Write("Введите размерность массива: ");
            int size = int.Parse(Console.ReadLine());
            int[] numbers = GenerateRandomArray(size);

            Console.WriteLine("Сгенерированный массив:");
            Console.WriteLine(string.Join(" ", numbers));

            while (true)
            {
                Console.WriteLine("Выберите метод сортировки (1 - Сортировка пузырьком, 2 - Быстрая сортировка, 3 - Выход): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    SortData(numbers, BubbleSort);
                }
                else if (choice == 2)
                {
                    SortData(numbers, QuickSort);
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
    }
}
