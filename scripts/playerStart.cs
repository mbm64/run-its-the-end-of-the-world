using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStart : MonoBehaviour
{
    // Start is called before the first frame update
    public bool run = false;
    public float speed = 3;
    public GameObject trans;
    public bool start = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        start = true;
    }
}
