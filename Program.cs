using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ST10178981_Thabang_Mokgonyana_PROG6221_POE
{
    internal class Program
    {

        //Declaring values that will be used throughout the program
        /*static String[] ingredientNamesArr = new String[9];
        static String[] recipeStepsArr = new String[9];
        static double[] ingredientQuantArr = new double[9];
        static String[] ingredientUnitOfMeas = new String[9];*/
        static int ingredientAmount;
        static int recipeStepsAmount;
        static int p;
        static int scaleOption;
        static double scaleIngrediants;
        static String r;
        static string name;
        static List<String> recipeNames = new List<String>();
        static int recipeNameCount;
        static StringBuilder showRecipe = new StringBuilder();




        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            //StringBuilder made to complie list for function 2

            //Object declared to call the external class
            External adder = new External();


            //value to hold while loop
            p = 1;

            //While loop to make sure the program runs until the exit option is choosen
            while (p != 6)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("WELCOME TO THE RECIPE LOGGING APPLICATION");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=========================================================");
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
                        
                    }


                }
                else if (function == 2)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    DisplayRecipes(recipes);


                }
                else if (function == 3)
                {
                    
                }
                else if (function == 4)
                {
                    


                }
                else if (function == 5)
                {

                }
                else if (function == 6)
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

        static void DisplayRecipes(List<Recipe> recipes)
        {

            Console.WriteLine("============================================================");
            Console.WriteLine("                            Recipes");
            Console.WriteLine("============================================================");
            List<string> sortedRecipeNames = recipes.Select(r => r.GetName()).OrderBy(name => name).ToList();
            foreach (string name in sortedRecipeNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Enter the name of the recipe to display details:");
            string recipeName = Console.ReadLine();
            if (string.IsNullOrEmpty(recipeName))
                return;

            Recipe selectedRecipe = recipes.FirstOrDefault(recipe => recipe.GetName() == recipeName);
            if (selectedRecipe == null)
            {
                Console.WriteLine($"No recipe found with name: {recipeName}");
                return;
            }

            Console.WriteLine(selectedRecipe.ToString());
        }
    }

    class Recipe
    {
        string name;
        List<Ingredient> ingredients;
        List<RecipeStep> steps;
        //Constructor
        Recipe(string name)
        {
            this.name = name;
            ingredients = new List<Ingredient>();
            steps = new List<RecipeStep>();
        }
        //Add ingredient method
        void AddIngredient(string name, float quantity, UnitOfMeasurement unit, int calories, FoodGroup foodGroup)
        {
            Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);
        }
        //Add recipe step method
        void AddStep(int stepNumber, string description)
        {
            RecipeStep step = new RecipeStep(stepNumber, description);
            steps.Add(step);
        }
        //Calculate total calories method
        int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.CalculateCalories();
            }
            return totalCalories;
        }
        //Scaled recipe method
        Recipe ScaledRecipe(float factor)
        {
            Recipe scaledRecipe = new Recipe(name);
            foreach (Ingredient ingredient in ingredients)
            {
                float scaledQuantity = ingredient.quantity * factor;
                scaledRecipe.AddIngredient(ingredient.name, scaledQuantity, ingredient.unit,
                                     ingredient.caloriesPerUnit, ingredient.foodGroup);
            }
            foreach (RecipeStep step in steps)
            {
                scaledRecipe.AddStep(step.stepNumber, step.description);
            }
            return scaledRecipe;
        }
        //Reset quantities method
        void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
        //Get recipe string method
        string GetRecipeString()
        {
            string recipeString = "Name: " + name + "\n\n";
            recipeString += "Ingredients:\n";
            foreach (Ingredient ingredient in ingredients)
            {
                recipeString += ingredient.ToString() + "\n";
            }
            recipeString += "\nSteps:\n";
            foreach (RecipeStep step in steps)
            {
                recipeString += step.ToString() + "\n";
            }
            recipeString += "\nTotal Calories: " + CalculateTotalCalories();
            return recipeString;
        }

        public string GetName()
        {
            return name;
        }
    }

        class Ingredient
        {
            public string name;
            public float quantity;
            public UnitOfMeasurement unit;
            public int caloriesPerUnit;
            public FoodGroup foodGroup;
            //Constructor
            public Ingredient(string name, float quantity, UnitOfMeasurement unit, int caloriesPerUnit, FoodGroup foodGroup)
            {
                this.name = name;
                this.quantity = quantity;
                this.unit = unit;
                this.caloriesPerUnit = caloriesPerUnit;
                this.foodGroup = foodGroup;
            }
            //Calculate calories method
            public int CalculateCalories()
            {
                return caloriesPerUnit * (int)quantity;
            }
            //Reset quantity method
            public void ResetQuantity()
            {
                quantity = 1;
            }
            //To string method
            override public string ToString()
            {
                return name + ": " + quantity + " " + unit + ", " + caloriesPerUnit + " Calories, " + foodGroup;
            }
        }

        //RecipeStep class
        class RecipeStep
        {
            public int stepNumber;
            public string description;
            //Constructor
            public RecipeStep(int stepNumber, string description)
            {
                this.stepNumber = stepNumber;
                this.description = description;
            }
            //To string method
            override public string ToString()
            {
                return stepNumber + ". " + description;
            }
        }
        //Unit of measurement enum
        enum UnitOfMeasurement
        {
            Teaspoon,
            Tablespoon,
            Cup,
            Gram,
            Ounce,
            Pound
        }
        //Food group enum
        enum FoodGroup
        {
            Dairy,
            Fruit,
            Grain,
            Protein,
            Vegetable
        }
}

  
