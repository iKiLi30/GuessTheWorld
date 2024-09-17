using System.Threading.Channels;

namespace GuessTheWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToGuess = null;

            Console.WriteLine("Welcome to 'Guess world!\n Do you want to type own words or guess?\n" +
                "Type Y if you want to type own world or 'N' if you want a randomly selected word");
            string randomOrNot = Console.ReadLine();
            randomOrNot = randomOrNot.ToUpper();

            bool isValidResponse;

            if ((randomOrNot == "Y") || (randomOrNot == "N"))
            {
                isValidResponse = true; 
            }
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

            else if (randomOrNot == "N")   // если выбрали угадывать слова из списка
            {
           
                //"C:\\Users\\user\\source\\repos\\GuessTheWorld\\WordToGuess.txt"
                string path = Path.Combine(@"C:\Users\user\source\repos\GuessTheWorld\WordToGuess.txt");
                string[] line = File.ReadAllLines(path);
                
                Random random = new Random();   
                int randomIndex = random.Next(line.Length);
                wordToGuess = line[randomIndex];
                wordToGuess = wordToGuess.ToUpper();
                Console.Clear();
                Console.WriteLine("Game Start");
            }
            int wordLenth = wordToGuess.Length;
            char[] positionsToGuess = new char[wordLenth];
            char[] wordToGuessChar = wordToGuess.ToCharArray();
            int lives = 5;

            List<char> letterGuessed = new List<char>();

            bool gameWon = false;

            for (int i = 0; i < wordLenth; i++)
            {
                positionsToGuess[i] = '_';
            }

            while (lives > 0)
            {
                string printProgress = String.Concat(positionsToGuess);

                bool letterFound = false;
                int multiples = 0;
                if (printProgress == wordToGuess)
                {
                    gameWon = true;
                    break;
                }

                Console.WriteLine("You have {0} lives!", lives);
                Console.WriteLine("Word to guess " + printProgress);
                Console.WriteLine("\n Guess a letter:");

                string playerGuessLetter = Console.ReadLine();

                bool guessTest = playerGuessLetter.All(Char.IsLetter);

                while (guessTest == false || playerGuessLetter.Length != 1)
                {
                    Console.WriteLine("Please input only a single letter");
                    Console.WriteLine("\n Guess a letter:");
                    playerGuessLetter = Console.ReadLine();
                    guessTest = playerGuessLetter.All(Char.IsLetter);
                }
                playerGuessLetter = playerGuessLetter.ToUpper();

                char playerChar = Convert.ToChar(playerGuessLetter);

                if (letterGuessed.Contains(playerChar) == false)
                {
                    letterGuessed.Add(playerChar);

                    for (int i = 0; i < wordToGuessChar.Length; i++)
                    {
                        if (wordToGuessChar[i] == playerChar)
                        {
                            positionsToGuess[i] = playerChar;
                            letterFound = true;
                            multiples++;
                        }
                    }

                    if (letterFound)
                    {
                        Console.Clear();
                        Console.WriteLine("Found {0} letter {1}!", multiples, playerChar);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("No letter{0}!", playerChar);
                        lives--;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You already guessed {0}!", playerChar);
                }
            }                        
        }
    }
}
