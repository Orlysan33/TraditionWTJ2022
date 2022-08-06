using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SeedPlace : MonoBehaviour
{
    // Start is called before the first frame update
    private HarvestState harvestState;
    private float delay;
    private float currentSeedDelay;
    private bool startCounter;
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Interactable interactable;

    public UnityEvent onNewInteractionAvailable;

    [SerializeField]
    private GameObject plant;

    [SerializeField]
    private IngredientScriptable ingredientItem;

    private GameObject spawnedHarvest;

    [SerializeField]
    private Transform spawnPositionTransform;

    void Start()
    {
       
        delay = 5f;
        currentSeedDelay = 0f;
        startCounter = false;
        harvestState = HarvestState.Empty;
        slider.maxValue = delay;
        slider.value = currentSeedDelay;
        slider.gameObject.SetActive(false);
        SetInteractionName();
        plant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startCounter)
        {
            
            currentSeedDelay = Mathf.Clamp(currentSeedDelay - Time.deltaTime, 0f, delay);
            UpdateSlider();
            if (currentSeedDelay==0f)
            {
                UpdateToNewState();
            }
        }
        
    }

    public void PlayerInteracted()
    {
        if(!startCounter)
        {
            switch(harvestState)
            {
                case HarvestState.Empty:
                    SoundEffects.current.PlaySound(PlaySoundEnum.PlanSeeds);
                    GoToNextState();
                    break;
                case HarvestState.Seed:
                    SoundEffects.current.PlaySound(PlaySoundEnum.WaterSeeds);
                    GoToNextState();
                    break;           
                case HarvestState.ReadyToHarvest:
                    SoundEffects.current.PlaySound(PlaySoundEnum.Harvest);
                    harvestState = HarvestState.Empty;
                    if(spawnedHarvest!=null)
                    {
                        ingredientItem.Add(1);
                        GameEvents.current.PlayerIngredientPickUp(this.ingredientItem);
                        Destroy(spawnedHarvest);
                        StartCoroutine(RewardSound());
                    }
                    StartCoroutine(DelayToInteract());
                    break;
               
            }        
        }
    }

    IEnumerator RewardSound()
    {
        yield return new WaitForSeconds(0.2f);
        SoundEffects.current.PlaySound(PlaySoundEnum.Reward);
    }

    IEnumerator DelayToInteract()
    {
        yield return new WaitForSeconds(1f);
        SetInteractionName();
        UpdateToNewState();
    }

    private void UpdateNewStateVisual()
    {
        switch (harvestState)
        {
            case HarvestState.Empty:
                plant.SetActive(false);
                break;
            case HarvestState.Seed:
                plant.SetActive(true);
                break;
            case HarvestState.ReadyToHarvest:
                spawnedHarvest = Instantiate(ingredientItem.PrefabObject, spawnPositionTransform.position,Quaternion.identity);
                plant.SetActive(false);
                break;

        }
    }

    private void UpdateToNewState()
    {
        startCounter = false;
        slider.gameObject.SetActive(false);
        UpdateNewStateVisual();
        onNewInteractionAvailable?.Invoke();
    }


    private void GoToNextState()
    {
        slider.gameObject.SetActive(true);
        harvestState = (HarvestState)((int)harvestState + 1);
        SetInteractionName();
        startCounter = true;
        currentSeedDelay = delay;
    }

    private void SetInteractionName()
    {
     
        switch (harvestState)
        {
            case HarvestState.Empty:
                interactable.SetInteractionText("Plant Seeds");
                break;
            case HarvestState.Seed:
                interactable.SetInteractionText("Water");
                break;
            case HarvestState.ReadyToHarvest:
                interactable.SetInteractionText("Harvest");
                break;
        }
    }

    private void CurrentStateEnd()
    {

    }

    private void UpdateSlider()
    {
        slider.value = delay - currentSeedDelay;
       
    }
}
