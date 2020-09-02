using System;

namespace c_odd_even_sorter_practice_T_Ralph
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Title: C# Odd/Even Sorter Practice
                Purpose: This program receives an array of numbers and sorts the odd numbers, then, the even numbers
                Author: Tosin Raphael Olaniyi (T-Ralph)
                Date: August 13, 2020
                Doc: https://docs.google.com/document/d/1K7AcbxyL32CFlHFzgtfj81ANHqiASsvj7C1JOYFglus/edit#
            */

            //Greet the user
            Console.WriteLine("  ------- -- -- -------- ------ --------  \n| Welcome to C# Odd/Even Sorter Practice |\n  ------- -- -- -------- ------ --------  ");
            Console.WriteLine("-> Enter 10 Numbers and the Program will sort the Odd and Even Numbers");

            MainProcess(); //Run the MainProcess method
        }
         static void MainProcess() {
            string initiateInput = ""; //Declare datatypes
            
            Console.Write("-> To start the Program, hit enter; To exit the Program, enter Letter 'q' (case insensitive):"); //Greet the user

            //Listen for 'q' to exit program using Loop
            while (initiateInput.ToLower() != "q")
            {
                initiateInput = Console.ReadLine(); //Ask for input
                if (initiateInput.ToLower() == "q")
                {
                    ExitProgram(); //Exit the Program
                }
                else {
                    InputProcess(); //Run InputProcess method
                    MainProcess(); //Run MainProcess method again
                }
            }

        }
        static void InputProcess() {
            //Declare datatypes
            string numberInput;
            int[] numbersArray = new int[10];
            bool valid;

            //for loop for 10 inputs
            for (int i = 0; i < 10; i++)
            {
                valid = false;
                do
                {
                    //Ask for input until validated
                    Console.Write($"Enter the Number #{i + 1}: ");
                    numberInput = Console.ReadLine();

                    //Check for "done" and break loop
                    if (numberInput.ToLower() == "done")
                    {
                        valid = true;
                        break;
                    }
                    else
                    {
                        //Validate input
                        if (ValidateInput(numberInput))
                        {
                            numbersArray[i] = Convert.ToInt32(numberInput);
                            valid = true;
                        }
                    }

                    
                } while (valid == false);

                //Check for "done" and break loop
                if (numberInput.ToLower() == "done")
                {
                    valid = true;
                    break;
                }
            }

            ProcessArray(numbersArray); //Process and Display array
        }
        static void ProcessArray(int[] numbersArray)
        {
            int[] evenArray = new int[10];
            int evenIterator = 0;
            int[] oddArray = new int[10];
            int oddIterator = 0;
            int[] mergeArray = new int[10];
            int mergeIterator = 0;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] != 0)
                {
                    if (CheckEvenOrOdd(numbersArray[i]))
                    {
                        evenArray[evenIterator] = numbersArray[i];
                        evenIterator++;
                    }
                    else
                    {
                        oddArray[oddIterator] = numbersArray[i];
                        oddIterator++;
                    }
                }
            }
            
            Array.Sort(evenArray);
            Array.Sort(oddArray);

            for (int i = 0; i < oddArray.Length; i++)
            {
                if (oddArray[i] != 0)
                {
                    mergeArray[mergeIterator] = oddArray[i];
                    mergeIterator++;
                }
            }
            for (int i = 0; i < evenArray.Length; i++)
            {
                if (evenArray[i] != 0)
                {
                    mergeArray[mergeIterator] = evenArray[i];
                    mergeIterator++;
                }
            }
            DisplayArray(mergeArray); //Display array
        }
        static bool ValidateInput(string numberInput) {
            bool validation; //Declare datatypes

            //Check with try
            try
            {
                Int16.Parse(numberInput);
                validation = true;
            }
            catch
            {
                validation = false;
                Console.WriteLine("Only Numeric inputs are accepted OR \"done\" to end Numeric inputs");
            }
            return validation;
        }
        static bool CheckEvenOrOdd(int number)
        {
            bool even;
            if (number % 2 == 0)
            {
                even = true;
            }
            else
            {
                even = false;
            }
            return even;
        }
        static void DisplayArray(int[] numbersArray)
        {
            //Declare datatypes
            int evenCount = 0;
            int oddCount = 0;

            Console.WriteLine("Sorted Array:"); //Display results

            //for loop through array
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] != 0)
                {
                    Console.WriteLine($"#{i + 1}: {numbersArray[i]}");
                    if (CheckEvenOrOdd(numbersArray[i]))
                    {
                        evenCount++;
                    }
                    else
                    {
                        oddCount++;
                    }
                }
            }
            Console.WriteLine($"# of Odd Numbers: {oddCount}"); //Display results
            Console.WriteLine($"# of Even Numbers: {evenCount}"); //Display results
        }
        static void ExitProgram()
        {
            //Exit the program
            Console.WriteLine("\n  ---------------------  \n| Program will exit now |\n| Bye                   |\n  ---------------------  \n");
            Environment.Exit(0);
        }
    }
}
