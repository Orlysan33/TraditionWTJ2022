using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDropZone : MonoBehaviour
{
    private IngredientScriptable ingredient;

    [SerializeField]
    private SpriteRenderer image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewItem(IngredientScriptable newIngredient)
    {
        ingredient = newIngredient;
        image.sprite = newIngredient.Icon;
    }
}
