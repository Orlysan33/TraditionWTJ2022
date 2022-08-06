using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine; 

public class CookingGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private CinemachineVirtualCamera virtualCameraStart;

    [SerializeField]
    private CinemachineVirtualCamera virtualCameraGame;

    [SerializeField]
    private GameObject startingCanvas;

    [SerializeField]
    private GameObject gameCanvas;

    [SerializeField]
    private GameIngredientManager gameIngredientManager;

    CookingRecipe currentRecipe;

    List<IngredientScriptable> ingredientAvailable;

    private IngredientScriptable currentActiveIngredient;

    [SerializeField]
    private GameDropZone gameDropZone;
    void Start()
    {
        ingredientAvailable = new List<IngredientScriptable>();
        startButton.interactable = false;
        GameEvents.current.onPlayerRecipePickUp += PlayerRecipeSelected;
        startingCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRecipeSelected( CookingRecipe recipe)
    {
        bool gameAvailable = true;
        for(int i=0; i < recipe.RequiredIngredients.Length; i++)
        {
            var ingredient = recipe.RequiredIngredients[i].Ingredient;
            if (ingredient.IsHarvesterItem && ingredient.Quantity <= 0)
            {
                gameAvailable = false;
                break;
            }
        }
        startButton.interactable = gameAvailable;
        currentRecipe = recipe;
    }

    public void StartGame()
    {
        currentActiveIngredient = null;
        ingredientAvailable = new List<IngredientScriptable>();
        gameIngredientManager.SetNewRecipe(currentRecipe);
        virtualCameraGame.gameObject.SetActive(true);
        startingCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        StartCoroutine(TurnOffCameraDelay(virtualCameraStart));
        FillGameData();
        SelectNewDropZoneItem();
        gameDropZone.gameObject.SetActive(true);
    }

    private void FillGameData()
    {
        for (int i = 0; i < currentRecipe.RequiredIngredients.Length; i++)
        {
            ingredientAvailable.Add(currentRecipe.RequiredIngredients[i].Ingredient);
        }
        
    }


    public void CancelGame()
    {
        startingCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        startButton.interactable = false;
        virtualCameraStart.gameObject.SetActive(true);
        StartCoroutine(TurnOffCameraDelay(virtualCameraGame));
        gameDropZone.gameObject.SetActive(false);
    }

    public void EndGame(bool win)
    {
        startingCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        startButton.interactable = false;
        virtualCameraStart.gameObject.SetActive(true);
        StartCoroutine(TurnOffCameraDelay(virtualCameraGame));
        gameDropZone.gameObject.SetActive(false);
    }

    IEnumerator TurnOffCameraDelay(CinemachineVirtualCamera camera)
    {
        yield return new WaitForSeconds(1f);
        camera.gameObject.SetActive(false);
    }

    public void SelectNewDropZoneItem()
    {
        if(currentActiveIngredient!=null)
        {
            ingredientAvailable.Remove(currentActiveIngredient);
        }
        if(ingredientAvailable.Count > 0)
        {
            int nextIndex = Random.Range(0, ingredientAvailable.Count);
            currentActiveIngredient = ingredientAvailable[nextIndex];
            gameDropZone.SetNewItem(currentActiveIngredient);
        }
        else
        {
            EndGame(true);
        }
    }




}
