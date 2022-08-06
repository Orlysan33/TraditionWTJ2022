using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI interactionText;

    [SerializeField]
    private Button interactionButton;
    void Start()
    {
        interactionButton.gameObject.SetActive(false);
        GameEvents.current.onPlayerInteractionAvailable += ShowInteractionText;
        GameEvents.current.onPlayerInteractionExit += HideInteractionText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInteractionText(string text)
    {
        interactionText.text = text;
        interactionButton.gameObject.SetActive(true);
    }

    public void HideInteractionText()
    {
        interactionButton.gameObject.SetActive(false);
    }
}
