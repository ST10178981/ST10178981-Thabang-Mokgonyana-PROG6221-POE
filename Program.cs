using System.Runtime.InteropServices;

namespace ST10178981_Thabang_Mokgonyana_PROG6221_POE
{
    internal class Program {

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
            StringBuilder showRecipe = new StringBuilder();
            External adder = new External();
            p = 1;

            while (p != 6)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome! Please select a function below\n" +
                    "1. Record the ingredients and steps.\n" +
                    "2. Display the full recipe\n" +
                    "3. Scale the unit of measurement\n" +
                    "4. Reset the changed scale\n" +
                    "5. Clear recipe\n" +
                    "6. Exit application");
                int function = int.Parse(Console.ReadLine());

                if (function == 1)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter the number of ingredients");
                    adder.setingredientAmount(Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < setingredientAmount; i++)
                    {

                        Console.WriteLine("Enter the name of the ingredient");
                        
                        ingredientNamesArr[i] = Console.ReadLine();


                        Console.WriteLine("Enter the Quantity of the ingredient");

                        ingredientQuantArr[i] = Convert.ToDouble(Console.ReadLine());


                        Console.WriteLine("Enter the Unit of measurement(kg,ml,g,l)");

                        ingredientUnitOfMeas[i] = Console.ReadLine();

                    }

                    Console.ForegroundColor = ConsoleColor.Red;
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
                else if (function == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    
                    Console.WriteLine("Please the pick the scale option you wish Use\n" +
                        "1. O.5(Half)\n" +
                        "2. 2(Double)\n" +
                        "3. 3(Triple)");
                    adder.scaleOption(int.Parse(Console.ReadLine());
                    for (int i = 0; i < ingredientAmoun; i++)
                    {
                        if (scaleOption == 1)
                        {
                            scaleIngrediants = ingredientQuantArr[i] * 0,5;
                            Console.WriteLine("Scale has been halved");
                            Console.ReadLine();
                        }
                        else if (scaleOption == 2)
                        {
                            scaleIngrediants = ingredientQuantArr[i] * 2;
                            Console.WriteLine("Quantity has been doubled");
                            Console.ReadLine();
                        }
                        else if (scaleOption == 3)
                        {
                            scaleIngrediants = ingredientQuantArr[i] * 3;
                            Console.WriteLine("Quantity has been Tripled");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                else if (function == 4)
                {
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < ingredientQuantArr.Length; i++)
                        {
                            ingredientQuantArr
                        }
                    
                } else if (function == 5)
                {
                        ingredientNamesArr = new string[0];
                        recipeStepsArr = new string[0];
                        ingredientQuantArr = new double[0];
                        ingredientUnitOfMeas = new string[0];

                        Conole.WriteLine("Items cleared");
                        Console.ReadLine();
                    } else if (function == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not valid");
                    Console.ReadLine();
                }
                

            }

        }
    }
}