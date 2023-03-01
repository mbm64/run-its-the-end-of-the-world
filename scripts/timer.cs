using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool start = false;
    public bool beat = false;
    public float time = 50;
    public GameObject text;
    public Canvas can;
    public AudioSource aud;
    void Start()
    {
        text.GetComponent<Text>().text = System.Convert.ToString(Mathf.Ceil(time));
    }

    // Update is called once per frame
    void Update()
    {
        if (beat)
        {
            start = false;
            can.gameObject.SetActive(false);
        }
        if (start)
        {
            time -= Time.deltaTime;
            text.GetComponent<Text>().text = System.Convert.ToString(Mathf.Ceil(time));
            if (time < 0)
            {
                aud.Stop();
                start = false;
                can.gameObject.SetActive(false);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<movement>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity -= player.GetComponent<Rigidbody2D>().velocity.x * Vector2.right;
                gameObject.GetComponent<lose>().lost = true;
                
            }
        }
        
    }
}
