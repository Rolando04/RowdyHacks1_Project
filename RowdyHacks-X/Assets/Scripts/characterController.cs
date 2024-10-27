using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class characterController : MonoBehaviour
{
    // Start is called before the first frame update
    MovementController movementController;

    void Start()
    {
        movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            movementController.SetDirection("left");
        }
        else if(Input.GetKey(KeyCode.D)){
            movementController.SetDirection("right");
        }
        else if(Input.GetKey(KeyCode.W)){
            movementController.SetDirection("up");
        }
        else if(Input.GetKey(KeyCode.S)){
            movementController.SetDirection("down");
        }
    }
}
