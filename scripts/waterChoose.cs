using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public string which = "";
    public Sprite[] types;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = types[System.Convert.ToInt32(which, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
