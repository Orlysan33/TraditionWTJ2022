using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RecipeItem 
{
    [SerializeField]
    private IngredientScriptable ingredient;

    [SerializeField]
    private int ingredientQuantity;


    public IngredientScriptable Ingredient => ingredient;

    public int IngredientQuantity => ingredientQuantity;
}
