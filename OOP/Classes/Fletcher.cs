using System.Diagnostics;
using PlayersGuide.Methods;


namespace PlayersGuide.Classes
{
    public static class Fletcher
    {
        public static void OpenStore()
        {
            // Console.WriteLine("Welcome to Fletcher's, home of the best arrows in Yargrisil!");
            // Process.Start("say", "-v Matilda -r 190 Welcome to Fletcher's, home of the best arrows in Yargrisil!").WaitForExit();
            Utilities.HandleDialogue("Welcome to Fletcher's, home of the best arrows in Yargrisil!");

            string[] storeMenu = { "Buy", "Sell", "Exit" };
            
            int menuChoice = Utilities.PromptMenuOptions("Are you looking for anything particular?", storeMenu);

            if (menuChoice == 1)
            {
                Utilities.HandleDialogue("A great choice! We custom craft all of our arrows at Fletchers, I'm sure we have what you need.");
                int length = PromptArrowLength();
                ArrowHead arrowHead = PromptArrowHeadType();
                ArrowFletching arrowFletching = PromptArrowFletchingType();
                Arrow arrow = new Arrow(length, arrowFletching, arrowHead);
                Utilities.HandleDialogue($"Your arrow will cost {arrow.GetCost()} gold.");
            }
            else if (menuChoice == 2)
            {
                Utilities.HandleDialogue("I'm sorry, we don't actually buy arrows. However, we can help you craft a new one!");
            }
            else
            {
                Utilities.HandleDialogue("Thank you for visiting Fletcher's! Come back soon!");
            }

        }

        public static int PromptArrowLength()
        {
            int[] lengths = { 28, 29, 30, 31, 32 };
            string[] lengthOptions = Array.ConvertAll(lengths, l => l.ToString());
            int choice = Utilities.PromptMenuOptions("Select Arrow Length:", lengthOptions);
            return lengths[choice - 1];
        }

        public static ArrowHead PromptArrowHeadType()
        {
            string[] headOptions = Enum.GetNames(typeof(ArrowHead));
            int choice = Utilities.PromptMenuOptions("Select Arrow Head:", headOptions);
            var selectedHead = (ArrowHead)Enum.Parse(typeof(ArrowHead), headOptions[choice - 1]);
            Console.WriteLine($"You selected: {selectedHead}");
            return selectedHead;
        }

        public static ArrowFletching PromptArrowFletchingType()
        {
            string[] fletchingOptions = Enum.GetNames(typeof(ArrowFletching));
            int choice = Utilities.PromptMenuOptions("Select Arrow Fletching:", fletchingOptions);
            var selectedFletching = (ArrowFletching)Enum.Parse(typeof(ArrowFletching), fletchingOptions[choice - 1]);
            Console.WriteLine($"You selected: {selectedFletching}");
            return selectedFletching;
        }

    }
}

