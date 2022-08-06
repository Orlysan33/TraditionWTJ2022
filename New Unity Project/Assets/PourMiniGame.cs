using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PourMiniGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider slider;

    private int maxValue = 100;
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Pour();
        }
    }

 


    public void StartGame()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    public void EndGame()
    {

    }

    public void Pour()
    {
        var pointsPerSecond = 100f / 5f * Time.deltaTime;
        slider.value = Mathf.Clamp(slider.value + pointsPerSecond, 0, maxValue);
    }
}
