using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellStuff
{
    public class AIMethodMaker
    {
        public void CreateMethod()
        {
            string userInput = "a";
            bool Loop = true;
            string sanitizedInput = "a";
            Method AImethod = new Method();

            Console.WriteLine("Enter Method Name:");
            AImethod.MethodName = Console.ReadLine();

            Console.WriteLine("Enter Method Length:");
            userInput = Console.ReadLine();
            sanitizedInput = MethodEnter.InputSanitizer(userInput, 0);
            if (sanitizedInput == "LOOP")
            {
                Loop = true;
                Console.WriteLine("Bad Input");
            }
            else
            {
                AImethod.MethodLenght = int.Parse(sanitizedInput);
                Loop = false;
            }


            Console.WriteLine("Enter Method Type:");

            userInput = Console.ReadLine();
            sanitizedInput = MethodEnter.MethodTypeChooser(userInput);
            AImethod.MethodType = sanitizedInput;

            Loop = true;
            while (Loop)
            {
                Console.WriteLine("Is the method Trebbel Oriented? (true/false):");
                sanitizedInput = MethodEnter.InputSanitizer(userInput, 3);

                if (sanitizedInput == "LOOP")
                {
                    Loop = true;
                    Console.WriteLine("Bad Input");
                }
                else
                {
                    AImethod.TrebbelOrintated = bool.Parse(sanitizedInput);
                };

                if (sanitizedInput == "TRUE")
                {
                    while (Loop)
                    {
                        Console.WriteLine("How many leads do you want before method compleation(rounds)?");
                        sanitizedInput = MethodEnter.InputSanitizer(userInput, 0);
                        AImethod.MethodLeadCount = int.Parse(sanitizedInput);

                    }
                }
                else
                {
                    while (Loop)
                    {
                        Console.WriteLine("How many Rows do you want before method compleation(rounds)?");
                        sanitizedInput = MethodEnter.InputSanitizer(userInput, 0);
                        AImethod.MethodRowCount = int.Parse(sanitizedInput);

                    }
                }




                Console.WriteLine("Next Stage!");

            }
             void AiCreationOfMethod()
            {

            }
        }
    }
}


