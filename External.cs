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

    public void recipeName(List<String> recipeNames, int recipeNameCount)
    {

        for (int i = 0; i < recipeNameCount; i++)
        {
            Console.WriteLine("Please enter the name of the recipe");
            recipeNames.Add(Console.ReadLine());
        }

    }


    }

