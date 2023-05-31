using System;

namespace Roulette_the_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Person player = new Person();
            
            // Ввода имени игрока и проверка.
            var isCorrectName = false;
            do
            {
                Console.WriteLine("Введите ваше имя:");
                string inputname = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(inputname))
                {
                    Console.WriteLine("Нельзя оставить поле пустым! Введите как к вам обращаться:");
                }
                else
                {
                    isCorrectName = true;
                    player.Name = inputname;
                }
            } while (isCorrectName == false);

            // Ввод возраста игрока и проверка.
            byte inputAge;
            Console.WriteLine("Введите сколько вам лет:");
            while (!byte.TryParse(Console.ReadLine(), out inputAge))
            {
                Console.WriteLine("Ошибка ввода! Введите сколько вам полных лет:");
            }
            player.Age = inputAge;
            if (player.Age < 5)
            {
                Console.Clear();
                Console.WriteLine("НЕВОЗМОЖНО! ТЫ СЛИШКОМ МАЛЕНЬКИЙ И ТУПОЙ");
                Console.WriteLine();
                Console.WriteLine("Нажми любую клавишу для выхода");
                Console.ReadKey();
                Environment.Exit(0);
            }
   
            // Проверка ввода чит-кода для средств на счету.
            if (player.Name.Equals("Sum") && player.Age == 41)
            {
                Console.Clear();
                Console.WriteLine($"ПОЗДРАВЛЯЕМ, {player.Name + player.Age}! ВЫ ВВЕЛИ ЧИТ-КОД!");
                Console.WriteLine("Теперь вы сказачно богаты!");
                player.Cash = 9999999;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Привет, {player.Name}! Давай сыграем в рулетку!");
            }

            // Игровой цикл.
            do
            {
                Console.WriteLine();
                Console.WriteLine("Раунд " + player.Round);
                Console.WriteLine("На счету: " + player.Cash);

                // Ввод и проверка выбора.
                Console.WriteLine($"На что ставите от 1 до {player.MaxNum}:");
                var choise = 0;
                var choiseCorrect = false;
                while(!choiseCorrect)
                    {
                        while (!Int32.TryParse(Console.ReadLine(), out choise))
                        {
                            Console.WriteLine("Ошибка ввода! Введите число от 1 до 5: ");
                        }
                        if (choise < 1 || choise > 5)
                        {
                            Console.WriteLine("Ошибка ввода! Введите число от 1 до 5: ");
                        }
                        else
                        {
                        choiseCorrect = true;
                        }
                    }

                // Ввод и проверка ставки.
                Console.WriteLine($"Сколько ставите (возможный выигрыш {player.Coef}Х): ");
                var bet = 0;
                var betCorrect = false;
                while (!betCorrect)
                {
                    while (!Int32.TryParse(Console.ReadLine(), out bet))
                    {
                        Console.WriteLine("Ошибка ввода! Введите сколько вы хотите поставить: ");
                    }
                    if (bet < 1)
                    {
                        Console.WriteLine("Ставка должна быть больше нуля. Попробуйте ещё раз: ");
                    }
                    else if (bet > player.Cash)
                    {
                        Console.WriteLine("У вас недостаточно средств на счету. Попробуйте ещё раз: ");
                    }
                    else
                    {
                        betCorrect = true;
                    }
                }
                player.Bet = bet;
                
                // Проверка на режим бога.
                if (player.Bet == 777)
                {
                    player.IsGod = true;
                }
                else if (player.Bet == 666)
                {
                    player.IsGod = false;
                }
                
                // Результат игры.
                player.IsWin(choise);
                player.Round++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========================================");
            } while (player.Cash >= 1);
            Console.WriteLine();
            Console.WriteLine($"У вас, {player.Name}, кончились средства на счету! Очень жаль (нет)");
            Console.WriteLine("ИГРА ОКОНЧЕНА.");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}