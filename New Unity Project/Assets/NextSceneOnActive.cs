using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnActive : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    void Start()
    {
        LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
