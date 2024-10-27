using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Tells us what node we are on
    public GameObject currentNode;
    public float speed = 4f;
    public string direction = "";
    public string lastDirection = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nodeController currentNodeController = currentNode.GetComponent<nodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);
        bool reverseDirection = false;
        if( 
            (direction == "left" && lastDirection == "right")
            || (direction == "right" && lastDirection == "left")
            || (direction == "up" && lastDirection == "up")
            || (direction == "down" && lastDirection == "down")
        ){
            reverseDirection = true;
        }
        if((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection){
            GameObject newNode = currentNodeController.getNodeFromDirection(direction);

            if( newNode != null){
                currentNode = newNode;
                lastDirection = direction;
            }
            else{
                direction = lastDirection;
                newNode = currentNodeController.getNodeFromDirection(direction);
                if(newNode != null){
                    currentNode = newNode;
                }
            }
        }
    }
    public void SetDirection(string newDirection){
        direction = newDirection;
    }
}
