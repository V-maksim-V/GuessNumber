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
            else(guessingPlayer == GuessingPlayer.Machine)
            {
                MachineGuesses();
            }
               
        }
        public void HumanGuesses()
        {
            Random random = new Random();
            int guessesNumber = random.Next(0, max);
            int lactGuess = -1;

        }
        public void MachineGuesses()
        {

        }






    }
}
