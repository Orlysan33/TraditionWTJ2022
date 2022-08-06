using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameIngredientManager : MonoBehaviour
{
    [SerializeField]
    private ItemUI prefab;

    List<ItemUI> currentUIItems;

    [SerializeField]
    private Image imagePrefab;

    private IngredientScriptable currentPickedItem;

    private void Start()
    {
        currentPickedItem = null;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PickUpItem();
        }
    }  

    private void DropItem()
    {

    }

    private void PickUpItem()
    {

        //Ray ray;
        //RaycastHit hit;
        //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //var direction = Camera.main.ScreenToWorldPoint(mousePosition);
        //var rayCast = Physics2D.Raycast(mousePosition, direction);
        //if (rayCast.transform != null)
        //{
        //    var itemUI = rayCast.transform.GetComponent<ItemUI>();
        //    if (itemUI != null)
        //    {

        //    }
        //}

   
    }

 




    private void ResetChilds()
    {
        var childs = this.GetComponentsInChildren<ItemUI>();
        for (int i = 0; i < childs.Length; i++)
        {
            Destroy(childs[i].gameObject);
        }
        if(currentUIItems==null)
        {
            currentUIItems = new List<ItemUI>();
        }
        currentUIItems.Clear();
    }


    public void SetNewRecipe(CookingRecipe recipe)
    {
        ResetChilds();
        for (int i = 0; i < recipe.RequiredIngredients.Length; i++)
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
