using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winScreen;
    public GameObject transition;
    public GameObject load;
    public bool cleared = false;
    public float transSpeed = 10;
    private float timePassed=0;
    public int lvToGo = 0;
    public AudioSource aud;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (cleared)
        {
            winScreen.SetActive(true);
            timer tim = gameObject.GetComponent<timer>();
            tim.beat = true;


            //winScreen.transform.position = Vector3.MoveTowards(winScreen.transform.position, transform.position+Vector3.forward*20, 5 * Time.deltaTime);
            if (winScreen.transform.position.x - transform.position.x > 0)
            {
                winScreen.transform.position += Vector3.left * transSpeed * Time.deltaTime;
            }
            else
            {
                timePassed += Time.deltaTime;
                if (timePassed > 1)
                {
                    aud.Stop();
                    transition.SetActive(true);
                    if (transition.transform.position.y - transform.position.y < 0)
                    {
                        transition.transform.position += Vector3.up * transSpeed * Time.deltaTime;
                    }
                    else
                    {
                        load.SetActive(true);
                        SceneManager.LoadScene(lvToGo);
                    }
                }
            }
        }
    }
}
