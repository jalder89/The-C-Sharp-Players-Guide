using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersGuide.Methods
{
    public static class Utilities
    {
        /// <summary>
        /// Many previous tasks have required getting a number from a user. To save time writing this code
        /// repeatedly, you have decided to make a method to do this common task.
        /// 
        /// Objectives:
        /// Make a method with the signature int AskForNumber(string text). Display the text parameter in the console window, get a response from the user, convert it to an int, and return it.
        /// This might look like this: int result = AskForNumber("What is the airspeed velocity of an unladen swallow ? ");.
        /// 
        /// Make a method with the signature int AskForNumberInRange(string text, int min, int max).
        /// Only return if the entered number is between the min and max values.Otherwise, ask again.
        /// 
        /// Place these methods in at least one of your previous programs to improve it.
        /// </summary>

        public static int AskForNumber(string text)
        {
            Console.WriteLine(text);
            string? response = Console.ReadLine();
            do
            {
                if (response != null)
                {
                    if (int.TryParse(response, out int result))
                    {
                        return result;
                    } 
                    else 
                    {
                        Console.WriteLine("Invalid input detected, please input a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("No input detected, please input a valid number.");
                    continue;
                }

            } while (true);
        }

        public static int AskForNumberInRange(string text, int min, int max)
        {
            Console.WriteLine(text);
            string? response = Console.ReadLine();
            do
            {
                if (response != null)
                {
                    if (int.TryParse(response,out int result))
                    {
                        if (result >= min && result <= max)
                        {
                            return result;
                        }
                        else
                        {
                            Console.WriteLine("Input not within a valid range, please input a valid number");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input detected, please input a valid number.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("No input detected, please input a valid number.");
                    continue;
                }
            } while (true);

        }
    }
}
