using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseInteriorUIManager : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;

    [SerializeField]
    private string exitSceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            sceneController.LoadNewScene(exitSceneName);
        }
    }
}
