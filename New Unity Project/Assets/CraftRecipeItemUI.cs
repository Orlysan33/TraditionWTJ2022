using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftRecipeItemUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private bool itemRequired;

    [SerializeField]
    private CookingRecipe cookingRecipe;

    [SerializeField]
    private TextMeshProUGUI textCookingRecipe;


    void Start()
    {
        itemRequired = true;
    }


    public void SetItem(CookingRecipe recipe)
    {
        cookingRecipe = recipe;
        textCookingRecipe.text = recipe.CookedRecipeItem.Ingredient.Name;
        image.sprite = recipe.CookedRecipeItem.Ingredient.Icon;
    }


    public void SelectRecipe()
    {
        GameEvents.current.PlayerRecipePickUp(cookingRecipe);
    }



}
