using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellStuff
{
    internal class MethodEnter
    {
        private static void MethodEnterPrompt()
        {
            string userEntry = "a";
            string result = "a";
            bool Loop = true;
            while (Loop)
            {
                Console.WriteLine("Do you want to create the method yourself or have the AI make one? (yes to make yourself, no to not)");
                userEntry = Console.ReadLine();
                result = InputSanitizer(userEntry, 1);
                if (result == "LOOP")
                {
                    Loop = true;
                    Console.WriteLine("In Vaild Entery");
                }
                else if (result == "YES")
                {

                }
                else
                {

                }
            }

        }

        public static string InputSanitizer(string userInput, int isString)
        {
            int parsedUserData = 0;
            string returnString = "a";
            string lowerInput = "a";
            string capitalizedString = "A";

            if (isString == 1)
            {
                capitalizedString = userInput.ToUpper();
                if (capitalizedString == "YES" || capitalizedString == "YE" || capitalizedString == "Y" || capitalizedString == "1")
                {
                    returnString = "YES";
                }
                else if (capitalizedString == "NO" || capitalizedString == "N" || capitalizedString == "0" || capitalizedString == "NOO")
                {
                    returnString = "NO";
                }
                else
                {
                    returnString = "LOOP";
                }
            }
            else if (isString == 0)
            {
                bool isSuccess = int.TryParse(userInput, out parsedUserData);

                if (isSuccess && parsedUserData > 0)
                {
                    returnString = userInput;
                }
                else
                {
                    returnString = "LOOP";
                }
            }
            else if (isString == 3)
            {
                try
                {
                    bool.Parse(userInput);
                    return "TRUE";
                }
                catch
                {
                    lowerInput = userInput.ToLower();
                    if (lowerInput == "true" || lowerInput == "t" || lowerInput == "yes" || lowerInput == "y" || lowerInput == "1")
                    {
                        returnString = "TRUE";
                    }
                    else if (lowerInput == "false" || lowerInput == "f" || lowerInput == "no" || lowerInput == "n" || lowerInput == "0")
                    {
                        returnString = "TRUE";
                    }
                    else
                    {
                        returnString = "LOOP";
                    }
                }


            }
            return returnString;
        }
        public static string MethodTypeChooser(string userInput)
        {
            // Convert the input to uppercase
            string userInputCommunized = userInput.ToUpper();

            try
            {
                List<string> bellRingingMethods = new List<string>
              {
            "HUNT",
            "LITTLE",
            "SURPRISE",
            "TREBLE"
             };
                Console.WriteLine("Available Method Types:");
                foreach (var method in bellRingingMethods)
                {
                    Console.WriteLine(method);
                }
                foreach (var method in bellRingingMethods)
                {
                    if (userInputCommunized.Contains(method))
                    {
                        Console.WriteLine($"You selected: {method}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return userInputCommunized;
        }
    }
}