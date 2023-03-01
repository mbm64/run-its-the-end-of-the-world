using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearLv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Clear")
        {
            Debug.Log("poo");
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<playerFollow>().player = null;
            camera.GetComponent<win>().cleared = true;

        }
    }
    void Clear() { }
}
