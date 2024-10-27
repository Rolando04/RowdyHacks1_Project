using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public enum GhostNodeStatesEnum
    {
        respawning,
        startNode,
        movingInNodes,
    }

    public GhostNodeStatesEnum ghostNodeState;

    public enum GhostType
    {
        tornado
    }

    public GhostType ghostType;

    public GameObject ghostNodeStart;

    public MovementController movementController;
    // Start is called before the first frame update
    void Awake()
    {
        movementController = GetComponent<movementController>();
        
        if (ghostType == GhostType.tornado)
        {
            ghostNodeState = GhostNodeStatesEnum.startNode;
            startingNode = ghostNodeStart;
        }
        movementController.currentNode = startingNode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
