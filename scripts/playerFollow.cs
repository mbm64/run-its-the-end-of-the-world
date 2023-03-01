using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.z = -10;
            transform.position = playerPos;
        }
    }
}
