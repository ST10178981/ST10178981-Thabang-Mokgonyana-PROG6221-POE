using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace ST10178981_Thabang_Mokgonyana_PROG6221_POE
{
    internal class Program {

        //Declaring values that will be used throughout the program
        static String[] ingredientNamesArr = new String[9];
        static String[] recipeStepsArr = new String[9];
        static double[] ingredientQuantArr = new double[9];
        static String[] ingredientUnitOfMeas = new String[9];
        static int ingredientAmount;
        static int recipeStepsAmount;
        static int p;
        static int scaleOption;
        static double scaleIngrediants;
        static string r;
        static string character;
        static List<String> recipeNames = new List<String>();
        static int recipeNameCount;
        static StringBuilder showRecipe = new StringBuilder();
        



        static void Main(string[] args)
        {
            //StringBuilder made to complie list for function 2
            
            //Object declared to call the external class
            External adder = new External();
            //value to hold while loop
            p = 1;

            //While loop to make sure the program runs until the exit option is choosen
            while (p != 6)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=====================================");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("WELCOME TO THE RECIPE LOGGING APPLICATION");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=====================================");
                //Chnging menu colour to blue
                Console.ForegroundColor = ConsoleColor.White;
                //Console menu list
                Console.WriteLine("Please select a function below\n" +
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
                    Console.WriteLine("Plaese enter the number of recipes you want to log");
                    recipeNameCount = Convert.ToInt32(Console.ReadLine());
                    adder.recipeName(recipeNames, recipeNameCount);
                    foreach (String name in recipeNames)
                    {
                        Console.WriteLine("Enter the number of ingredients");
                        adder.getIngredientAmount(ingredientAmount);
                        ingredientAmount = Convert.ToInt32(Console.ReadLine());
                        adder.setIngredientAmount();

                        //for loop iterting the desired output message prompting the user to enter values and storing them accoding to the above given value
                        for (int i = 0; i < ingredientAmount; i++)
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

                        adder.getrecipeStepsAmount(recipeStepsAmount);
                        recipeStepsAmount = Convert.ToInt32(Console.ReadLine());
                        adder.setrecipeStepsAmount();

                        for (int i = 0; i < recipeStepsAmount; i++)
                        {

                            Console.WriteLine("Enter description for Ingredient " + (i + 1));

                            recipeStepsArr[i] = Console.ReadLine();
                        }
                    }
                    
                   
                } else if (function == 2)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Creating blank string value to store and display the string builder

                    adder.setName(character);

                    Console.WriteLine("-----Recipes-----");
                    List<string> sortedRecipeNames = recipeNames.Select(r => adder.GetName()).OrderBy(name => name).ToList();
                    foreach (string name in sortedRecipeNames)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("Enter the name of the recipe to display details (or press Enter to go back):");
                    string recipeName = Console.ReadLine();
                    if (string.IsNullOrEmpty(recipeName))
                        return;

                    External selectedRecipe = recipeNames.FirstOrDefault(r => r.GetName() == recipeName);
                    if (selectedRecipe == null)
                    {
                        Console.WriteLine($"No recipe found with name: {recipeName}");
                        return;
                    }

                    Console.WriteLine(selectedRecipe.ToString());


                }
                else if (function == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //Second menu option for function 3 with third external class retrieval method
                    Console.WriteLine("Please the pick the scale option you wish Use\n" +
                        "1. O.5(Half)\n" +
                        "2. 2(Double)\n" +
                        "3. 3(Triple)");
                    adder.getScaleOption(scaleOption);
                    scaleOption = int.Parse(Console.ReadLine());
                    adder.setscaleOption();
                    //For loop to change each value within the array ingrediantuantArr by the factor of the given option
                    for (int i = 0; i < ingredientAmount; i++)
                    {
                        if (scaleOption == 1)
                        {
                            // Halfing all ingrediantuantArr with confirmation message
                            scaleIngrediants = ingredientQuantArr[i] * 0.5;
                            Console.WriteLine("Scale has been halved");
                            Console.ReadLine();
                        }
                        else if (scaleOption == 2)
                        {
                            //Doubling all ingrediantuantArr with confirmation message
                            scaleIngrediants = ingredientQuantArr[i] * 2;
                            Console.WriteLine("Quantity has been doubled");
                            Console.ReadLine();
                        }
                        else if (scaleOption == 3)
                        {
                            //Tripling all ingrediantuantArr with confirmation message
                            scaleIngrediants = ingredientQuantArr[i] * 3;
                            Console.WriteLine("Quantity has been Tripled");
                            Console.ReadLine();
                        }
                        else
                        {

                            //Message if other number is selected
                            Console.WriteLine("Invalid input");
                        }
                    }
                }
                else if (function == 4)
                {
                    //CANNOT FIND A SOULTION 
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < ingredientQuantArr.Length; i++)
                    {
                        
                        }

                } else if (function == 5)
                {
                    
                } else if (function == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Simple goodbye exit message with an enviroment exit method
                    Console.WriteLine("Goodbye");

                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not valid");

                }


                }

            }

        
    }
    }
