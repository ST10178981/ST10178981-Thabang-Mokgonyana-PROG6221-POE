using System;

public class External
{


    public External()
    {
        //declaring private ints to call in the main method and solution
        private int ingredientAmount;
        private int ingredientType;
        private int scaleOption;

        //Method to retrieve value for private int 1 above

        public void setIngredientAmount(int ingredientSum)
        {
            this.ingredientAmount = ingredientSum;
        }

        public int getIngredientAmount()
        {
            return this.ingredientAmount
        }

    //Method to retrieve value for private int 2 above
    public void setrecipeStepsAmount(int recipeList)
    {
        this.recipeStepsAmountt = recipeList;
    }
    
    public int getIngredientAmount()
    {
        return this.recipeStepsAmount
        }

    //Method to retrieve value for private int 3 above
    public void setScaleOption(int scaleChoice)
    {
        this.scaleOption = scaleChoice;
    }

    public int getscaleOption()
    {
        return this.scaleOption
        }

}





}


