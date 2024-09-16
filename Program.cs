using System.Threading.Channels;

namespace GuessTheWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 'Guess world!\n Do you want to type own words or guess?\n" +
                "Type Y if you want to type own world or 'N' if you want a randomly selected word");
            string randomOrNot = Console.ReadLine();
            randomOrNot = randomOrNot.ToUpper();

            bool isValidResponse;

            if ((randomOrNot == "Y") || (randomOrNot == "N")){
                isValidResponse = true; }
            else { 
                isValidResponse = false;
            }


            while (isValidResponse == false) 
            {
                Console.WriteLine("Only N or Y");
                randomOrNot = Console.ReadLine();
                randomOrNot = randomOrNot.ToUpper();
                if ((randomOrNot == "Y") || (randomOrNot == "N"))
                {
                    isValidResponse = true;
                }
                else
                {
                    isValidResponse = false;
                }

            }
            Console.Clear();
            string wordToGuess = null;

            if (randomOrNot == "Y")
            {
                Console.WriteLine("Enter ahe word for the guest to guess: ");
                wordToGuess = Console.ReadLine();

                bool isOnlyLetters = wordToGuess.All(Char.IsLetter);
                while (isOnlyLetters == false || wordToGuess.Length == 0)
                {
                    Console.WriteLine("Please inter only letters. \n Tets try again");
                    wordToGuess = Console.ReadLine();
                    isOnlyLetters = wordToGuess.All(Char.IsLetter);
                }
                wordToGuess = wordToGuess.ToUpper();
            }

            else if (randomOrNot == "N")
            {
                //C:\Users\user\source\repos\GuessTheWorld
                var path = Path.Combine(@"...\...\...\WordsToGuess.txt");

            }
        }
    }
}
