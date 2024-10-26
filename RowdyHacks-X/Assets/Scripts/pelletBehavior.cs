using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelletBehavior : MonoBehaviour
{
    int numToSpawn = 26;
    public float currentOffset;
    public float spawnOffset = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Node")
        {
            currentOffset = spawnOffset;
            for(int i = 0; i < numToSpawn; i++){
                GameObject clone = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + currentOffset, 1), Quaternion.identity);
                currentOffset += spawnOffset;
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
