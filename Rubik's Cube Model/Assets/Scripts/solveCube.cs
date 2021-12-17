using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solveCube : MonoBehaviour
{
    public GameObject Cube;

    public GameObject YO;
    public GameObject YO_Y;
    public GameObject YO_O;
    public GameObject YOG;
    public GameObject YOG_Y;
    public GameObject YOG_O;
    public GameObject YOG_G;
    public GameObject YOB;
    public GameObject YOB_Y;
    public GameObject YOB_O;
    public GameObject YOB_B;
    public GameObject Down;
    public GameObject YG;
    public GameObject YG_Y;
    public GameObject YG_G;
    public GameObject YB;
    public GameObject YB_Y;
    public GameObject YB_B;
    public GameObject YR;
    public GameObject YR_Y;
    public GameObject YR_R;
    public GameObject YRG;
    public GameObject YRG_Y;
    public GameObject YRG_R;
    public GameObject YRG_G;
    public GameObject YRB;
    public GameObject YRB_Y;
    public GameObject YRB_R;
    public GameObject YRB_B;
    public GameObject Back;
    public GameObject OG;
    public GameObject OG_O;
    public GameObject OG_G;
    public GameObject OB;
    public GameObject OB_O;
    public GameObject OB_B;
    public GameObject Right;
    public GameObject Left;
    public GameObject Middle;
    public GameObject RB;
    public GameObject RB_R;
    public GameObject RB_B;
    public GameObject RG;
    public GameObject RG_R;
    public GameObject RG_G;
    public GameObject Front;
    public GameObject Up;
    public GameObject WO;
    public GameObject WO_W;
    public GameObject WO_O;
    public GameObject WOG;
    public GameObject WOG_W;
    public GameObject WOG_O;
    public GameObject WOG_G;
    public GameObject WOB;
    public GameObject WOB_W;
    public GameObject WOB_O;
    public GameObject WOB_B;
    public GameObject WB;
    public GameObject WB_W;
    public GameObject WB_B;
    public GameObject WG;
    public GameObject WG_W;
    public GameObject WG_G;
    public GameObject WRB;
    public GameObject WRB_W;
    public GameObject WRB_R;
    public GameObject WRB_B;
    public GameObject WRG;
    public GameObject WRG_W;
    public GameObject WRG_R;
    public GameObject WRG_G;
    public GameObject WR;
    public GameObject WR_W;
    public GameObject WR_R;
    public List<List<List<bool>>> position = new List<List<List<bool>>>();
    public List<List<List<bool>>> orientation = new List<List<List<bool>>>();
    public List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();
    RotateBigCube rotateBigCube;

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
        pieces[2][2][2] = WRB;        for (int x = 0; x < 3; x++)        {            List<List<bool>> twoDim = new List<List<bool>>();            for (int y = 0; y < 3; y++)            {                List<bool> oneDim = new List<bool>();                for (int z = 0; z < 3; z++)                {                    oneDim.Add(false);                }                twoDim.Add(oneDim);            }            position.Add(twoDim);            orientation.Add(twoDim);        }

        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void scramble()    {        rotateBigCube.U(0, -90, 0);        rotateBigCube.B(-90, 0, 0);        rotateBigCube.R(0, 0, -90);        rotateBigCube.F(90, 0, 0);        rotateBigCube.L(0, 0, -90);        rotateBigCube.B(-90, 0, 0);    }

    List<int> searching(GameObject piece)    {        List<int> objectIndex = new List<int>();
        int x = 0;
        int y = 0;
        int z = 0;
        while (true)
        {            Debug.Log("Index: " + x + "," + y + "," + z);            if (pieces[x][y][z] == piece)            {                Debug.Log("Object found!");                objectIndex.Add(x);                objectIndex.Add(y);                objectIndex.Add(z);                break;            }            else            {                if(x >= 2)                {                    x = 0;                    y++;                    if (y > 2)                    {                        y = 0;                        z++;                        if(z > 2)                        {                            Debug.Log("Fully searched!");                            break;                        }                    }                }                else                {                    x++;                }            }                    }        return objectIndex;    }
    public void whiteCross()    {        //first check if it is solved        List<int> objectIndex = new List<int>();        //WB PIECE        objectIndex = searching(WB);        if (objectIndex[0] == 2 && objectIndex[1] == 2 && objectIndex[2] == 1)        {            position[2][2][1] = true;            //check if orientation is correct using coordinates            //if up is greater y value than left            float y1 = WB_W.transform.position.y;            float y2 = WB_B.transform.position.y;            if (y1 > y2)            {                orientation[2][2][1] = true;            }            else            {                //R, R, D, B, R', B'                rotateBigCube.R(0, 0, -90);                rotateBigCube.R(0, 0, -90);                rotateBigCube.D(0, -90, 0);                rotateBigCube.B(90, 0, 0);                rotateBigCube.R(0, 0, 90);                rotateBigCube.B(-90, 0, 0);            }        }        else if (objectIndex[1] == 2) //if it is in the correct y value        {            float y1 = WB_W.transform.position.y;            float y2 = WB_B.transform.position.y;            if (y1 > y2)            {                //locate layer it is on                //for example if it is on red layer, rotate red twice, rotate bottom so it is under the blue side, rotate blue twice            }            else            {                //R, R, D, B, R', B'                rotateBigCube.R(0, 0, -90);                rotateBigCube.R(0, 0, -90);                rotateBigCube.D(0, -90, 0);                rotateBigCube.B(90, 0, 0);                rotateBigCube.R(0, 0, 90);                rotateBigCube.B(-90, 0, 0);//correctly orient, like this or somehow, and then do the top thing            }            //position correctly            //middle layer incorrect placement            //bottom layer incorrect        }        //WG        objectIndex = searching(WG);        if (objectIndex[0] == 0 && objectIndex[1] == 2 && objectIndex[2] == 1)        {            position[0][2][1] = true;            //check if orientation is correct using coordinates            //if up is greater y value than left            float y1 = WG_W.transform.position.y;            float y2 = WG_G.transform.position.y;            if (y1 > y2)            {                orientation[0][2][1] = true;            }            else            {                //L', L', D', B', L, B                rotateBigCube.L(0, 0, -90);                rotateBigCube.L(0, 0, -90);                rotateBigCube.D(0, 90, 0);                rotateBigCube.B(-90, 0, 0);                rotateBigCube.L(0, 0, 90);                rotateBigCube.B(90, 0, 0);            }        }        else        {            //position correctly        }        //WR        objectIndex = searching(WR);        if (objectIndex[0] == 1 && objectIndex[1] == 2 && objectIndex[2] == 2)        {            position[1][2][2] = true;            //check if orientation is correct using coordinates            //if up is greater y value than left            float y1 = WR_W.transform.position.y;            float y2 = WR_R.transform.position.y;            if (y1 > y2)            {                orientation[1][2][2] = true;            }            else            {                //F, F, D, R, F', R'                rotateBigCube.F(-90, 0, 0);                rotateBigCube.F(-90, 0, 0);                rotateBigCube.D(0, -90, 0);                rotateBigCube.R(0, 0, -90);                rotateBigCube.F(90, 0, 0);                rotateBigCube.R(0, 0, 90);            }        }        else        {            //position correctly        }        //WO        objectIndex = searching(WO);        if (objectIndex[0] == 1 && objectIndex[1] == 2 && objectIndex[2] == 0)        {            position[1][2][0] = true;            //check if orientation is correct using coordinates            //if up is greater y value than left            float y1 = WO_W.transform.position.y;            float y2 = WO_O.transform.position.y;            if (y1 > y2)            {                orientation[1][2][0] = true;            }            else            {                //B', B', D', R', B, R                rotateBigCube.B(-90, 0, 0);                rotateBigCube.B(-90, 0, 0);                rotateBigCube.D(0, 90, 0);                rotateBigCube.R(0, 0, 90);                rotateBigCube.B(90, 0, 0);                rotateBigCube.R(0, 0, -90);            }        }        else        {            //position correctly        }    }
}
