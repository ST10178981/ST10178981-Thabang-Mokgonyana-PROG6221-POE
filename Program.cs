using System.Runtime.InteropServices;

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
                    
                }
                

            }

        }
    }
}