﻿using System.Runtime.InteropServices;

namespace ST10178981_Thabang_Mokgonyana_PROG6221_POE
{
    internal class Program {

        //Declaring values that will be used throughout the program
        public static String[] ingredientNamesArr = new String[9];
        public static String[] recipeStepsArr = new String[9];
        public static double[] ingredientQuantArr = new double[9];
        public static String[] ingredientUnitOfMeas = new String[9];
        public static int ingredientAmount;
        public static int recipeStepsAmount;
        public static String recipeName;
        public static int p;
        double scaleIngrediants;
        




        static void Main(string[] args)
        {
            //StringBuilder made to complie list for function 2
            StringBuilder showRecipe = new StringBuilder();
            //Object declared to call the external class
            External adder = new External();
            //value to hold while loop
            p = 1;

            //While loop to make sure the program runs until the exit option is choosen
            while (p != 6)
            {
                //Chnging menu colour to blue
                Console.ForegroundColor = ConsoleColor.Blue;
                //Console menu list
                Console.WriteLine("Welcome! Please select a function below\n" +
                    "1. Record the ingredients and steps.\n" +
                    "2. Display the full recipe\n" +
                    "3. Scale the unit of measurement\n" +
                    "4. Reset the changed scale\n" +
                    "5. Clear recipe\n" +
                    "6. Exit application");
                //int value used to track which option the user selected
                int function = int.Parse(Console.ReadLine());

                //if statement tied to above integer value to execute the desired menu option
                if (function == 1)
                {
                    //internal coour of function changed to cyan
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Asking user for set value and calling external int to retrieve the value and store it
                    Console.WriteLine("Enter the number of ingredients");
                    adder.setingredientAmount(Convert.ToInt32(Console.ReadLine());

                    //for loop iterting the desired output message prompting the user to enter values and storing them accoding to the above given value
                    for (int i = 0; i < setingredientAmount; i++)
                    {

                        Console.WriteLine("Enter the name of the ingredient");
                        
                        ingredientNamesArr[i] = Console.ReadLine();


                        Console.WriteLine("Enter the Quantity of the ingredient");

                        ingredientQuantArr[i] = Convert.ToDouble(Console.ReadLine());


                        Console.WriteLine("Enter the Unit of measurement(kg,ml,g,l)");

                        ingredientUnitOfMeas[i] = Console.ReadLine();

                    }

                    //Changing colour once again to gray
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Asking user for set value and calling external int to retrieve the value and store it
                    Console.WriteLine("Enter the number of steps for the recipe");

                    adder.setrecipeStepsAmount(Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < adder.setrecipeStepsAmount(); i++)
                    {

                        Console.WriteLine("Enter description for Ingredient " + (i + 1));

                        recipeStepsArr[i] = Console.ReadLine();
                    }
                } else if (function == 2)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Creating blank string value to store and display the string builder
                    string Recipte = "";
                    
                    for (int i = 0; i < adder.setingredientAmount(); i++)
                    {
                        if (ingredientNamesArr[i] == null && ingredientQuantArr[i] == null)
                        {
                            Console.WriteLine("No ingredients or recipes added!");
                        }
                        else
                        {


                            for (int i = 0; i < setingredientAmount(); i++)
                            {

                                showRecipe.Append("Item Name: " + ingredientNamesArr[i] + "\n" +
                                "Item Quantity: " + ingredientQuantArr[i] + ingredientUnitOfMeas + "\n");
                            }

                            for (int i = 0; i < recipeStepsAmount; i++)
                            {

                                showRecipe.Append("Steps to make the recipe:\n" +
                                "Step " + i + " : " + recipeStepsArr[i] + "\n");
                            }
                        }
                    }

                    Console.WriteLine(showRecipe.ToString());
                    Console.ReadLine();

                }
                
                }
                

            }

        }
    }
}