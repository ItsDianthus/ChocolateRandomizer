using System;

namespace Chocorandom
{
    class Program
    {
        static void Main()
        {
            // Setting last data far away in the past.
            DateTime lastData = new DateTime(1991, 02, 19);

            // Here we're setting the amount of chocolate bars that we have.
            // Their positions:
            //  Blue = 0, Red = 1, Brown = 2, Green = 3, Yellow = 4, Pink = 5
            int[] current = { 1, 2, 2, 2, 0, 1 };
            do
            {
                ChoseNewColourOfChocolate(ref current, ref lastData);
                WriteLineBySymbol("Для продолжения нажмите любую кнопку", ConsoleColor.DarkGray);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            

        }

        static void ChoseNewColourOfChocolate(ref int[] current, ref DateTime lastData)
        {
            try
            {
                WriteLineBySymbol("\nЗдравствуйте!");
                if (lastData.Date == DateTime.Now.Date) { WriteLineBySymbol("Извините, Вы уже выбирали шоколадку на сегодня! Две шоколадки будет для вас перебором. Ждём завтра)", ConsoleColor.DarkYellow); return; }
                WriteBySymbol("Данный метод поможет Вам выбрать шоколадку на сегодня: ");
                WriteLineBySymbol(DateTime.Now.ToString("f"));

                WriteLineBySymbol("Думаю...");
                Thread.Sleep(600);
                Random rnd = new Random();
                int ind = rnd.Next(6);
                while (current[ind] == 0)
                {
                    WriteLineBySymbol("Ой!", ConsoleColor.Red);
                    WriteLineBySymbol("Я хотел выбрать шоколадку, все экземпляры которой уже были съедены. \nСейчас выберу другую...");
                    ind = rnd.Next(6);
                }
                WriteLineBySymbol("Итак... Вам выпала шоколадка номер...");
                WriteLineBySymbol("...3...", ConsoleColor.Magenta);
                WriteLineBySymbol("...2...", ConsoleColor.Red);
                WriteLineBySymbol("...1...", ConsoleColor.Blue);
                ChocolateColors chocolate = (ChocolateColors)ind;
                var chocDict = new Dictionary<ChocolateColors, object[]>()
                {
                    {ChocolateColors.Red, new object[]{"Красная шоколадка с Марципаном", ConsoleColor.Red} },
                    {ChocolateColors.Blue, new object[]{"Голубая шоколадка с Альпийским молоком", ConsoleColor.Blue} },
                    {ChocolateColors.Brown, new object[]{"Коричневая шоколадка с Хрустящим печеньем", ConsoleColor.Gray} },
                    {ChocolateColors.Green, new object[]{"Зелёная шоколадка с Лесным Орехом", ConsoleColor.Green} },
                    {ChocolateColors.Yellow, new object[]{"Жёлтая шоколадка с Кукурузными хлопьями", ConsoleColor.Yellow} },
                    {ChocolateColors.Pink, new object[]{"Розовая шоколадка с Клубникой с Йогуртом", ConsoleColor.Magenta}}
                };

                current[ind] -= 1;
                lastData = DateTime.Now;
                WriteLineBySymbol(chocDict[chocolate][0].ToString() + "!", (ConsoleColor)chocDict[chocolate][1]);

            }
            catch (Exception ex) when (ex is ArgumentException)
            {
                Console.WriteLine("Sorry, some sort of mistake has happeed.");
            }
        }

        static void WriteLineBySymbol(string message, ConsoleColor color= ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char a in message)
            {

                Console.Write(a);
                Thread.Sleep(30);
            }
            Console.Write("\n");
            Thread.Sleep(900);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteBySymbol(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char a in message)
            {

                Console.Write(a);
                Thread.Sleep(20);
            }
            Thread.Sleep(30);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public enum ChocolateColors : uint
    {
        Blue = 0, Red = 1, Brown = 2, Green = 3, Yellow = 4, Pink = 5
    }
}

