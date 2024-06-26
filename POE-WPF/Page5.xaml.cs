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
            mainWindow = mainWindow;
        }

        private void DisplayRecipe()
        {
            string recipeText = "Recipe:\r\nIngredients:\r\n";

            // Get the current recipe from the MainWindow
            Recipe currentRecipe = mainWindow.CurrentRecipe;

            if (currentRecipe != null)
            {
                // Display recipe name
                recipeText += $"{currentRecipe.Name}\r\n\r\n";

                // Display ingredients
                foreach (var ingredient in currentRecipe.Ingredients)
                {
                    recipeText += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}\r\n";
                }

                // Display steps
                recipeText += "\r\nSteps:\r\n";
                int stepNumber = 1;
                foreach (var step in currentRecipe.Steps)
                {
                    recipeText += $"{stepNumber}. {step.Description}\r\n";
                    stepNumber++;
                }
            }

            // Display the recipe text in a TextBox or another control
            txtDisplay.Text = recipeText;
        }
    }
}
