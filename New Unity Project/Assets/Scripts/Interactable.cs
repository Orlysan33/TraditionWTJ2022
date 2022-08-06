using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnInteraction;   
    private bool isPlayerNear;

    private Transform playerTransform;

    [SerializeField]
    private string interactionName;


    private bool interactable;



    [SerializeField]
    private float interactionAvailableMeters = 3f;

    private float interactionDefaultMeter = 3f;


    [SerializeField]
    private GameObject interactionIcon;



    void Start()
    {

        interactionIcon.SetActive(false);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        interactable = true;
        if (interactionAvailableMeters == 0)
        {
            interactionAvailableMeters = interactionDefaultMeter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            var currentNearCheck = (playerTransform.position - this.transform.position).sqrMagnitude < 3 * interactionAvailableMeters;
            if (isPlayerNear != currentNearCheck)
            {
                if (currentNearCheck)
                {
                    GameEvents.current.PlayerInteraction(interactionName);
                    InteractionAvailabilityChange(true);
                }
                else
                {
                    GameEvents.current.PlayerInteractionExit();
                    InteractionAvailabilityChange(false);
                }
             
            }
            isPlayerNear = currentNearCheck;
            if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && OnInteraction != null)
            {
                DisableInteraction();
                OnInteraction.Invoke();
                GameEvents.current.PlayerInteractionExit();
                InteractionAvailabilityChange(false);

            }
        }

    }

    public void EnableInteraction()
    {
        isPlayerNear = (playerTransform.position - this.transform.position).sqrMagnitude < 3 * interactionAvailableMeters;
        GameEvents.current.PlayerInteraction(interactionName);
        interactable = true;
        InteractionAvailabilityChange(true);
    }

    public void DisableInteraction()
    {
        interactable = false;
    }

    public void UpdateInteractionIcon(Sprite image)
    {

    }

    public void SetInteractionText(string text)
    {
        interactionName = text;
    }

    public void InteractionAvailabilityChange(bool availability)
    {
        interactionIcon.SetActive(availability);
    }
       








}
