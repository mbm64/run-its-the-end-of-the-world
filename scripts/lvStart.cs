using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transition;
    public float transSpeed = 20;
    bool started = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transition.transform.position.y - transform.position.y < 11 && !started)
        {
            transition.transform.position += Vector3.up * transSpeed * Time.deltaTime;
        }
        else if(!started){
            transition.SetActive(false);
            transition.transform.position += Vector3.down * 22;
            started = true;
            gameObject.GetComponent<timer>().start = true;
        }
    }
}
