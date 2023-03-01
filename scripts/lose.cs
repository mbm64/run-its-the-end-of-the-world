using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lost = false;
    public GameObject lava;
    public bool ended = false;
    public GameObject load;
    public GameObject retry;
    public GameObject transition;
    public float transSpeed = 10;
    public bool restart = false;
    private bool butRestart = false;
    private timer tim;
    void Start()
    {
        tim = gameObject.GetComponent<timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lost)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (tim.start)
                {
                    butRestart = true;
                }
            }
        }
        if (butRestart)
        {
            tim.start = false;
            transition.SetActive(true);
            if (transition.transform.position.y - transform.position.y < 0)
            {
                
                transition.transform.position += Vector3.up * transSpeed * Time.deltaTime;
                
            }
            else
            {
                load.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
        if (lost)
        {
            lava.SetActive(true);
            if (lava.transform.position.y - transform.position.y > 0)
            {
                lava.transform.position += transSpeed * Vector3.down*Time.deltaTime;
            }
            else ended = true; 

        }
        if (ended)
        {
            retry.SetActive(true);
            if(retry.transform.position.y - transform.position.y > 0 && !restart)
            {
                retry.transform.position += transSpeed * Vector3.down*Time.deltaTime;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    restart = true;
                }
            }
        }
        if (restart)
        {
            transition.SetActive(true);
            if(transition.transform.position.y-transform.position.y < 0)
            {
                lava.transform.position += Vector3.up * transSpeed * Time.deltaTime;
                transition.transform.position += Vector3.up * transSpeed * Time.deltaTime;
                retry.transform.position += Vector3.up * transSpeed * Time.deltaTime;
            }
            else
            {
                load.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
