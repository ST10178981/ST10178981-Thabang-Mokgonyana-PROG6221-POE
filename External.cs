using System;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

public class External
{


    public External()
    {

    }
    
        //declaring private ints to call in the main method and solution
        private int ingredientSum;
        private int ingredientType;
        private int scaleChoice;
        private int recipeList;
        private int recipeStepsType;
        private String name;


        //Method to retrieve value for private int 1 above

        public void getIngredientAmount(int ingredientAmount)
        {
            this.ingredientSum = ingredientAmount;
        }


        //Returns and stores value for private int 1 from the main class
        public int setIngredientAmount()
        {
            return this.ingredientSum;
        }

        //Method to retrieve value for private int 2 above
        public void getrecipeStepsAmount(int recipeStepsAmount)
        {
            this.recipeList = recipeStepsAmount;
        }

        public int setrecipeStepsAmount()
        {
            return this.recipeList;
        }


        //Method to retrieve value for private int 3 above
        public void getScaleOption(int scaleOption)
        {
            this.scaleChoice = scaleOption;
        }

        //Returns and stores value for private int 1 from the main class
        public int setscaleOption()
        {
            return this.scaleChoice;
        }

        public void recipeName(List <String> recipeNames, int recipeNameCount)
        {
        
            for (int i = 0; i < recipeNameCount; i++)
            {
                Console.WriteLine("Please enter the name of the recipe");
                recipeNames.Add(Console.ReadLine());
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

    /*public void setName(string character)
    {
    this.name = character;
    }*/

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

    class Ingredient
    {
        string name;
        float quantity;
        UnitOfMeasurement unit;
        int caloriesPerUnit;
        FoodGroup foodGroup;
        //Constructor
        Ingredient(string name, float quantity, UnitOfMeasurement unit, int caloriesPerUnit, FoodGroup foodGroup)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
            this.caloriesPerUnit = caloriesPerUnit;
            this.foodGroup = foodGroup;
        }


    }

