using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ending : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] panels;
    public GameObject pressSpace;
    public GameObject anotherDay;
    private SpriteRenderer anotherDayRend;
    private SpriteRenderer spaceRend;
    private bool another = false;
    public float fadeInSpeed = 1;
    private SpriteRenderer spriteRenderer;
    int index = -1;
    bool next = false;
    bool seen = false;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anotherDayRend = anotherDay.GetComponent<SpriteRenderer>();
        spaceRend = pressSpace.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.color.a <= 0 && !next)
        {
            index += 1;
            if (index < panels.Length)
            {
                next = true;
                spriteRenderer.sprite = panels[index];
            }
            else SceneManager.LoadScene(0);

        }
        if (next)
        {
            if(spriteRenderer.color.a < 1 && !seen) {
                spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * fadeInSpeed);
            }
            else
            {
                if (spaceRend.color.a < 1 && index!=panels.Length-1)
                {
                    spaceRend.color += new Color(0, 0, 0, Time.deltaTime *2* fadeInSpeed);
                }
                if (Input.GetKeyDown("space")&&!seen) {
                    if(index == 5 && anotherDayRend.color.a < 1)
                    {
                        another = true;
                    }
                    else seen = true;
                }
                
            }
            if (another)
            {
                if (anotherDayRend.color.a < 1)
                {
                    anotherDayRend.color += new Color(0, 0, 0, Time.deltaTime * fadeInSpeed);
                }
                else another = false;
            }
            if (seen)
            {
                if(spaceRend.color.a > 0)
                {
                    spaceRend.color -= new Color(0, 0, 0, Time.deltaTime *5* fadeInSpeed);
                }
                if (spriteRenderer.color.a > 0)
                {
                    spriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime * fadeInSpeed);
                    if(index == 5)
                    {
                        anotherDayRend.color -= new Color(0, 0, 0, Time.deltaTime * fadeInSpeed);
                    }
                }
                else
                {
                    seen = false;
                    next = false;
                }
            }
        }
    }
}
