using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public enum GhostNodeStatesEnum
    {
        respawning,
        startNode,
        centerNode,
        movingInNodes,

    }

    public GhostNodeStatesEnum ghostNodeState;

    public enum GhostType
    {
        tornado,

    }


    public GhostType ghostType;
    public GhostNodeStatesEnum respawnState;

    public GameObject ghostNodeStart;
    public GameObject ghostNodeCenter;

    public MovementController movementController;

    public GameObject startingNode;

    public bool readyToLeaveHome = false;

    public GameManager gameManager;

    public bool testRespawn = false;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        movementController = GetComponent<MovementController>();
        if (ghostType == GhostType.tornado)
        {
            ghostNodeState = GhostNodeStatesEnum.startNode;
            respawnState = GhostNodeStatesEnum.centerNode;
            startingNode = ghostNodeStart;
            readyToLeaveHome = true;
        }
        
        movementController.currentNode = startingNode;
        transform.position = startingNode.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (testRespawn == true)
        {
            readyToLeaveHome = false;
            ghostNodeState = GhostNodeStatesEnum.respawning;
            testRespawn = false;
        }
    }
    public void ReachedCenterOfNode(nodeController nodeControl)
    {
        if (ghostNodeState == GhostNodeStatesEnum.movingInNodes)
        {
            //Determine next game node to go to
            if (ghostType == GhostType.tornado)
            {
                DetermineTornadoDirection();
            }
        }
        else if (ghostNodeState == GhostNodeStatesEnum.respawning)
        {
            string direction ="";
            
            //we have reached starter node, move to the center node
            if (transform.position.x == ghostNodeStart.transform.position.x && transform.position.y == ghostNodeStart.transform.position.y)
            {
                direction = "down";
            }
            else if (transform.position.x == ghostNodeCenter.transform.position.x && transform.position.y == ghostNodeCenter.transform.position.y)
            {
                if (respawnState == GhostNodeStatesEnum.centerNode)
                {
                    ghostNodeState = respawnState;
                }
            }
            //Determine quickest direction to home
             direction = GetClosestDirection(ghostNodeStart.transform.position);
            movementController.SetDirection(direction);
        }
        else
        {
            if (readyToLeaveHome)
            {
                if (ghostNodeState == GhostNodeStatesEnum.startNode)
                {
                    ghostNodeState = GhostNodeStatesEnum.movingInNodes;
                    movementController.SetDirection("Left");
                }
            }
        }
    }

        void DetermineTornadoDirection()
    {
        string direction = GetClosestDirection(gameManager.Rowdy.transform.position);
        movementController.SetDirection(direction);
    }

    string GetClosestDirection(Vector2 target)
    {
        float shortestDistance = 0;
        string lastMovingDirection = movementController.direction;
        string newDirection ="";

        nodeController nodeControl = movementController.currentNode.GetComponent<nodeController>();

        //if we can move up and we arent reversing 
        if (nodeControl.canMoveUp && lastMovingDirection != "down")
        {
            //get the node above us
            GameObject NodeUp = nodeControl.NodeUp;
            //get distance between top node and rowdy
            float distance = Vector2.Distance(NodeUp.transform.position, target);
            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "up";
            }
        }

         if (nodeControl.canMoveDown && lastMovingDirection != "up")
        {
            //get the node above us
            GameObject NodeDown = nodeControl.NodeDown;
            //get distance between top node and rowdy
            float distance = Vector2.Distance(NodeDown.transform.position, target);
            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "down";
            }
        }
         if (nodeControl.canMoveLeft && lastMovingDirection != "right")
        {
            //get the node above us
            GameObject NodeLeft = nodeControl.NodeLeft;
            //get distance between top node and rowdy
            float distance = Vector2.Distance(NodeLeft.transform.position, target);
            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "left";
            }
        }
         if (nodeControl.canMoveRight && lastMovingDirection != "left")
        {
            //get the node above us
            GameObject NodeRight = nodeControl.NodeRight;
            //get distance between top node and rowdy
            float distance = Vector2.Distance(NodeRight.transform.position, target);
            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "right";
            }
        }

        return newDirection;
    }
}
