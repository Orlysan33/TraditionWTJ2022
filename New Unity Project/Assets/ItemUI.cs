using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Image image;  

    private bool itemRequired;

    [SerializeField]
    private IngredientScriptable requiredIngredient;
    void Start()
    {
        itemRequired = true;   
    }


    public void SetItem(IngredientScriptable ingredient)
    {
        image.sprite = ingredient.Icon;
        requiredIngredient = ingredient;
        itemRequired = ingredient.Quantity ==0;   
        UpdateImageOpacity(!itemRequired);
    }

    public bool ItemPickUp(IngredientScriptable ingredient)
    {
        var allowPickUp = (ingredient == requiredIngredient) && itemRequired;

        if (allowPickUp)
        {
            UpdateImageOpacity(true);       
        }
        return allowPickUp;
    }

    private void UpdateImageOpacity(bool showImage)
    {
        if(showImage)
        {
            itemRequired = false;
            var color = image.color;
            color.a = 1;
            image.color = color;
        }
        else
        {
            var color = image.color;
            color.a = 0.45f;
            image.color = color;
        }
    }

    
}
