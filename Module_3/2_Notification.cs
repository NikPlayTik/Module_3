using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    // Класс "Уведомление"
    public class Notification
    {
        public event Action<string> OnMessage;
        public event Action<string> OnCall;
        public event Action<string> OnEmail;
        public bool flagBool;

        public Notification() 
        {
            flagBool = true;
        }
        /*Оператор условного null ?. проверяет, не равно ли выражение слева
        от него null, прежде чем пытаться вызвать метод или свойство справа от него.*/
        public void SendMessage(string message)
        {
            OnMessage?.Invoke(message);
        }

        public void MakeCall(string number)
        {
            OnCall?.Invoke(number);
        }

        public void SendEmail(string email)
        {
            OnEmail?.Invoke(email);
        }

        public void OutputData()
        {
            Notification notification = new Notification();
            // message и т.д - анонимный метод
            notification.OnMessage += message => Console.WriteLine($"Отправка сообщения: {message}");
            notification.OnCall += number => Console.WriteLine($"Вызов на номер: {number}");
            notification.OnEmail += email => Console.WriteLine($"Отправка сообщения на электронную почту: {email}");

            while (flagBool)
            {
                Console.Write("Выберите тип уведомления (1 - сообщение, 2 - звонок, 3 - электронное письмо, 4 - выход): ");
                string choiceNumber = Console.ReadLine();
                switch (choiceNumber)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Введите сообщение: ");
                        string message = Console.ReadLine();
                        notification.SendMessage(message);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Введите номер: ");
                        string number = Console.ReadLine();
                        notification.MakeCall(number);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Введите адрес электронной почты: ");
                        string email = Console.ReadLine();
                        notification.SendEmail(email);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        flagBool = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
                
        }
    }
}
