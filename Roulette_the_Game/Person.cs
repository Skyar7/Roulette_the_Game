using System;
using System.Threading;

namespace Roulette_the_Game
{
    class Person
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public int Cash { get; set; } = 1000;
        public int Round { get; set; } = 1;
        public int MaxNum { get; set; } = 5;
        public int Coef { get; set; } = 4;
        public int Bet { get; set; }
        public bool IsGod { get; set; } = false;

        // Метод получения результата.
        public void IsWin(int playerchoise)
        {
            var posWin = Bet * Coef;
            
            // Режим бога.
            if (IsGod)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("БЫЛ ВВЕДЁН ЧИТ-КОД!");
                Console.WriteLine("АКТИВИРОВАН РЕЖИМ БОГА!");
                Console.WriteLine(Name + " - РУЛЕТОЧНЫЙ БОГ!");
                Console.WriteLine();
                Console.WriteLine("На вашем счету: " + Cash);
                Console.WriteLine("Ваша ставка: " + Bet);
                Console.WriteLine("Вы поставили на: " + playerchoise);
                Console.WriteLine("Пока ты моргнул, уже выпало: " + playerchoise);
                Cash += posWin;
                Console.WriteLine("У ВАС УДАЧА БОГА!");
                Console.WriteLine("Ваш выигрыш: " + posWin);
               
            }
            // Обычный режим игры.
            else
            {
                // Заставка.
                var loading = "=";
                for (var i = 0; i < 43; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("На вашем счету: " + Cash);
                    Console.WriteLine("Ваша ставка: " + Bet);
                    Console.WriteLine("Возможный выигрыш: " + posWin);
                    Console.WriteLine("Вы поставили на: " + playerchoise);
                    if (i % 2 == 0 && i != 42)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (i == 42)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine("Рулетка крутится, лавеха мутится (не точно)");
                    Console.WriteLine(loading);
                    loading = (loading + "=");
                    Thread.Sleep(40);
                }

                // Проверка победы.
                Random rnd = new Random();
                var comeOut = rnd.Next(1, MaxNum);
                if (playerchoise == comeOut)
                {
                    Cash += posWin;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Выпало: " + comeOut);
                    Console.WriteLine("ВЫ ПОБЕДИЛИ!");
                    Console.WriteLine("Ваш выигрыш: " + posWin);
                }
                else
                {
                    Cash -= Bet;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Выпало: " + comeOut);
                    Console.WriteLine("ВЫ ПРОИГРАЛИ!");
                }
            }
           
        }
    }
}
