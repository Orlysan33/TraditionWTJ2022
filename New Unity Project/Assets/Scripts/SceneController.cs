using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject transitionCanvas;

    [SerializeField]
    private Animator transitionAnimator;


    private bool sceneChangeStarted;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewScene(string sceneName)
    {
        if(!sceneChangeStarted)
        {
            sceneChangeStarted = false;
            StartCoroutine(StartSceneChange(sceneName));
        }
       
    }

    IEnumerator StartSceneChange(string sceneName)
    {
        transitionCanvas.SetActive(true);
        transitionAnimator.SetTrigger("Close");
        SoundEffects.current.PlaySound(PlaySoundEnum.DoorOpen);
        yield return new WaitForSeconds(1.8f);
        SoundEffects.current.PlaySound(PlaySoundEnum.DoorClose);
        yield return new WaitForSeconds(0.2f);
       
        SceneManager.LoadScene(sceneName);

    }
}
