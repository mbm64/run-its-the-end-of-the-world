using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wallchoose : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask wall;
    public string which = "";
    public Sprite[] types;

  
    void Start()

    {
        /*Collider2D hit = Physics2D.OverlapCircle(transform.position + Vector3.up, 0.1f, wall);
        Debug.Log(hit);
        if (hit != null) which += "1";
        else which += "0";
        hit = Physics2D.OverlapCircle(transform.position + Vector3.right, 0.1f, wall);
        if (hit != null) which += "1";
        else which += "0";
        hit = Physics2D.OverlapCircle(transform.position + Vector3.down, 0.1f, wall);
        if (hit != null) which += "1";
        else which += "0";
        hit = Physics2D.OverlapCircle(transform.position + Vector3.left, 0.1f, wall);
        if (hit != null) which += "1";
        else which += "0";*/

        //Debug.Log(which);
        GetComponent<SpriteRenderer>().sprite = types[System.Convert.ToInt32(which,2)];
        //Debug.Log(which);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
