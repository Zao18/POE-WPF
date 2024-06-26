﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POE_WPF.Ingredient;

namespace POE_WPF
{
    public class IngredientDB
    {
            //Stores the lists of ingredients
            private SortedList<string, Ingredient> ingredientList = new SortedList<string, Ingredient>();

            //Stores the lists of steps
            private SortedList<int, Steps> stepsList = new SortedList<int, Steps>();

            //Method adds a new ingredient to the list
            public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
            {
                Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                ingredientList[name] = (ingredient);
            }

            //Method retrives the ingredients
            public List<Ingredient> GetAllIngredients()
            {
                return ingredientList.Values.ToList();
            }

            //Method Adds a step to the list
            public void AddStep(string stepDescription)
            {
                int stepNumber = stepsList.Count + 1;

                Steps step = new Steps(stepDescription);
                stepsList[stepNumber] = (step);
            }

            //Method retrives the steps
            internal List<Steps> GetAllSteps()
            {
                return stepsList.Values.ToList();
            }

            //Method clears the ingredients list
            public void ClearIngredients()
            {
                ingredientList.Clear(); //(stackoverflow, 2011)
            }

            //Method clears the steps list
            public void ClearSteps()
            {
                stepsList.Clear(); //(stackoverflow, 2011)
            }
        }
    }
