using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public static SoundEffects current;

    [SerializeField]
    private AudioClip openDoor;

    [SerializeField]
    private AudioClip closeDoor;

    [SerializeField]
    private AudioClip plantSeeds;

    [SerializeField]
    private AudioClip waterSeeds;

    [SerializeField]
    private AudioClip harvest;

    [SerializeField]
    private AudioClip popInteractionUI;


    [SerializeField]
    private AudioClip hideInteractionUI;

    [SerializeField]
    private AudioClip rewardSound;

    private GameObject oneShotGameObject;
    private AudioSource oneShotGameAudio;


    private void Awake()
    {
        current = this;
    }

    public void Start()
    {
        GameEvents.current.onPlayerInteractionAvailable += PlayerInteraction;
        GameEvents.current.onPlayerInteractionExit += PlayerInteractionExit;
    }

    public void PlayerInteraction(string interactionname)
    {
        PlaySound(PlaySoundEnum.PopInteraction);
    }

    public void PlayerInteractionExit()
    {
        //PlaySound(PlaySoundEnum.HideInteraction);
    }


    public void PlaySound(PlaySoundEnum playSound)
    {
        AudioClip audioClip = null;
        switch(playSound)
        {
            case PlaySoundEnum.DoorOpen:
                audioClip = openDoor;
                break;
            case PlaySoundEnum.DoorClose:
                audioClip = closeDoor;
                break;
            case PlaySoundEnum.PlanSeeds:
                audioClip = plantSeeds;
                break;
            case PlaySoundEnum.WaterSeeds:
                audioClip = waterSeeds;
                break;
            case PlaySoundEnum.Harvest:
                audioClip = harvest;
                break;
            case PlaySoundEnum.PopInteraction:
                audioClip = popInteractionUI;
                break;
            case PlaySoundEnum.HideInteraction:
                audioClip = hideInteractionUI;
                break;
            case PlaySoundEnum.Reward:
                audioClip = rewardSound;
                break;
                
        }
        PlaySound(audioClip);
    }

    private void PlaySound(AudioClip audioClip)
    {      
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotGameAudio = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotGameAudio.PlayOneShot(audioClip);
    }


}


public enum PlaySoundEnum
{
    DoorOpen=1,
    DoorClose=2,
    PlanSeeds=3,
    WaterSeeds=4,
    Harvest=5,
    PopInteraction=6,
    HideInteraction=7,
    Reward=8
}
