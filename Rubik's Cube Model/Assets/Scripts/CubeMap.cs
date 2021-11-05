using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {    }

    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();

        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
    }


    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        float f = .05f;

        //make random numbers between 0 and 1.0 for rgb. change random each time from for each
        //foreach (Transform map in side)
        foreach (Transform map in side)
        {
            if (face[i].name[0] == 'F') //orange
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            /*if (face[i].name[0] == 'B') //red
            {
                map.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            }
            if (face[i].name[0] == 'U') //yellow
            {
                map.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 1);
            }
            if (face[i].name[0] == 'D') //white
            {
                map.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            if (face[i].name[0] == 'L') //green
            {
                map.GetComponent<Image>().color = new Color(0, 1, 0, 1);
            }
            if (face[i].name[0] == 'R') //blue
            {
                map.GetComponent<Image>().color = new Color(0, 0, 1, 1);
            }*/
            /*if (side == front) //orange
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (side == back) //red
            {
                map.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            }
            if (side == up) //yellow
            {
                map.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 1);
            }
            if (side == down) //white
            {
                map.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            if (side == left) //green
            {
                map.GetComponent<Image>().color = new Color(0, 1, 0, 1);
            }
            if (side == right) //blue
            {
                map.GetComponent<Image>().color = new Color(0, 0, 1, 1);
            }*/
            i++;
            //f += .05f;


            //red = 1, 0, 0, 1
            //yellow = 1, .92, 0.016, 1
            //white = 1, 1, 1, 1
            //green = 0, 1, 0, 1
            //blue = 0, 0, 1, 1
        }
    }

}