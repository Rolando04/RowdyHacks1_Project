using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class nodeController : MonoBehaviour
{
    public bool canMoveUp = false;
    public bool canMoveDown = false;
    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public GameObject NodeLeft;
    public GameObject NodeRight;
    public GameObject NodeUp;
    public GameObject NodeDown;
    // Start is called before the first frame update
    void Start()
    {  
        //Shoots a raycast going downwards
        RaycastHit2D[] hitsDown;
        hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);

        for(int i = 0; i<hitsDown.Length; i++){
            float distance = math.abs(hitsDown[i].point.y - transform.position.y);
            if(distance < 0.4f){
                canMoveDown = true;
                NodeDown = hitsDown[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsUp;
        hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);

        for(int i = 0; i < hitsUp.Length; i++){
            float distance = math.abs(hitsUp[i].point.y - transform.position.y);
            if(distance < 0.4f){
                canMoveUp = true;
                NodeUp = hitsUp[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsRight;
        hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);

        for(int i = 0; i < hitsRight.Length; i++){
            float distance = math.abs(hitsRight[i].point.x - transform.position.x);
            if(distance < 0.4f){
                canMoveRight = true;
                NodeRight = hitsRight[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsLeft;
        hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);

        for(int i = 0; i < hitsLeft.Length; i++){
            float distance = math.abs(hitsLeft[i].point.x - transform.position.x);
            if(distance < 0.4f){
                canMoveLeft = true;
                NodeLeft = hitsLeft[i].collider.gameObject;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject getNodeFromDirection(string direction){
        if(direction == "left" && canMoveLeft){
            return NodeLeft;
        } 
        else if(direction == "right" && canMoveRight){
            return NodeRight;
        }
        else if(direction == "down" && canMoveDown){
            return NodeDown;
        }
        else if(direction == "up" && canMoveUp){
            return NodeUp;
        } 
        else{
            return null;
        }
    }
}
