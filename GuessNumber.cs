using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    public enum GuessingPlayer
    {
        Human,
        Machine
    }

    public class GuessNumber
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public GuessNumber(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }
        public void Start()
        {
            if (guessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses();
            }
            else if (guessingPlayer == GuessingPlayer.Machine)
            {
                MachineGuesses();
            }
               
        }
        public void HumanGuesses()
        {
            Random random = new Random();
            int guessesNumber = random.Next(0, max);
            int lactGuess = -1;
            int tries = 0;
            Console.WriteLine("У Вас есть 5 попытак чтобы угадать число!");
            while (lactGuess != guessesNumber && tries < maxTries)
            {
                Console.WriteLine("Ввeдите число:");
                lactGuess = int.Parse(Console.ReadLine());
                if (guessesNumber == lactGuess)
                {
                    Console.WriteLine("Вы угадали! Поздравляю!");
                    break;
                }
                else if (guessesNumber > lactGuess)
                {
                    Console.WriteLine("Загаданное число меньше введеннго.");
                }
                else if(guessesNumber < lactGuess)
                {
                    Console.WriteLine("Загаданное число больше введеннго.");
                }
                tries++;
                if(tries == maxTries)
                {
                    Console.WriteLine("Вы проиграли! У Вас закончились попытки.");
                }
            }
        }
        public void MachineGuesses()
        {
            Console.WriteLine("Введите число которое должен отгадать компьютер:");
            int guessesNumber = -1;

            while (guessesNumber == -1)
            {
                int parssedNumber = int.Parse(Console.ReadLine());
                if (parssedNumber >= 0 && parssedNumber <= this.max)
                {
                    guessesNumber = parssedNumber;
                }
            }

            int lactGuess = -1;
            int tries = 0;
            int max = this.max;
            int min = 0;

            while (lactGuess != guessesNumber && tries < maxTries)
            {
                lactGuess = (min + max) / 2;
                Console.WriteLine($"Ты загодал это число - {lactGuess}?");
                Console.WriteLine("Если ДА, то нажми 'y', если загаданное число больше, то нажми 'g', если меньше, то 'l'.");

                string ansfer = Console.ReadLine();
                if (ansfer == "y")
                {
                    Console.WriteLine("Компьютер победил!");
                    break;
                }
                else if(ansfer == "g")
                {
                    Console.WriteLine("Загаданное число больше введенного.");
                    min = lactGuess;
                }
                else
                {
                    Console.WriteLine("Загаданное число меньше введенного.");
                    max = lactGuess;
                }

                if(lactGuess == guessesNumber)  //проверка
                    Console.WriteLine("Я угодал, не обманывай!");
                tries++;
                if(tries==maxTries)
                    Console.WriteLine("Компьютер проиграл! Попытки закончились.");
            }
        }
    }
}
