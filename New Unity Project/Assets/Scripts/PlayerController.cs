using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private PlayerMovementController playerMovementController;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int xInput = 0;
        int yInput = 0;
        if(Input.GetKey(KeyCode.W))
        {
            yInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yInput = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xInput = 1;
        }
        Move(xInput, yInput);
    }

    private void Move(int xDirection, int zDirection)
    {
        playerMovementController.Move(xDirection, zDirection);
    }



}
