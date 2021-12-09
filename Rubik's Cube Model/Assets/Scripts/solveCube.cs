using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solveCube : MonoBehaviour
{
    public GameObject Cube;

    public GameObject YO;
    public GameObject YOG;
    public GameObject YOB;
    public GameObject Down;
    public GameObject YG;
    public GameObject YB;
    public GameObject YR;
    public GameObject YRG;
    public GameObject YRB;
    public GameObject Back;
    public GameObject OG;
    public GameObject OB;
    public GameObject Right;
    public GameObject Left;
    public GameObject Middle;
    public GameObject RB;
    public GameObject RG;
    public GameObject Front;
    public GameObject Up;
    public GameObject WO;
    public GameObject WOG;
    public GameObject WOB;
    public GameObject WB;
    public GameObject WG;
    public GameObject WRB;
    public GameObject WRG;
    public GameObject WR;
    public List<List<List<bool>>> position = new List<List<List<bool>>>();
    public List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 3; x++)        {            List<List<GameObject>> twoDim = new List<List<GameObject>>();            for (int y = 0; y < 3; y++)            {                List<GameObject> oneDim = new List<GameObject>();                for (int z = 0; z < 3; z++)                {                    oneDim.Add(null);                }                twoDim.Add(oneDim);            }            pieces.Add(twoDim);        }
        pieces[0][0][0] = YOG;
        pieces[1][0][0] = YO;
        pieces[2][0][0] = YOB;
        pieces[0][1][0] = OG;
        pieces[1][1][0] = Back;
        pieces[2][1][0] = OB;
        pieces[0][2][0] = WOG;
        pieces[1][2][0] = WO;
        pieces[2][2][0] = WOB;
        pieces[0][0][1] = YG;
        pieces[1][0][1] = Down;
        pieces[2][0][1] = YB;
        pieces[0][1][1] = Left;
        pieces[1][1][1] = Middle;
        pieces[2][1][1] = Right;
        pieces[0][2][1] = WG;
        pieces[1][2][1] = Up;
        pieces[2][2][1] = WB;
        pieces[0][0][2] = YRG;
        pieces[1][0][2] = YR;
        pieces[2][0][2] = YRB;
        pieces[0][1][2] = RG;
        pieces[1][1][2] = Front;
        pieces[2][1][2] = RB;
        pieces[0][2][2] = WRG;
        pieces[1][2][2] = WR;
        pieces[2][2][2] = WRB;        for (int x = 0; x < 3; x++)        {            List<List<bool>> twoDim = new List<List<bool>>();            for (int y = 0; y < 3; y++)            {                List<bool> oneDim = new List<bool>();                for (int z = 0; z < 3; z++)                {                    oneDim.Add(false);                }                twoDim.Add(oneDim);            }            position.Add(twoDim);        }
        searching(WRB);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    List<int> searching(GameObject piece)    {        List<int> objectIndex = new List<int>();
        int x = 0;
        int y = 0;
        int z = 0;
        while (true)
        {            Debug.Log("Index: " + x + "," + y + "," + z);            if (pieces[x][y][z] == piece)            {                Debug.Log("Object found!");                objectIndex.Add(x);                objectIndex.Add(y);                objectIndex.Add(z);                break;            }            else            {                if(x >= 2)                {                    x = 0;                    y++;                    if (y > 2)                    {                        y = 0;                        z++;                        if(z > 2)                        {                            Debug.Log("Fully searched!");                            break;                        }                    }                }                else                {                    x++;                }            }                    }        return objectIndex;    }
    void whiteCross()    {        //first check if it is solved        List<int> objectIndex = new List<int>();        objectIndex = searching(WB);        if(objectIndex[0] == 2 && objectIndex[1] == 2 && objectIndex[2] == 1)        {            position[2][2][1] = true;            //correct position is not a thing yet        }    }
}
