using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D level;
    public ColorToPrefab[] mappings;
    void Start()
    {
        levelLoad();
        gameObject.GetComponent<playerFollow>().player = GameObject.FindGameObjectWithTag("Player");
    }
    private void levelLoad()
    {
        for (int x = 0; x < level.width; x++)
        {
            for (int y = 0; y < level.height; y++)
            {
                loadTile(x, y);
            }
        }
    }
    private void loadTile(int x, int y)
    {
        Color tile = level.GetPixel(x, y);
        //Debug.Log(ColorUtility.ToHtmlStringRGBA(tile));
        if (tile.Equals(Color.white))
        {
            return;
        }
        for (int i = 0; i < mappings.Length; i++)
        {
            if (tile.Equals(mappings[i].color))
            {

                GameObject newTile = Instantiate(mappings[i].prefab, new Vector3(x, y), Quaternion.identity);
                if (tile.Equals(Color.black))
                {
                    int[] type = new int[4];
                    if (level.GetPixel(x , y+1).Equals(Color.black)) type[0] = 1;
                    if (level.GetPixel(x + 1, y).Equals(Color.black)|| level.GetPixel(x + 1, y).Equals(new Color(1,1,0))) type[1] = 1;
                    if (level.GetPixel(x , y-1).Equals(Color.black)) type[2] = 1;
                    if (level.GetPixel(x - 1, y).Equals(Color.black)|| level.GetPixel(x -5, y).Equals(new Color(1, 1, 0))) type[3] = 1;
                    newTile.GetComponent<wallchoose>().which = string.Join("", type);
                }
                if (tile.Equals(Color.blue))
                {
                    int[] type = new int[4];
                    /*if (level.GetPixel(x, y + 1).Equals(Color.blue)) type[0] = 1;
                    if (level.GetPixel(x + 1, y).Equals(Color.blue)) type[1] = 1;
                    if (level.GetPixel(x, y - 1).Equals(Color.blue)) type[2] = 1;
                    if (level.GetPixel(x - 1, y).Equals(Color.blue)) type[3] = 1;*/
                    if (!level.GetPixel(x, y + 1).Equals(Color.white)) type[0] = 1;
                    if (!level.GetPixel(x + 1, y).Equals(Color.white)) type[1] = 1;
                    if (!level.GetPixel(x, y - 1).Equals(Color.white)) type[2] = 1;
                    if (!level.GetPixel(x - 1, y).Equals(Color.white)) type[3] = 1;
                    Debug.Log(string.Join("", type));
                    newTile.GetComponent<waterChoose>().which = string.Join("", type);
                }
            }
        }
    }
}
