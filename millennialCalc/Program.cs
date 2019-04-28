using System;

namespace millennialCalc
{
    class Program
    {
 
            // // // // // // // // // // // // // // // // // // // // // 
            //   MILLENNIAL BUDGET CALC v1.0                            
            //                   
            //   Console application for assessing monthly expenses
            //   
            //   by: Brinda Earnest                 
            //                                      
            //   newest version date: 4.27.19       
            //                                      
            //   (CIT 110 Capstone Project)         
            // // // // // // // // // // // // // // // // // // // // // 

        static void Main(string[] args)
        {

            Console.WriteLine("BUDGET CALCULATOR v.1.0");
            Console.WriteLine();
            Console.WriteLine("\tFor young folks with (some) cash $");
            Console.WriteLine();
            Console.WriteLine("\tLet's get started on your 50/30/20 Budget!");
            Console.WriteLine();
            Console.WriteLine("We'll need information on your monthly income & bills...");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();

            DisplayMenu();

        }

        static void DisplayMenu()
        {
            bool exiting = false;
            string menuChoice;
            double userBills = 0;
            double userIncome = 0;
            double userRent = 0;
            double userCC = 0;
            double userBillsTotal = 0;

            // The Menu //

            while (!exiting)
            {
                Console.Clear();
                Console.WriteLine("Please select from the following options: ");
                Console.WriteLine();
                Console.WriteLine("1) Get Started!");
                Console.WriteLine();
                // Console.WriteLine("2) Next: Establish Savings");
                //Console.WriteLine();
                Console.WriteLine("E) Exit");
                Console.WriteLine();
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        userBills = DisplayUserBills();
                        userRent = DisplayUserRent();
                        userCC = DisplayUserCreditCard();
                        CalculateUserBillsTotal(userCC, userBills, userRent, userIncome);
                        // userIncome = DisplayEstablishIncome(userBillsTotal1);
                        break;
                    case "2":
                        // CalculateReport(userIncome, userBillsTotal);
                        DisplaySavingsAmount(userIncome, userBillsTotal);
                        //DisplayTotalSavings(userBillsTotal, userIncome);
                        //DisplayOverSpending(userBillsTotal, userIncome);
                        break;
                    case "E":
                    case "e":
                        DisplayExitScreen();
                        exiting = true;
                        break;
                    default:
                        Console.WriteLine("Please select option 1 or option 2.");
                        DisplayContinuePrompt();
                        break;
                }

            }


        }

        //static double DisplayOverSpending(double userBillsTotal, double userIncome)
        //{
        //    double billsMax = (userIncome * 0.5);
        //    double overSpend = userBillsTotal - billsMax;

        //    Console.WriteLine($"{ overSpend}");
        //    DisplayContinuePrompt();

        //   return overSpend;
        //}

        static void DisplayExitScreen()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using my application!");
            Console.WriteLine();
            Console.WriteLine("NOTE: 50/30/20 scheme based on calculations from \"All Your Worth\" by Senator Elizabeth Warren");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static double DisplayUserBills()
        {

            Console.Clear();

            Console.WriteLine("\tHow much do you pay total each month for the following?");
            Console.WriteLine("\t(NOTE: enter numeric values without commas or symbols)");
            Console.WriteLine();
            Console.WriteLine("UTILITIES: (including gas, electricity, water, sewer, trash, propane): ");
            //userBills = double.Parse(Console.ReadLine());
            var userInput = Console.ReadLine();
            double userBills;
            while (!double.TryParse(userInput, out userBills))
            {
                Console.WriteLine("Please enter a numerical value");
                userInput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Total utility bills: ${userBills}");

            DisplayContinuePrompt();


            return userBills;
        }

        static double DisplayUserRent()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Rent or Mortgage: ");

            var userInput = Console.ReadLine();
            double userRent;
            while (!double.TryParse(userInput, out userRent))
            {
                Console.WriteLine("Please enter a numerical value");
                userInput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Total Monthly Housing Cost: ${userRent}");

            DisplayContinuePrompt();

            return userRent;

        }

        static double DisplayUserCreditCard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Monthly minimum credit card payments: ");

            var userInput = Console.ReadLine();
            double userCC;
            while (!double.TryParse(userInput, out userCC))
            {
                Console.WriteLine("Please enter a numerical value");
                userInput = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Total Monthly Minimum Credit Payments: ${userCC}");

            DisplayContinuePrompt();

            return userCC;
        }

        static double DisplayEstablishIncome(double userBillsTotal1)
        {
            Console.Clear();
            Console.WriteLine("Your Income-");
            Console.WriteLine("\tPlease enter number values as prompted without commas or symbols.");
            Console.WriteLine();
            Console.WriteLine("\tNOTE: Income values are after taxes.");
            Console.WriteLine();
            Console.WriteLine("What is your monthly income?");

            var userInput = Console.ReadLine();
            double userIncome;
            while (!double.TryParse(userInput, out userIncome))
            {
                Console.WriteLine("Please enter a numerical value");
                userInput = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Monthly Income:${userIncome}");

            CalculateReport(userIncome, userBillsTotal1);

            return userIncome;

        }

        static double CalculateUserBillsTotal(double userCC, double userBills, double userRent, double userIncome)
        {

            double.TryParse(Console.ReadLine(), out double userBillsTotal);
            double userBillsTotal1 = userBillsTotal;
            userBillsTotal1 = userBills + userRent + userCC;
            Console.WriteLine();
            Console.WriteLine($"Your total monthly bill payments are ${userBillsTotal1}.");

            DisplayEstablishIncome(userBillsTotal1);


            return userBillsTotal1;


        }

        static double CalculateReport(double userIncome, double userBillsTotal1)
        {
            Console.Clear();

            double fiftyPercent;
            double thirtyPercent;
            double twentyPercent;

            Console.WriteLine($"\tBased on your reported income of ${userIncome}");
            Console.WriteLine($"\tAnd your reported bills of ${userBillsTotal1}");
            Console.WriteLine();

            fiftyPercent = userIncome * 0.5;

            Console.WriteLine();
            Console.WriteLine($"${fiftyPercent} is how much you should spend on NECESSITIES:");
            Console.WriteLine("\tThis includes housing, transportation, utilities, food, and insurance.");
            Console.WriteLine();

            thirtyPercent = userIncome * 0.3;
            twentyPercent = userIncome * 0.2;

            Console.WriteLine();

            if (userBillsTotal1 >= fiftyPercent)
            {
                Console.WriteLine("It appears that you are spending over the recommended 50% of your income on bills & necessities.");
                Console.WriteLine($"\tIt recommended that you spend ${thirtyPercent} of your income on rent.");
                Console.WriteLine($"\tAnd use the remaining ${twentyPercent} on bills & groceries");
                double overSpend = userBillsTotal1 - (thirtyPercent + twentyPercent);
                Console.WriteLine($"\tYou are overspending by ${overSpend}");

            }

            else
            {
                Console.WriteLine("Great job, it appears you are keeping your bills & necessities payments under 50% of your income!");
                Console.WriteLine($"\tYour recommendation is to not exceed ${thirtyPercent} to pay rent.");
                Console.WriteLine($"\tUse the remaining ${twentyPercent} on bills & groceries.");
                double extraSavings = (thirtyPercent + twentyPercent) - userBillsTotal1;
                Console.WriteLine($"\tYou are saving an extra ${extraSavings}");
                Console.WriteLine();
                Console.WriteLine($"Because you earned it, you have ${thirtyPercent} to allocate towards WANTS:");
                Console.WriteLine("\tThese include entertainment, extracurricular activities, travel, memberships, and pats on the back.");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DisplaySavingsAmount(userIncome, userBillsTotal1);

            return userIncome;

        }

        //static double DisplayTotalSavings(double userBillsTotal, double userIncome)
        //{

        //   double billsMax = (userIncome*0.5);
        //   double excess = billsMax - userBillsTotal;

        //   Console.WriteLine($"{ excess}");
        //   DisplayContinuePrompt();

        //   return excess;
        //}

        static void DisplaySavingsAmount(double userIncome, double userBillsTotal1)
        {

            double twentyPercent;

            Console.Clear();
            Console.WriteLine("Finally, it is of vital importance that you set aside 20% of your income towards savings.");
            Console.WriteLine("\tOr else, use it for debt reduction or investments.");
            Console.WriteLine();
            Console.WriteLine("How much do you save on a monthly basis?");

            var userInput = Console.ReadLine();
            double userSavings;
            while (!double.TryParse(userInput, out userSavings))
            {
                Console.WriteLine("Please enter a numerical value");
                userInput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine($"{userSavings}");
            twentyPercent = userIncome * 0.19;

            if (userIncome <= userBillsTotal1 + userSavings)
            {
                Console.WriteLine("It appears that you've entered an incorrect amount...");
                Console.WriteLine("You are saving more than you earn!");
            }

            else if (twentyPercent >= userSavings)
            {
                Console.WriteLine();
                Console.WriteLine("It appears that you aren't saving enough per month. I know it can be tough!");
                Console.WriteLine($"\tIt takes as little as ${twentyPercent} with your income to create a strong savings!");
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("It appears that you are already saving responsibly.");
                Console.WriteLine("\tConsider making some investments to boost your return on value and your income!");
            }

            DisplayContinuePrompt();

        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

