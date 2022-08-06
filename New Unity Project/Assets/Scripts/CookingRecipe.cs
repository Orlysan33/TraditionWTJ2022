using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CookingRecipe")]
public class CookingRecipe : ScriptableObject
{
    [SerializeField]
    private RecipeItem[] requiredIngredients;

    [SerializeField]
    private RecipeItem cookedRecipeItem;

    public RecipeItem[] RequiredIngredients => requiredIngredients;

    public RecipeItem CookedRecipeItem => cookedRecipeItem;

}
