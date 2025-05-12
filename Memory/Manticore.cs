using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PlayersGuide.Methods;

namespace PlayersGuide.Memory
{
    public static class Manticore
    {
        public static void Run()
        {
            const int ManticoreMaxHealth = 10;
            int manticoreHealth = 10;
            int manticoreRange = 0;
            int manticoreDamage = 1;
            const int CityMaxHealth = 15;
            int cityHealth = 15;
            int cannonRange = 0;
            int cannonDamage = 0;
            bool didHit = false;
            int round = 1;
            int[] healthReferences = { manticoreHealth, cityHealth };

            Console.Beep();

            // Title
            Console.Title = "Hunting the Manticore";
            Console.Write("\t\t\t\t|\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Welcome ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("to ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hunting ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Manticore!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t|");
            Console.ResetColor();
            Utilities.AddSeperator(true);
            
            // Introduction
            Console.WriteLine("The Uncoded One’s airship, the Manticore, has begun an all-out attack on the city of Consolas. It must be\ndestroyed, or the city will fall. Only by combining Mylara’s prototype, Skorin’s cannon, and your\nprogramming skills will you have a chance to win this fight.You must build a program that allows one\nuser, the pilot of the Manticore, to enter the airship’s distance from the city and a second user, the city’s\ndefenses, to attempt to find what distance the airship is at and destroy it before it can lay waste to the\ntown.\n");
            Utilities.AddSeperator();

            // Set the Manticore's location
            manticoreRange = Utilities.AskForNumberInRange("Player 1, Captain of the glorious Manticore, where will you station your ship?\nEnter a number between 1-100: ", 1, 100);
            Console.Clear();
            Console.WriteLine("Player 2, your turn... Find and defeat the dreaded Manticore!");

            // Game Loop
            while (manticoreHealth > 0 && cityHealth > 0)
            {
                DisplayRoundInfo(round, cityHealth, CityMaxHealth, manticoreHealth, ManticoreMaxHealth);
                cannonDamage = CalculateCannonDamage(round);
                cannonRange = Utilities.AskForNumberInRange("Enter desired cannon range: ", 1, 100);
                Utilities.AddSeperator();
                didHit = CalculateHit(cannonRange, manticoreRange);
                if (!didHit)
                {
                    Console.WriteLine($"\t\tCity damage received: {manticoreDamage}");
                    cityHealth -= manticoreDamage;
                }
                else
                {
                    Console.WriteLine($"\t\tManticore damage taken: {cannonDamage}");
                    manticoreHealth -= cannonDamage;

                    Console.WriteLine($"\t\tCity damage received: {manticoreDamage}");
                    cityHealth -= manticoreDamage;
                }
                ResolveRound(cityHealth, manticoreHealth);
                round++;
            }

        }


        private static void DisplayRoundInfo(int currentRound, int cityCurrentHealth, int CityMaxHealth, int manticoreCurrentHealth, int ManticoreMaxHealth)
        {
            Utilities.AddSeperator();
            Console.Write("\t\t\tSTATUS: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Round: ");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write($"{currentRound}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tCity: ");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write($"{cityCurrentHealth}/{CityMaxHealth}");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write("\tManticore: ");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine($"{manticoreCurrentHealth}/{ManticoreMaxHealth}");
            Console.WriteLine("The manticore is expected to deal 1 damage this round.");
            Utilities.AddSeperator();
        }

        private static int CalculateCannonDamage(int currentRound)
        {
            // Checks if round is a multiple of 3 and 5 for 10 damage, 3 or 5 for 3 damage, otherwise 1 damage is done.
            if (currentRound % 3 == 0 && currentRound % 5 == 0)
            {
                return 10;
            }
            else if (currentRound % 3 != 0 && currentRound % 5 == 0 || currentRound % 3 == 0 && currentRound % 5 != 0)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        
        private static bool CalculateHit(int cannonRange, int manticoreRange)
        {
            if (cannonRange == manticoreRange)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t\tDIRECT HIT!!!");
                Console.ResetColor();
                return true;
            }
            else if (cannonRange < manticoreRange)
            {
                Console.WriteLine("That round FELL SHORT of the target.");
                return false;
            }
            else if (cannonRange > manticoreRange)
            {
                Console.WriteLine("OVERSHOT! That round flew beyond the target.");
                return false;
            }
            else
            {
                return false;
            }
        }

        private static void ResolveRound(int currentCityHealth, int currentManticoreHealth)
        {
            if (currentCityHealth <= 0)
            {
                Console.WriteLine($"The city has been destroyed! All is lost!");
            }
            else if (currentManticoreHealth <= 0)
            {
                Console.WriteLine($"The manticore has been destroyed! The city is saved!");
            }
        }
    }
}
