using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private bool started = false;
    private Vector3 iniPos;
    private Vector3 lastPlayerPos;
    public float panConst = 0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && player == null)
        {
            player = gameObject.transform.parent.gameObject;
            started = true;
            lastPlayerPos = player.transform.position;
        }
        else
        {
            transform.position -= Vector3.right*(player.transform.position.x - lastPlayerPos.x) * panConst;
            lastPlayerPos = player.transform.position;
        }
    }
}
