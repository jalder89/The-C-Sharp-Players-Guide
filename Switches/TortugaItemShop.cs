using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersGuide.Switches
{
    /// <summary>
    ///     Represents the Tortuga Item Shop, where players can interact with a shopkeeper to price items, sell items, or exit the shop.
    /// </summary>
    /// <remarks>
    ///     This static class implements a text-based shop interface with multiple menus and options.
    ///     It demonstrates the use of switch expressions for menu navigation and item pricing.
    ///     Special pricing is available for players named "Jessica".
    /// </remarks>
    public static class TortugaItemShop
    {
        private enum Menus
        {
            MainMenu,
            BuyMenu,
            SellMenu
        }

        private static string? playerName;

        /// <summary>
        ///     Starts the shop dialogue, allowing the player to interact with the shopkeeper.
        /// </summary>
        /// <remarks>
        ///     This is the main entry point for the Tortuga Item Shop interface.
        ///     The player is asked for their name and then presented with the main menu.
        /// </remarks>
        public static void StartShopDialogue()
        {
            Console.WriteLine("Welcome to the Tortuga Item Shop!\n");
            Console.WriteLine("What is your name traveler?");
            playerName = Console.ReadLine();
            int choice = Methods.Utilities.AskForNumber("1. Price Items\n2. Sell Items\n3. Exit\n");
            int response = choice switch
            {
                1 => PriceItems(),
                2 => SellItems(),
                3 => Exit(),
                _ => InvalidChoice(Menus.MainMenu)
            };
        }

        private static int PriceItems()
        {
            List<string> items = new List<string>
                   {
                       "Rope",
                       "Torches",
                       "Climbing Equipment",
                       "Clean Water",
                       "Machete",
                       "Canoe",
                       "Food Supplies"
                   };

            Console.WriteLine("The following items are available:");
            Console.WriteLine("1. Rope");
            Console.WriteLine("2. Torch");
            Console.WriteLine("3. Climbing Equipment");
            Console.WriteLine("4. Clean Water");
            Console.WriteLine("5. Machete");
            Console.WriteLine("6. Canoe");
            Console.WriteLine("7. Food");

            int itemChoice = Methods.Utilities.AskForNumberInRange("Please enter the number of the item you wish to price:", 1, 7);
            int price = itemChoice switch
            {
                1 => 10,
                2 => 16,
                3 => 24,
                4 => 2,
                5 => 20,
                6 => 200,
                7 => 2,
                _ => InvalidChoice(Menus.BuyMenu)
            };

            if (playerName == "Jessica")
            {
                Console.WriteLine($"{items[itemChoice - 1]} costs {price / 2} gold.");
            }
            else
            {
                Console.WriteLine($"{items[itemChoice - 1]} costs {price} gold.");
            }
            return 1;
        }

        private static int SellItems()
        {
            Console.WriteLine("You have sold an item!");
            return 0;
        }

        private static int Exit()
        {
            Console.WriteLine("Thank you for visiting the Tortuga Item Shop!");
            return 0;
        }

        /// <summary>
        ///     Handles invalid menu choices and redirects the player to the appropriate menu.
        /// </summary>
        /// <param name="CURRENT_MENU">
        ///     The current menu where the invalid choice occurred.
        /// </param>
        /// <remarks>
        ///     This method recursively calls the appropriate menu method based on where the invalid choice occurred.
        /// </remarks>
        /// <returns>
        ///     An integer indicating the result of the operation (0 for success).
        /// </returns>
        private static int InvalidChoice(Enum CURRENT_MENU)
        {
            switch (CURRENT_MENU)
            {
                case Menus.MainMenu:
                    Console.WriteLine("Invalid choice. Please try again.");
                    StartShopDialogue();
                    break;
                case Menus.BuyMenu:
                    Console.WriteLine("Invalid choice. Please select an item to price.");
                    PriceItems();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to the main menu.");
                    StartShopDialogue();
                    break;
            }
            return 0;
        }
    }
}
