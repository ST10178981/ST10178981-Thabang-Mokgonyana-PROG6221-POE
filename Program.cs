using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using System.Xml.Linq;

namespace ST10178981_Thabang_Mokgonyana_PROG6221_POE
{
    internal class Program
    {

        //Declaring values that will be used throughout the program
        static int ingredientAmount;
        static int recipeStepsAmount;
        static int p;
        static int scaleOption;
        static double scaleIngrediants;
        static List<String> recipeNames = new List<String>();
        static int recipeNameCount;
        static float factor;
        static string name;
        static int quantity;
        static UnitOfMeasurement unit;
        static int calories;
        static FoodGroup foodGroup;
        static string description;
        static int stepNumber;





        //main program that houses the console and 
        static void Main(string[] args)
        {
            //List object that forms the backbone of the new program
            List<Recipe> recipes = new List<Recipe>();

            //Object declared to call the external class
            External adder = new External();

            Recipe recipe = new Recipe();
            
            
            //value to hold while loop
            p = 1;

            //While loop to make sure the program runs until the exit option is choosen
            
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("WELCOME TO THE RECIPE LOGGING APPLICATION");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=========================================================");
            //Chnging menu colour to white
            while (p != 7)
            {
                Console.ForegroundColor = ConsoleColor.White;
                //Console menu list
                Console.WriteLine("Please select a function below\n" +
                    "1. Record the ingredients and steps.\n" +
                    "2. Display the full recipe\n" +
                    "3. Scale the unit of measurement\n" +
                    "4. Reset the changed scale\n" +
                    "5. Clear recipes\n" +
                    "6. Calcualte total calories\n" +
                    "7. Exit application");
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
                        Console.WriteLine("How many ingredients do you wish to log for recipe " + name);
                        ingredientAmount = Convert.ToInt32(Console.ReadLine());
                        
                        for(int i = 0; i < ingredientAmount; i++)
                        {
                            recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
                        }

                        Console.WriteLine("How many steps are are need for recipe " + name);
                        recipeStepsAmount = Convert.ToInt32(Console.ReadLine());

                        for(int i = 0; i < recipeStepsAmount; i++)
                        {
                            recipe.AddStep(stepNumber, description);
                        }

                    }


                }
                else if (function == 2)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    recipeNames.Sort();

                    foreach(String name in recipeNames)
                    {
                        DisplayRecipes(recipes);
                    }


                }
                else if (function == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Please enter");
                    foreach (String name in recipeNames)
                    {
                        recipe.ScaledRecipe(factor);
                    }
                }
                else if (function == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    recipe.ResetQuantities();

                }
                else if (function == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You are aboout to clear the contents of your recipes. Are you sure you wish to delete all the recipes\n\n");
                    Console.WriteLine("Press Y if you wish to proceed. Press anything else to return to the console menu.");
                    String delChoice = Console.ReadLine();

                    if (delChoice.Equals("y"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        recipes.ToList().Clear();

                        
                        Console.WriteLine("Recipes have been cleared");
                        
                    }
                    else
                    {
                        return;
                    }
                }
                else if (function == 6)
                {
                    recipe.CalculateTotalCalories();
                }
                else if (function == 7)
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
            Console.WriteLine("-----Recipes-----");
            List<string> sortedRecipeNames = recipes.Select(r => r.GetName()).OrderBy(name => name).ToList();
            foreach (string name in sortedRecipeNames)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(name);
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the name of the recipe to display details:");
            string recipeName = Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Cyan;
            Recipe selectedRecipe = recipes.FirstOrDefault(recipe => recipe.GetName() == recipeName);
            if (selectedRecipe == null)
            {
                Console.WriteLine($"No recipe found with name: {recipeName}");
                return;
            }

            Console.WriteLine(selectedRecipe.ToString());
            foreach(Recipe recipe in recipes)
            {
                recipe.GetRecipeString();
            }
        }
    }
}

    internal class Recipe
    {
        public Recipe()
        {

        }

        string name;
        List<Ingredient> ingredients;
        List<RecipeStep> steps;

        public event Action<string> ExceededCalories;
        //Constructor
        Recipe(string name)
        {
            this.name = name;
            ingredients = new List<Ingredient>();
            steps = new List<RecipeStep>();
        }
        //Add ingredient method

        public void AddIngredient(string name, float quantity, UnitOfMeasurement unit, int calories, FoodGroup foodGroup)
        {
            Console.WriteLine("Enter the name of ingredient");
            name= Console.ReadLine();

            Console.WriteLine("Enter the quantity of the ingredient");
            quantity = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name Unit of mesurement(Select 1- 6 for one of the following units: Teaspoon, Tablespoon, Cup, Gram, Ounce, Pound)");
            int unitChoice = int.Parse(Console.ReadLine());
            if(unitChoice == 1)
            {
                unit = UnitOfMeasurement.Teaspoon;
            }else if(unitChoice == 2)
            {
                unit = UnitOfMeasurement.Tablespoon;
            }
            else if (unitChoice == 3)
            {
                unit = UnitOfMeasurement.Cup;
            }
            else if (unitChoice == 4)
            {
                unit = UnitOfMeasurement.Gram;
            }
            else if (unitChoice == 5)
            {
                unit = UnitOfMeasurement.Ounce;
            }
            else if (unitChoice == 6)
            {
            unit = UnitOfMeasurement.Pound;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }


            Console.WriteLine("Enter the name of ingredient");
            calories = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the food group of the ingredient(Dairy, Fruit, Grain, Protein, Vegetable)");
            int foodChoice = int.Parse(Console.ReadLine());
            if (foodChoice == 1)
            {
                foodGroup = FoodGroup.Vegetable;
            }
            else if (foodChoice == 2)
            {
                foodGroup = FoodGroup.Fruit;
            }
            else if (foodChoice == 3)
            {
                foodGroup = FoodGroup.Grain;
            }
            else if (foodChoice == 4)
            {
                foodGroup = FoodGroup.Protein;
            }
            else if (foodChoice == 5)
            {
                foodGroup = FoodGroup.Vegetable;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

        Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);
        }
        //Add recipe step method
        public void AddStep(int stepNumber, string description)
        {
            RecipeStep step = new RecipeStep(stepNumber, description);
            Console.WriteLine("Enter step{i+1}");
            steps.Add(step);
        }
        //method to calculate the total calories
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.CalculateCalories();
            }
            return totalCalories;
        }
        // method to scale the recipes
        public Recipe ScaledRecipe(float factor)
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
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
        //Get recipe string method
        public string GetRecipeString()
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
    public void deleteLists()
    {
        foreach(Ingredient ingredient in ingredients)
        {
            
        }

        foreach(RecipeStep step in steps)
        {
            ;
        }
    }


        public string GetName()
        {
            return name;
        }
    }

        internal class Ingredient
        {
            public Ingredient()
            {

            }
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
                return name + ": " + quantity + " " + unit + ", " + caloriesPerUnit + " kcal, " + foodGroup;
            }
        }

        //RecipeStep class
        internal class RecipeStep
        {
            public RecipeStep()
            {

            }
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
            Teaspoon = 1,
            Tablespoon = 2,
            Cup = 3,
            Gram = 4,
            Ounce = 5,
            Pound = 6
        }
        //Food group enum
        enum FoodGroup
        {
            Dairy = 1,
            Fruit = 2,
            Grain = 3,
            Protein = 4,
            Vegetable = 5
        }


  
