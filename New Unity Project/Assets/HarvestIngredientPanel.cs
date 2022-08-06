using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestIngredientPanel : MonoBehaviour
{
    [SerializeField]
    private ItemUI prefab;

    List<ItemUI> currentUIItems;


    void Start()
    {
        currentUIItems = new List<ItemUI>();
        ResetChilds();
        GameEvents.current.onPlayerIngredientPickUp += PlayerPickUpItem;
        GameEvents.current.onPlayerRecipePickUp += SetNewRecipe;
    }


    private void ResetChilds()
    {
        var childs= this.GetComponentsInChildren<ItemUI>();
        for(int i=0; i < childs.Length;i++)
        {
            Destroy(childs[i].gameObject);
        }
        currentUIItems.Clear();
    }


    public void SetNewRecipe(CookingRecipe recipe)
    {
        ResetChilds();
        for (int i=0;i < recipe.RequiredIngredients.Length; i++)
        {
            if (recipe.RequiredIngredients[i].Ingredient.IsHarvesterItem)
            {
                for (int j = 0; j < recipe.RequiredIngredients[i].IngredientQuantity; j++)
                {
                    var item = Instantiate(prefab, this.transform);
                    currentUIItems.Add(item);
                    var ingredient = recipe.RequiredIngredients[i].Ingredient;
                    item.SetItem(ingredient);
                }
            }          
        }
    }

    public void PlayerPickUpItem(IngredientScriptable ingredient)
    {
        foreach(var item in currentUIItems)
        {
            if(item.ItemPickUp(ingredient))
            {
                break;
            }
        }
    }


}
