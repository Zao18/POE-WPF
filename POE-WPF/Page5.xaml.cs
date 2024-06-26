using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE_WPF
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        private MainWindow mainWindow;
        public Page5(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            DisplayRecipe();
        }

        private void DisplayRecipe()
        {
            string recipeText = "Recipe:\r\nIngredients:\r\n";

            // Get all ingredients from ingredientDB in mainWindow
            List<Ingredient> ingredients = mainWindow.ingredientDB.GetAllIngredients();

            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient.Quantity == 16 && ingredient.Unit == "teaspoons")
                {
                    recipeText += $"1 cup of {ingredient.Name}\r\n";
                }
                else
                {
                    recipeText += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} with {ingredient.Calories} calories and is a {ingredient.FoodGroup} product\r\n";
                }
            }

            recipeText += "\r\nSteps:\r\n";

            // Get all steps from ingredientDB in mainWindow
            List<Steps> steps = mainWindow.ingredientDB.GetAllSteps();

            int stepNumber = 1;
            foreach (Steps step in steps)
            {
                recipeText += $"Step {stepNumber}:\n {step.Step}\r\n";
                stepNumber++;
            }

            txtDisplay.Text = recipeText;
        }
    }
}
