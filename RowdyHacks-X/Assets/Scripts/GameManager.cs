using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Rowdy;
    public GameObject leftWarpNode;
    public GameObject rightWarpNode;
    public GameObject topRightWarpNode1;
    public GameObject topRightWarpNode2;
    public GameObject topLeftWarpNode1;
    public GameObject topLeftWarpNode2;
    public GameObject bottomLeftWarpNode1;
    public GameObject bottomLeftWarpNode2;
    public GameObject bottomRightWarpNode1;
    public GameObject bottomRightWarpNode2;

     public GameObject ghostNodeStart;
    public GameObject ghostNodeCenter;

    // Start is called before the first frame update
    void Awake()
    {
        ghostNodeStart.GetComponent<nodeController>().isGhostStartingNode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
