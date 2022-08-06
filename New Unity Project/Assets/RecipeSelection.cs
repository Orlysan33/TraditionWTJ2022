using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSelection : MonoBehaviour
{
    [SerializeField]
    private CraftRecipeItemUI prefab;

    List<CraftRecipeItemUI> currentUIItems;
    void Start()
    {
        currentUIItems = new List<CraftRecipeItemUI>();
        ResetChilds();
        LoadRecipes();
    }


    private void ResetChilds()
    {
        var childs = this.GetComponentsInChildren<CraftRecipeItemUI>();
        for (int i = 0; i < childs.Length; i++)
        {
            Destroy(childs[i].gameObject);
        }
        currentUIItems.Clear();
    }


    public void LoadRecipes()
    {
        var recipes = Resources.LoadAll<CookingRecipe>("Recipes");
        for (int i = 0; i < recipes.Length; i++)
        {           
           var item = Instantiate(prefab, this.transform);
           currentUIItems.Add(item);
           item.SetItem(recipes[i]);
        }
    }




}
