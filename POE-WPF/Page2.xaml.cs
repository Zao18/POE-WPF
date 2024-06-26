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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private MainWindow mainWindow;
        public Page2(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void btnSubmit2_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtQuantity.Text, out double quantity) && double.TryParse(txtCalories.Text, out double calories))
            {
                string name = txtName.Text;
                string unit = txtUnit.Text;
                string foodGroup = ((ComboBoxItem)cbFoodGroup.SelectedItem).Content.ToString();

                mainWindow.ingredientDB.AddIngredient(name, quantity, unit, calories, foodGroup);
                string recipeName = mainWindow.recipeDB.GetAllRecipes().Last().Name;
                mainWindow.recipeDB.AddIngredientToRecipe(recipeName, name, quantity, unit, calories, foodGroup);

                txtName.Text = "";
                txtQuantity.Text = "";
                txtUnit.Text = "";
                txtCalories.Text = "";
                cbFoodGroup.SelectedIndex = 0;

                if (mainWindow.ingredientDB.GetAllIngredients().Count >= mainWindow.numOfIngredients)
                {
                    double totalCalories = mainWindow.TotalCalories(mainWindow.ingredientDB.GetAllIngredients());
                    if (totalCalories >= 300)
                    {
                        MessageBox.Show("The total calories exceed 300");
                    }

                    mainWindow.NavigateTo(new Page3(mainWindow));
                }
            }
            else
            {
                MessageBox.Show("Please Enter Valid Numbers");
            }
        }
    }
}
