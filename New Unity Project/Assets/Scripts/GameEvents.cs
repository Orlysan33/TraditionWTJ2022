using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;


    //public static GameEvents current
    //{
    //    get
    //    {
    //        if (_current == null)
    //        {
    //            _current = Instantiate(Resources.Load<GameEvents>("GameEvents"));
    //        }
    //        return _current;
    //    }
    //}



    public event Action<string> onPlayerInteractionAvailable;
    public event Action onPlayerInteractionExit;

    public event Action<IngredientScriptable> onPlayerIngredientPickUp;

    public event Action<CookingRecipe> onPlayerRecipePickUp;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {

    }


    public void PlayerInteraction(string interactionName)
    {
        if (onPlayerInteractionAvailable != null)
        {
            onPlayerInteractionAvailable(interactionName);
        }
    }

    public void PlayerInteractionExit()
    {
        if (onPlayerInteractionExit != null)
        {
            onPlayerInteractionExit();
        }
    }

    public void PlayerIngredientPickUp(IngredientScriptable ingredient)
    {
        if (onPlayerIngredientPickUp != null)
        {
            onPlayerIngredientPickUp(ingredient);
        }
    }

    public void PlayerRecipePickUp(CookingRecipe recipe)
    {
        if (onPlayerRecipePickUp != null)
        {
            onPlayerRecipePickUp(recipe);
        }
    }


    
}
