using System;

namespace Events_Ping_Pong
{
    public delegate void Del(string message);
    public class Ping
    {
        public event Del Notify;
        public Ping() {}
        public void Start(string player) { Notify?.Invoke($"Понг получил от {player} "); }
    }
    public class Pong
    {
        public delegate void Del2(string message);
        public event Del2 Notify;
        public Pong() {}
        public void Start(string player) { Notify?.Invoke($"Пинг получил от {player} "); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ping ping1 = new Ping();
            Pong pong1 = new Pong();
            string answer = "";
            Link1: ping1.Notify -= DisplayMessage; pong1.Notify -= DisplayMessage;
            Console.WriteLine("1 - Пинг отправляет\n2 - Понг отправляет \n3 - Выйти");
            answer = Console.ReadLine();
                switch (answer)
                {
                    case ("1"):
                        ping1.Notify += DisplayMessage;
                        ping1.Start("Пинг");
                    goto Link1;
                   
                    break;
                    case ("2"):
                        pong1.Notify += DisplayMessage;
                        pong1.Start("Понг");
                    goto Link1;
                    break;
                    case ("3"):
                        break;
                    default:
                        Console.WriteLine("Ошибка. Введите 1 , 2 или 3");
                        break;
                }
            
            static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
