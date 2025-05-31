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
                Utilities.HandleDialogue("A great choice! We craft all of our arrows at Fletchers, I'm sure we have what you need.");
                string[] buyMenu = { "Beginner Arrow", "Marksman Arrow", "Elite Arrow", "Custom", "Exit" };
                int buyMenuChoice = Utilities.PromptMenuOptions(buyMenu);
                Arrow? arrow = null;
                switch (buyMenuChoice)
                {
                    case 1:
                        arrow = Arrow.createBeginnerArrow();
                        Utilities.HandleDialogue($"Your arrow will cost {arrow.GetCost()} gold.");
                        break;
                    case 2:
                        arrow = Arrow.createMarksmanArrow();
                        Utilities.HandleDialogue($"Your arrow will cost {arrow.GetCost()} gold.");
                        break;
                    case 3:
                        arrow = Arrow.createEliteArrow();
                        Utilities.HandleDialogue($"Your arrow will cost {arrow.GetCost()} gold.");
                        break;
                    case 4:
                        int length = PromptArrowLength();
                        ArrowHead arrowHead = PromptArrowHeadType();
                        ArrowFletching arrowFletching = PromptArrowFletchingType();
                        arrow = new Arrow(length, arrowFletching, arrowHead);
                        Utilities.HandleDialogue($"Your arrow will cost {arrow.GetCost()} gold.");
                        break;
                    default:
                        Utilities.HandleDialogue("Alright... Let me know if you change your mind.");
                        break;

                }
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

