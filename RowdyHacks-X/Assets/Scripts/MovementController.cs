using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MovementController : MonoBehaviour
{
    //Tells us what node we are on
    public GameManager gameManager;
    public GameObject currentNode;
    public float speed = 4f;
    public string direction = "";
    public string lastDirection = "";
    public bool canWarp = true;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            || (direction == "up" && lastDirection == "down")
            || (direction == "down" && lastDirection == "up")
        ){
            reverseDirection = true;
        }
        if((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection){
            if(currentNodeController.isWarpLeftNode && canWarp){
                currentNode = gameManager.leftWarpNode;
                transform.position = currentNode.transform.position;
                direction = "right";
                lastDirection = "right";
                //transform.position = currentNode.transform.position;
                canWarp = false;
            }else if(currentNodeController.isWarpRightNode && canWarp){
                currentNode = gameManager.leftWarpNode;
                direction = "left";
                lastDirection = "left";
                transform.position = currentNode.transform.position;
                canWarp = false;
            }else if((currentNodeController.isWarpBottomLeftNode1 || currentNodeController.isWarpBottomLeftNode2)&& canWarp){
                currentNode = gameManager.topRightWarpNode1;
                direction = "right";
                lastDirection = "right";
                transform.position = currentNode.transform.position;
                canWarp = false;
            }else if((currentNodeController.isWarpBottomRightNode1 || currentNodeController.isWarpBottomRightNode2)&& canWarp){
                currentNode = gameManager.topLeftWarpNode1;
                direction = "left";
                lastDirection = "left";
                transform.position = currentNode.transform.position;
                canWarp = false;
            }else if((currentNodeController.isWarpTopLeftNode1 || currentNodeController.isWarpTopLeftNode2)&& canWarp){
                currentNode = gameManager.bottomRightWarpNode1;
                direction = "right";
                lastDirection = "right";
                transform.position = currentNode.transform.position;
                canWarp = false;
            }else if((currentNodeController.isWarpTopRightNode1 || currentNodeController.isWarpTopRightNode2) && canWarp){
                currentNode = gameManager.bottomLeftWarpNode1;
                direction = "left";
                lastDirection = "left";
                transform.position = currentNode.transform.position;
                canWarp = false;
            }
            else{
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
            canWarp = true;
            }
        }
    }
    public void SetDirection(string newDirection){
        direction = newDirection;
    }
}
