using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public bool pan = false;
    public float panSpeed = 5;
    public GameObject trans;
    public GameObject begin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pan = true;
            begin.SetActive(false);
        }
        if (pan)
        {
            if (transform.position.y > -6)
            {
                transform.position += Vector3.down * Time.deltaTime * panSpeed;
            }
            else
            {
                playerStart status = player.GetComponent<playerStart>();
                status.run = true;
                if (status.start) {
                    trans.SetActive(true);
                    if (trans.transform.position.y - transform.position.y < 0)
                    {
                        trans.transform.position += Vector3.up * panSpeed *2* Time.deltaTime;
                    }
                    else SceneManager.LoadScene(1);

                }
            }
        }
    }
}
