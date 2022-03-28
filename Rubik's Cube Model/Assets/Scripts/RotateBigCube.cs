using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
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
    public List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();

    // Start is called before the first frame update
    void Start()
    {
        //List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();
        for (int x = 0; x < 3; x++)
        {
            List<List<GameObject>> twoDim = new List<List<GameObject>>();
            for (int y = 0; y < 3; y++)
            {
                List<GameObject> oneDim = new List<GameObject>();
                for (int z = 0; z < 3; z++)
                {
                    oneDim.Add(null);
                }
                twoDim.Add(oneDim);
            }
            pieces.Add(twoDim);
        }
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
        pieces[2][2][2] = WRB;
    }

    // Update is called once per frame
    void Update()
    {
        //Swipe();

    }
    /*List<List<List<GameObject>>> swap(List<int> indexOne, List<int> indexTwo, List<List<List<GameObject>>> pieces)
    {
        GameObject temp = pieces[indexOne[0]][indexOne[1]][indexOne[2]];
        pieces[indexOne[0]][indexOne[1]][indexOne[2]] = pieces[indexTwo[0]][indexTwo[1]][indexTwo[2]];
        pieces[indexTwo[0]][indexTwo[1]][indexTwo[2]] = temp;
        return pieces;
    }*/
    //full cube rotations
    public List<List<List<GameObject>>> fullRotation(int x, int y, int z)
    {
        //Cube.transform.Rotate(x, y, z, Space.World);
        //
        pieces[0][0][0].transform.parent = pieces[1][1][1].transform;//child all to center piece
        pieces[1][0][0].transform.parent = pieces[1][1][1].transform;
        pieces[2][0][0].transform.parent = pieces[1][1][1].transform;
        pieces[0][0][1].transform.parent = pieces[1][1][1].transform;
        pieces[1][0][1].transform.parent = pieces[1][1][1].transform;
        pieces[2][0][1].transform.parent = pieces[1][1][1].transform;
        pieces[0][0][2].transform.parent = pieces[1][1][1].transform;
        pieces[1][0][2].transform.parent = pieces[1][1][1].transform;
        pieces[2][0][2].transform.parent = pieces[1][1][1].transform;
        //
        pieces[0][1][0].transform.parent = pieces[1][1][1].transform;
        pieces[1][1][0].transform.parent = pieces[1][1][1].transform;
        pieces[2][1][0].transform.parent = pieces[1][1][1].transform;
        pieces[0][1][1].transform.parent = pieces[1][1][1].transform;
        pieces[2][1][1].transform.parent = pieces[1][1][1].transform;
        pieces[0][1][2].transform.parent = pieces[1][1][1].transform;
        pieces[1][1][2].transform.parent = pieces[1][1][1].transform;
        pieces[2][1][2].transform.parent = pieces[1][1][1].transform;
        //
        pieces[0][2][0].transform.parent = pieces[1][1][1].transform;
        pieces[1][2][0].transform.parent = pieces[1][1][1].transform;
        pieces[2][2][0].transform.parent = pieces[1][1][1].transform;
        pieces[0][2][1].transform.parent = pieces[1][1][1].transform;
        pieces[1][2][1].transform.parent = pieces[1][1][1].transform;
        pieces[2][2][1].transform.parent = pieces[1][1][1].transform;
        pieces[0][2][2].transform.parent = pieces[1][1][1].transform;
        pieces[1][2][2].transform.parent = pieces[1][1][1].transform;
        pieces[2][2][2].transform.parent = pieces[1][1][1].transform;

        pieces[1][1][1].transform.Rotate(x, y, z, Space.World);
        pieces[0][0][0].transform.parent = Cube.transform;//unchild all from center piece
        pieces[1][0][0].transform.parent = Cube.transform;
        pieces[2][0][0].transform.parent = Cube.transform;
        pieces[0][0][1].transform.parent = Cube.transform;
        pieces[1][0][1].transform.parent = Cube.transform;
        pieces[2][0][1].transform.parent = Cube.transform;
        pieces[0][0][2].transform.parent = Cube.transform;
        pieces[1][0][2].transform.parent = Cube.transform;
        pieces[2][0][2].transform.parent = Cube.transform;
        //
        pieces[0][1][0].transform.parent = Cube.transform;
        pieces[1][1][0].transform.parent = Cube.transform;
        pieces[2][1][0].transform.parent = Cube.transform;
        pieces[0][1][1].transform.parent = Cube.transform;
        pieces[2][1][1].transform.parent = Cube.transform;
        pieces[0][1][2].transform.parent = Cube.transform;
        pieces[1][1][2].transform.parent = Cube.transform;
        pieces[2][1][2].transform.parent = Cube.transform;
        //
        pieces[0][2][0].transform.parent = Cube.transform;
        pieces[1][2][0].transform.parent = Cube.transform;
        pieces[2][2][0].transform.parent = Cube.transform;
        pieces[0][2][1].transform.parent = Cube.transform;
        pieces[1][2][1].transform.parent = Cube.transform;
        pieces[2][2][1].transform.parent = Cube.transform;
        pieces[0][2][2].transform.parent = Cube.transform;
        pieces[1][2][2].transform.parent = Cube.transform;
        pieces[2][2][2].transform.parent = Cube.transform;
        //need to move them all in array based on which axis of rotation and direction
        if (x != 0) //fully functional        {            if (x > 0) //x clock            {                GameObject temp1 = pieces[2][2][2];                GameObject temp2 = pieces[2][2][1];                GameObject temp3 = pieces[2][2][0];                GameObject temp4 = pieces[2][1][2];                GameObject temp5 = pieces[2][1][1];                GameObject temp6 = pieces[2][1][0];                GameObject temp7 = pieces[2][0][2];                GameObject temp8 = pieces[2][0][1];                GameObject temp9 = pieces[2][0][0];                //                pieces[2][2][2] = pieces[2][0][2];                pieces[2][2][1] = pieces[2][0][1];                pieces[2][2][0] = pieces[2][0][0];                pieces[2][1][2] = pieces[1][0][2];                pieces[2][1][1] = pieces[1][0][1];                pieces[2][1][0] = pieces[1][0][0];                pieces[2][0][2] = pieces[0][0][2];                pieces[2][0][1] = pieces[0][0][1];                pieces[2][0][0] = pieces[0][0][0];                //                pieces[2][0][2] = pieces[0][0][2];                pieces[2][0][1] = pieces[0][0][1];                pieces[2][0][0] = pieces[0][0][0];                pieces[1][0][2] = pieces[0][1][2];                pieces[1][0][1] = pieces[0][1][1];                pieces[1][0][0] = pieces[0][1][0];                pieces[0][0][2] = pieces[0][2][2];                pieces[0][0][1] = pieces[0][2][1];                pieces[0][0][0] = pieces[0][2][0];                //                pieces[0][0][2] = pieces[0][2][2];                pieces[0][0][1] = pieces[0][2][1];                pieces[0][0][0] = pieces[0][2][0];                pieces[0][1][2] = pieces[1][2][2];                pieces[0][1][1] = pieces[1][2][1];                pieces[0][1][0] = pieces[1][2][0];                pieces[0][2][2] = pieces[2][2][2];                pieces[0][2][1] = pieces[2][2][1];                pieces[0][2][0] = pieces[2][2][0];                //                pieces[0][2][2] = temp1;                pieces[0][2][1] = temp2;                pieces[0][2][0] = temp3;                pieces[1][2][2] = temp4;                pieces[1][2][1] = temp5;                pieces[1][2][0] = temp6;                pieces[2][2][2] = temp7;                pieces[2][2][1] = temp8;                pieces[2][2][0] = temp9;            }            else            {                GameObject temp1 = pieces[2][0][2];                GameObject temp2 = pieces[2][0][1];                GameObject temp3 = pieces[2][0][0];                GameObject temp4 = pieces[2][1][2];                GameObject temp5 = pieces[2][1][1];                GameObject temp6 = pieces[2][1][0];                GameObject temp7 = pieces[2][2][2];                GameObject temp8 = pieces[2][2][1];                GameObject temp9 = pieces[2][2][0];                //                pieces[2][0][2] = pieces[2][2][2];                pieces[2][0][1] = pieces[2][2][1];                pieces[2][0][0] = pieces[2][2][0];                pieces[2][1][2] = pieces[1][2][2];                pieces[2][1][1] = pieces[1][2][1];                pieces[2][1][0] = pieces[1][2][0];                pieces[2][2][2] = pieces[0][2][2];                pieces[2][2][1] = pieces[0][2][1];                pieces[2][2][0] = pieces[0][2][0];                //                pieces[2][2][2] = pieces[0][2][2];                pieces[2][2][1] = pieces[0][2][1];                pieces[2][2][0] = pieces[0][2][0];                pieces[1][2][2] = pieces[0][1][2];                pieces[1][2][1] = pieces[0][1][1];                pieces[1][2][0] = pieces[0][1][0];                pieces[0][2][2] = pieces[0][0][2];                pieces[0][2][1] = pieces[0][0][1];                pieces[0][2][0] = pieces[0][0][0];                //                pieces[0][2][2] = pieces[0][0][2];                pieces[0][2][1] = pieces[0][0][1];                pieces[0][2][0] = pieces[0][0][0];                pieces[0][1][2] = pieces[1][0][2];                pieces[0][1][1] = pieces[1][0][1];                pieces[0][1][0] = pieces[1][0][0];                pieces[0][0][2] = pieces[2][0][2];                pieces[0][0][1] = pieces[2][0][1];                pieces[0][0][0] = pieces[2][0][0];                //                pieces[0][0][2] = temp1;                pieces[0][0][1] = temp2;                pieces[0][0][0] = temp3;                pieces[1][0][2] = temp4;                pieces[1][0][1] = temp5;                pieces[1][0][0] = temp6;                pieces[2][0][2] = temp7;                pieces[2][0][1] = temp8;                pieces[2][0][0] = temp9;            }        }
        /*else if (y != 0) //fully funct        {            if (y > 0)            {                GameObject temp1 = pieces[2][2][2];                GameObject temp2 = pieces[2][2][1];                GameObject temp3 = pieces[2][2][0];                GameObject temp4 = pieces[2][1][2];                GameObject temp5 = pieces[2][1][1];                GameObject temp6 = pieces[2][1][0];                GameObject temp7 = pieces[2][0][2];                GameObject temp8 = pieces[2][0][1];                GameObject temp9 = pieces[2][0][0];                //                pieces[2][2][2] = pieces[2][2][0];                pieces[2][2][1] = pieces[1][2][0];                pieces[2][2][0] = pieces[0][2][0];                pieces[2][1][2] = pieces[2][1][0];                pieces[2][1][1] = pieces[1][1][0];                pieces[2][1][0] = pieces[0][1][0];                pieces[2][0][2] = pieces[2][0][0];                pieces[2][0][1] = pieces[1][0][0];                pieces[2][0][0] = pieces[0][0][0];                //                pieces[2][2][0] = pieces[0][2][0];                pieces[1][2][0] = pieces[0][2][1];                pieces[0][2][0] = pieces[0][2][2];                pieces[2][1][0] = pieces[0][1][0];                pieces[1][1][0] = pieces[0][1][1];                pieces[0][1][0] = pieces[0][1][2];                pieces[2][0][0] = pieces[0][0][0];                pieces[1][0][0] = pieces[0][0][1];                pieces[0][0][0] = pieces[0][0][2];                //                pieces[0][2][0] = pieces[0][2][2];                pieces[0][2][1] = pieces[1][2][2];                pieces[0][2][2] = pieces[2][2][2];                pieces[0][1][0] = pieces[0][1][2];                pieces[0][1][1] = pieces[1][1][2];                pieces[0][1][2] = pieces[2][1][2];                pieces[0][0][0] = pieces[0][0][2];                pieces[0][0][1] = pieces[1][0][2];                pieces[0][0][2] = pieces[2][0][2];                //                pieces[0][2][2] = temp1;                pieces[1][2][2] = temp2;                pieces[2][2][2] = temp3;                pieces[0][1][2] = temp4;                pieces[1][1][2] = temp5;                pieces[2][1][2] = temp6;                pieces[0][0][2] = temp7;                pieces[1][0][2] = temp8;                pieces[2][0][2] = temp9;            }            else            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     GameObject temp1 = pieces[2][2][0];                GameObject temp2 = pieces[2][2][1];                GameObject temp3 = pieces[2][2][2];                GameObject temp4 = pieces[2][1][0];                GameObject temp5 = pieces[2][1][1];                GameObject temp6 = pieces[2][1][2];                GameObject temp7 = pieces[2][0][0];                GameObject temp8 = pieces[2][0][1];                GameObject temp9 = pieces[2][0][2];                //                pieces[2][2][0] = pieces[2][2][2];                pieces[2][2][1] = pieces[1][2][2];                pieces[2][2][2] = pieces[0][2][2];                pieces[2][1][0] = pieces[2][1][2];                pieces[2][1][1] = pieces[1][1][2];                pieces[2][1][2] = pieces[0][1][2];                pieces[2][0][0] = pieces[2][0][2];                pieces[2][0][1] = pieces[1][0][2];                pieces[2][0][2] = pieces[0][0][2];                //                pieces[2][2][2] = pieces[0][2][2];                pieces[1][2][2] = pieces[0][2][1];                pieces[0][2][2] = pieces[0][2][0];                pieces[2][1][2] = pieces[0][1][2];                pieces[1][1][2] = pieces[0][1][1];                pieces[0][1][2] = pieces[0][1][0];                pieces[2][0][2] = pieces[0][0][2];                pieces[1][0][2] = pieces[0][0][1];                pieces[0][0][2] = pieces[0][0][0];                //                pieces[0][2][2] = pieces[0][2][0];                pieces[0][2][1] = pieces[1][2][0];                pieces[0][2][0] = pieces[2][2][0];                pieces[0][1][2] = pieces[0][1][0];                pieces[0][1][1] = pieces[1][1][0];                pieces[0][1][0] = pieces[2][1][0];                pieces[0][0][2] = pieces[0][0][0];                pieces[0][0][1] = pieces[1][0][0];                pieces[0][0][0] = pieces[2][0][0];                //                pieces[0][2][0] = temp1;                pieces[1][2][0] = temp2;                pieces[2][2][0] = temp3;                pieces[0][1][0] = temp4;                pieces[1][1][0] = temp5;                pieces[2][1][0] = temp6;                pieces[0][0][0] = temp7;                pieces[1][0][0] = temp8;                pieces[2][0][0] = temp9;            }        }
        else if (z != 0)
        {
            if (z > 0)
            {
                GameObject temp1 = pieces[0][2][2];
                GameObject temp2 = pieces[1][2][2];
                GameObject temp3 = pieces[2][2][2];
                GameObject temp4 = pieces[0][2][1];
                GameObject temp5 = pieces[1][2][1];
                GameObject temp6 = pieces[2][2][1];
                GameObject temp7 = pieces[0][2][0];
                GameObject temp8 = pieces[1][2][0];
                GameObject temp9 = pieces[2][2][0];
                //white = orange
                pieces[0][2][2] = pieces[0][2][0];
                pieces[1][2][2] = pieces[1][2][0];
                pieces[2][2][2] = pieces[2][2][0];
                pieces[0][2][1] = pieces[0][1][0];
                pieces[1][2][1] = pieces[1][1][0];
                pieces[2][2][1] = pieces[2][1][0];
                pieces[0][2][0] = pieces[0][0][0];
                pieces[1][2][0] = pieces[1][0][0];
                pieces[2][2][0] = pieces[2][0][0];
                //orange = yellow
                pieces[0][2][0] = pieces[0][0][0];
                pieces[1][2][0] = pieces[1][0][0];
                pieces[2][2][0] = pieces[2][0][0];
                pieces[0][1][0] = pieces[0][0][1];
                pieces[1][1][0] = pieces[1][0][1];
                pieces[2][1][0] = pieces[2][0][1];
                pieces[0][0][0] = pieces[0][0][2];
                pieces[1][0][0] = pieces[1][0][2];
                pieces[2][0][0] = pieces[2][0][2];
                //yellow = red
                pieces[0][0][0] = pieces[0][0][2];
                pieces[1][0][0] = pieces[1][0][2];
                pieces[2][0][0] = pieces[2][0][2];
                pieces[0][0][1] = pieces[0][1][2];
                pieces[1][0][1] = pieces[1][1][2];
                pieces[2][0][1] = pieces[2][1][2];
                pieces[0][0][2] = pieces[0][2][2];
                pieces[1][0][2] = pieces[1][2][2];
                pieces[2][0][2] = pieces[2][2][2];
                //
                pieces[0][0][2] = temp1;
                pieces[1][0][2] = temp2;
                pieces[2][0][2] = temp3;
                pieces[0][1][2] = temp4;
                pieces[1][1][2] = temp5;
                pieces[2][1][2] = temp6;
                pieces[0][2][2] = temp7;
                pieces[1][2][2] = temp8;
                pieces[2][2][2] = temp9;
            }
            else
            {
                GameObject temp1 = pieces[0][2][0];
                GameObject temp2 = pieces[1][2][0];
                GameObject temp3 = pieces[2][2][0];
                GameObject temp4 = pieces[0][2][1];
                GameObject temp5 = pieces[1][2][1];
                GameObject temp6 = pieces[2][2][1];
                GameObject temp7 = pieces[0][2][2];
                GameObject temp8 = pieces[1][2][2];
                GameObject temp9 = pieces[2][2][2];
                //
                pieces[0][2][0] = pieces[0][2][2];
                pieces[1][2][0] = pieces[1][2][2];
                pieces[2][2][0] = pieces[2][2][2];
                pieces[0][2][1] = pieces[0][1][2];
                pieces[1][2][1] = pieces[1][1][2];
                pieces[2][2][1] = pieces[2][1][2];
                pieces[0][2][2] = pieces[0][0][2];
                pieces[1][2][2] = pieces[1][0][2];
                pieces[2][2][2] = pieces[2][0][2];
                //
                pieces[0][2][2] = pieces[0][0][2];
                pieces[1][2][2] = pieces[1][0][2];
                pieces[2][2][2] = pieces[2][0][2];
                pieces[0][1][2] = pieces[0][0][1];
                pieces[1][1][2] = pieces[1][0][1];
                pieces[2][1][2] = pieces[2][0][1];
                pieces[0][0][2] = pieces[0][0][0];
                pieces[1][0][2] = pieces[1][0][0];
                pieces[2][0][2] = pieces[2][0][0];
                //
                pieces[0][0][2] = pieces[0][0][0];
                pieces[1][0][2] = pieces[1][0][0];
                pieces[2][0][2] = pieces[2][0][0];
                pieces[0][0][1] = pieces[0][1][0];
                pieces[1][0][1] = pieces[1][1][0];
                pieces[2][0][1] = pieces[2][1][0];
                pieces[0][0][0] = pieces[0][2][0];
                pieces[1][0][0] = pieces[1][2][0];
                pieces[2][0][0] = pieces[2][2][0];
                //
                pieces[0][0][0] = temp1;
                pieces[1][0][0] = temp2;
                pieces[2][0][0] = temp3;
                pieces[0][1][0] = temp4;
                pieces[1][1][0] = temp5;
                pieces[2][1][0] = temp6;
                pieces[0][2][0] = temp7;
                pieces[1][2][0] = temp8;
                pieces[2][2][0] = temp9;
            }        }*/
        return pieces;
    }
    //side rotations
    public List<List<List<GameObject>>> U(int x, int y, int z) //make a u method that takes in rotation so clock and counter is not necessary
    {
        pieces[0][2][0].transform.parent = pieces[1][2][1].transform;
        pieces[1][2][0].transform.parent = pieces[1][2][1].transform;
        pieces[2][2][0].transform.parent = pieces[1][2][1].transform;
        pieces[0][2][1].transform.parent = pieces[1][2][1].transform;
        pieces[2][2][1].transform.parent = pieces[1][2][1].transform;
        pieces[0][2][2].transform.parent = pieces[1][2][1].transform;
        pieces[1][2][2].transform.parent = pieces[1][2][1].transform;
        pieces[2][2][2].transform.parent = pieces[1][2][1].transform;
        pieces[1][2][1].transform.Rotate(x, y, z, Space.World);
        pieces[0][2][0].transform.parent = Cube.transform;
        pieces[1][2][0].transform.parent = Cube.transform;
        pieces[2][2][0].transform.parent = Cube.transform;
        pieces[0][2][1].transform.parent = Cube.transform;
        pieces[2][2][1].transform.parent = Cube.transform;
        pieces[0][2][2].transform.parent = Cube.transform;
        pieces[1][2][2].transform.parent = Cube.transform;
        pieces[2][2][2].transform.parent = Cube.transform;
        if (y < 0) //counter
        {
            GameObject temp = pieces[2][2][1];
            pieces[2][2][1] = pieces[1][2][2];
            pieces[1][2][2] = pieces[0][2][1];
            pieces[0][2][1] = pieces[1][2][0];
            pieces[1][2][0] = temp;
            temp = pieces[2][2][0];
            pieces[2][2][0] = pieces[2][2][2];
            pieces[2][2][2] = pieces[0][2][2];
            pieces[0][2][2] = pieces[0][2][0];
            pieces[0][2][0] = temp;
        }
        else if (y > 0) //clock 
        {
            GameObject temp = pieces[1][2][0];
            pieces[1][2][0] = pieces[0][2][1];
            pieces[0][2][1] = pieces[1][2][2];
            pieces[1][2][2] = pieces[2][2][1];
            pieces[2][2][1] = temp;
            temp = pieces[0][2][0];
            pieces[0][2][0] = pieces[0][2][2];
            pieces[0][2][2] = pieces[2][2][2];
            pieces[2][2][2] = pieces[2][2][0];
            pieces[2][2][0] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> D(int x, int y, int z)
    {
        pieces[0][0][0].transform.parent = pieces[1][0][1].transform;
        pieces[1][0][0].transform.parent = pieces[1][0][1].transform;
        pieces[2][0][0].transform.parent = pieces[1][0][1].transform;
        pieces[0][0][1].transform.parent = pieces[1][0][1].transform;
        pieces[2][0][1].transform.parent = pieces[1][0][1].transform;
        pieces[0][0][2].transform.parent = pieces[1][0][1].transform;
        pieces[1][0][2].transform.parent = pieces[1][0][1].transform;
        pieces[2][0][2].transform.parent = pieces[1][0][1].transform;
        pieces[1][0][1].transform.Rotate(x, y, z, Space.World);
        pieces[0][0][0].transform.parent = Cube.transform;
        pieces[1][0][0].transform.parent = Cube.transform;
        pieces[2][0][0].transform.parent = Cube.transform;
        pieces[0][0][1].transform.parent = Cube.transform;
        pieces[2][0][1].transform.parent = Cube.transform;
        pieces[0][0][2].transform.parent = Cube.transform;
        pieces[1][0][2].transform.parent = Cube.transform;
        pieces[2][0][2].transform.parent = Cube.transform;
        if (y < 0) //clock 
        {
            GameObject temp = pieces[1][0][2];
            pieces[1][0][2] = pieces[0][0][1];
            pieces[0][0][1] = pieces[1][0][0];
            pieces[1][0][0] = pieces[2][0][1];
            pieces[2][0][1] = temp;
            temp = pieces[0][0][2];
            pieces[0][0][2] = pieces[0][0][0];
            pieces[0][0][0] = pieces[2][0][0];
            pieces[2][0][0] = pieces[2][0][2];
            pieces[2][0][2] = temp;
        }
        else if (y > 0)
        {
            GameObject temp = pieces[1][0][2];
            pieces[1][0][2] = pieces[2][0][1];
            pieces[2][0][1] = pieces[1][0][0];
            pieces[1][0][0] = pieces[0][0][1];
            pieces[0][0][1] = temp;
            temp = pieces[0][0][2];
            pieces[0][0][2] = pieces[2][0][2];
            pieces[2][0][2] = pieces[2][0][0];
            pieces[2][0][0] = pieces[0][0][0];
            pieces[0][0][0] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> B(int x, int y, int z)
    {
        pieces[0][0][0].transform.parent = pieces[1][1][0].transform;
        pieces[1][0][0].transform.parent = pieces[1][1][0].transform;
        pieces[2][0][0].transform.parent = pieces[1][1][0].transform;
        pieces[0][1][0].transform.parent = pieces[1][1][0].transform;
        pieces[2][1][0].transform.parent = pieces[1][1][0].transform;
        pieces[0][2][0].transform.parent = pieces[1][1][0].transform;
        pieces[1][2][0].transform.parent = pieces[1][1][0].transform;
        pieces[2][2][0].transform.parent = pieces[1][1][0].transform;
        pieces[1][1][0].transform.Rotate(x, y, z, Space.World);
        pieces[0][0][0].transform.parent = Cube.transform;
        pieces[1][0][0].transform.parent = Cube.transform;
        pieces[2][0][0].transform.parent = Cube.transform;
        pieces[0][1][0].transform.parent = Cube.transform;
        pieces[2][1][0].transform.parent = Cube.transform;
        pieces[0][2][0].transform.parent = Cube.transform;
        pieces[1][2][0].transform.parent = Cube.transform;
        pieces[2][2][0].transform.parent = Cube.transform;
        if (x > 0)
        {
            GameObject temp = pieces[1][2][0];
            pieces[1][2][0] = pieces[2][1][0];
            pieces[2][1][0] = pieces[1][0][0];
            pieces[1][0][0] = pieces[0][1][0];
            pieces[0][1][0] = temp;
            temp = pieces[2][2][0];
            pieces[2][2][0] = pieces[2][0][0];
            pieces[2][0][0] = pieces[0][0][0];
            pieces[0][0][0] = pieces[0][2][0];
            pieces[0][2][0] = temp;
        }
        else if (x < 0)
        {
            GameObject temp = pieces[0][1][0];
            pieces[0][1][0] = pieces[1][0][0];
            pieces[1][0][0] = pieces[2][1][0];
            pieces[2][1][0] = pieces[1][2][0];
            pieces[1][2][0] = temp;
            temp = pieces[2][2][0];
            pieces[2][2][0] = pieces[0][2][0];
            pieces[0][2][0] = pieces[0][0][0];
            pieces[0][0][0] = pieces[2][0][0];
            pieces[2][0][0] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> F(int x, int y, int z)
    {
        pieces[0][2][2].transform.parent = pieces[1][1][2].transform;
        pieces[1][2][2].transform.parent = pieces[1][1][2].transform;
        pieces[2][2][2].transform.parent = pieces[1][1][2].transform;
        pieces[0][1][2].transform.parent = pieces[1][1][2].transform;
        pieces[2][1][2].transform.parent = pieces[1][1][2].transform;
        pieces[0][0][2].transform.parent = pieces[1][1][2].transform;
        pieces[1][0][2].transform.parent = pieces[1][1][2].transform;
        pieces[2][0][2].transform.parent = pieces[1][1][2].transform;
        pieces[1][1][2].transform.Rotate(x, y, z, Space.World);
        pieces[0][2][2].transform.parent = Cube.transform;
        pieces[1][2][2].transform.parent = Cube.transform;
        pieces[2][2][2].transform.parent = Cube.transform;
        pieces[0][1][2].transform.parent = Cube.transform;
        pieces[2][1][2].transform.parent = Cube.transform;
        pieces[0][0][2].transform.parent = Cube.transform;
        pieces[1][0][2].transform.parent = Cube.transform;
        pieces[2][0][2].transform.parent = Cube.transform;
        if (x < 0)
        {
            GameObject temp = pieces[1][2][2];
            pieces[1][2][2] = pieces[0][1][2];
            pieces[0][1][2] = pieces[1][0][2];
            pieces[1][0][2] = pieces[2][1][2];
            pieces[2][1][2] = temp;
            temp = pieces[0][2][2];
            pieces[0][2][2] = pieces[0][0][2];
            pieces[0][0][2] = pieces[2][0][2];
            pieces[2][0][2] = pieces[2][2][2];
            pieces[2][2][2] = temp;
        }
        else if (x > 0)
        {
            GameObject temp = pieces[1][2][2];
            pieces[1][2][2] = pieces[2][1][2];
            pieces[2][1][2] = pieces[1][0][2];
            pieces[1][0][2] = pieces[0][1][2];
            pieces[0][1][2] = temp;
            temp = pieces[0][2][2];
            pieces[0][2][2] = pieces[2][2][2];
            pieces[2][2][2] = pieces[2][0][2];
            pieces[2][0][2] = pieces[0][0][2];
            pieces[0][0][2] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> L(int x, int y, int z)
    {
        pieces[0][2][0].transform.parent = pieces[0][1][1].transform;
        pieces[0][2][1].transform.parent = pieces[0][1][1].transform;
        pieces[0][2][2].transform.parent = pieces[0][1][1].transform;
        pieces[0][1][0].transform.parent = pieces[0][1][1].transform;
        pieces[0][1][2].transform.parent = pieces[0][1][1].transform;
        pieces[0][0][0].transform.parent = pieces[0][1][1].transform;
        pieces[0][0][1].transform.parent = pieces[0][1][1].transform;
        pieces[0][0][2].transform.parent = pieces[0][1][1].transform;
        pieces[0][1][1].transform.Rotate(x, y, z, Space.World);
        pieces[0][2][0].transform.parent = Cube.transform;
        pieces[0][2][1].transform.parent = Cube.transform;
        pieces[0][2][2].transform.parent = Cube.transform;
        pieces[0][1][0].transform.parent = Cube.transform;
        pieces[0][1][2].transform.parent = Cube.transform;
        pieces[0][0][0].transform.parent = Cube.transform;
        pieces[0][0][1].transform.parent = Cube.transform;
        pieces[0][0][2].transform.parent = Cube.transform;
        if (z > 0)
        {
            GameObject temp = pieces[0][2][1];
            pieces[0][2][1] = pieces[0][1][0];
            pieces[0][1][0] = pieces[0][0][1];
            pieces[0][0][1] = pieces[0][1][2];
            pieces[0][1][2] = temp;
            temp = pieces[0][2][0];
            pieces[0][2][0] = pieces[0][0][0];
            pieces[0][0][0] = pieces[0][0][2];
            pieces[0][0][2] = pieces[0][2][2];
            pieces[0][2][2] = temp;
        }
        else if (z < 0)
        {
            GameObject temp = pieces[0][2][1];
            pieces[0][2][1] = pieces[0][1][2];
            pieces[0][1][2] = pieces[0][0][1];
            pieces[0][0][1] = pieces[0][1][0];
            pieces[0][1][0] = temp;
            temp = pieces[0][2][0];
            pieces[0][2][0] = pieces[0][2][2];
            pieces[0][2][2] = pieces[0][0][2];
            pieces[0][0][2] = pieces[0][0][0];
            pieces[0][0][0] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> R(int x, int y, int z)
    {
        pieces[2][2][0].transform.parent = pieces[2][1][1].transform;
        pieces[2][2][1].transform.parent = pieces[2][1][1].transform;
        pieces[2][2][2].transform.parent = pieces[2][1][1].transform;
        pieces[2][1][0].transform.parent = pieces[2][1][1].transform;
        pieces[2][1][2].transform.parent = pieces[2][1][1].transform;
        pieces[2][0][0].transform.parent = pieces[2][1][1].transform;
        pieces[2][0][1].transform.parent = pieces[2][1][1].transform;
        pieces[2][0][2].transform.parent = pieces[2][1][1].transform;
        pieces[2][1][1].transform.Rotate(x, y, z, Space.World);
        pieces[2][2][0].transform.parent = Cube.transform;
        pieces[2][2][1].transform.parent = Cube.transform;
        pieces[2][2][2].transform.parent = Cube.transform;
        pieces[2][1][0].transform.parent = Cube.transform;
        pieces[2][1][2].transform.parent = Cube.transform;
        pieces[2][0][0].transform.parent = Cube.transform;
        pieces[2][0][1].transform.parent = Cube.transform;
        pieces[2][0][2].transform.parent = Cube.transform;
        //put stuff here 
        if (z < 0)
        {
            GameObject temp = pieces[2][2][1];
            pieces[2][2][1] = pieces[2][1][2];
            pieces[2][1][2] = pieces[2][0][1];
            pieces[2][0][1] = pieces[2][1][0];
            pieces[2][1][0] = temp;
            temp = pieces[2][2][2];
            pieces[2][2][2] = pieces[2][0][2];
            pieces[2][0][2] = pieces[2][0][0];
            pieces[2][0][0] = pieces[2][2][0];
            pieces[2][2][0] = temp;
        }
        else if (z > 0)
        {
            GameObject temp = pieces[2][2][1];
            pieces[2][2][1] = pieces[2][1][0];
            pieces[2][1][0] = pieces[2][0][1];
            pieces[2][0][1] = pieces[2][1][2];
            pieces[2][1][2] = temp;
            temp = pieces[2][2][2];
            pieces[2][2][2] = pieces[2][2][0];
            pieces[2][2][0] = pieces[2][0][0];
            pieces[2][0][0] = pieces[2][0][2];
            pieces[2][0][2] = temp;
        }
        return pieces;
    }
    //double turns
    public List<List<List<GameObject>>> u(bool clockwise)
    {
        if (clockwise)
        {
            pieces = U(0, 90, 0);
            pieces = E(0, 90, 0);
        }
        else
        {
            pieces = U(0, -90, 0);
            pieces = E(0, -90, 0);
        }
        return pieces;
    }
    public List<List<List<GameObject>>> d(bool clockwise)
    {
        if (clockwise)
        {
            pieces = D(0, -90, 0);
            pieces = E(0, -90, 0);
        }
        else
        {
            pieces = D(0, 90, 0);
            pieces = E(0, 90, 0);
        }
        return pieces;
    }
    public List<List<List<GameObject>>> b(bool clockwise)
    {
        if (clockwise)
        {
            pieces = S(90, 0, 0);
            pieces = B(90, 0, 0);
        }
        else
        {
            pieces = S(-90, 0, 0);
            pieces = B(-90, 0, 0);
        }
        return pieces;
    }
    public List<List<List<GameObject>>> f(bool clockwise)
    {
        if (clockwise)
        {
            pieces = F(-90, 0, 0);
            pieces = S(-90, 0, 0);
        }
        else
        {
            pieces = F(90, 0, 0);
            pieces = S(90, 0, 0);
        }
        return pieces;
    }
    public List<List<List<GameObject>>> l(bool clockwise)
    {
        if (clockwise)
        {
            pieces = L(0, 0, 90);
            pieces = M(0, 0, 90);
        }
        else
        {
            pieces = L(0, 0, -90);
            pieces = M(0, 0, -90);
        }
        return pieces;
    }
    public List<List<List<GameObject>>> r(bool clockwise)
    {
        if (clockwise)
        {
            pieces = R(0, 0, -90);
            pieces = M(0, 0, -90);
        }
        else
        {
            pieces = R(0, 0, 90);
            pieces = M(0, 0, 90);
        }
        return pieces;
    }
    //mid layer turns 
    public List<List<List<GameObject>>> S(int x, int y, int z)
    {
        pieces[0][2][1].transform.parent = Middle.transform;
        pieces[1][2][1].transform.parent = Middle.transform;
        pieces[2][2][1].transform.parent = Middle.transform;
        pieces[0][1][1].transform.parent = Middle.transform;
        pieces[2][1][1].transform.parent = Middle.transform;
        pieces[0][0][1].transform.parent = Middle.transform;
        pieces[1][0][1].transform.parent = Middle.transform;
        pieces[2][0][1].transform.parent = Middle.transform;
        Middle.transform.Rotate(x, y, z, Space.World);
        pieces[0][2][1].transform.parent = Cube.transform;
        pieces[1][2][1].transform.parent = Cube.transform;
        pieces[2][2][1].transform.parent = Cube.transform;
        pieces[0][1][1].transform.parent = Cube.transform;
        pieces[2][1][1].transform.parent = Cube.transform;
        pieces[0][0][1].transform.parent = Cube.transform;
        pieces[1][0][1].transform.parent = Cube.transform;
        pieces[2][0][1].transform.parent = Cube.transform;
        if (x < 0)
        {
            GameObject temp = pieces[1][2][1];
            pieces[1][2][1] = pieces[0][1][1];
            pieces[0][1][1] = pieces[1][0][1];
            pieces[1][0][1] = pieces[2][1][1];
            pieces[2][1][1] = temp;
            temp = pieces[0][2][1];
            pieces[0][2][1] = pieces[0][0][1];
            pieces[0][0][1] = pieces[2][0][1];
            pieces[2][0][1] = pieces[2][2][1];
            pieces[2][2][1] = temp;
        }
        else if (x > 0)
        {
            GameObject temp = pieces[1][2][1];
            pieces[1][2][1] = pieces[2][1][1];
            pieces[2][1][1] = pieces[1][0][1];
            pieces[1][0][1] = pieces[0][1][1];
            pieces[0][1][1] = temp;
            temp = pieces[0][2][1];
            pieces[0][2][1] = pieces[2][2][1];
            pieces[2][2][1] = pieces[2][0][1];
            pieces[2][0][1] = pieces[0][0][1];
            pieces[0][0][1] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> E(int x, int y, int z)
    {
        pieces[0][1][0].transform.parent = Middle.transform;
        pieces[1][1][0].transform.parent = Middle.transform;
        pieces[2][1][0].transform.parent = Middle.transform;
        pieces[0][1][1].transform.parent = Middle.transform;
        pieces[2][1][1].transform.parent = Middle.transform;
        pieces[0][1][2].transform.parent = Middle.transform;
        pieces[1][1][2].transform.parent = Middle.transform;
        pieces[2][1][2].transform.parent = Middle.transform;
        Middle.transform.Rotate(x, y, z, Space.World);
        pieces[0][1][0].transform.parent = Cube.transform;
        pieces[1][1][0].transform.parent = Cube.transform;
        pieces[2][1][0].transform.parent = Cube.transform;
        pieces[0][1][1].transform.parent = Cube.transform;
        pieces[2][1][1].transform.parent = Cube.transform;
        pieces[0][1][2].transform.parent = Cube.transform;
        pieces[1][1][2].transform.parent = Cube.transform;
        pieces[2][1][2].transform.parent = Cube.transform;
        if (y < 0)
        {
            GameObject temp = pieces[2][1][1];
            pieces[2][1][1] = pieces[1][1][2];
            pieces[1][1][2] = pieces[0][1][1];
            pieces[0][1][1] = pieces[1][1][0];
            pieces[1][1][0] = temp;
            temp = pieces[2][1][0];
            pieces[2][1][0] = pieces[2][1][2];
            pieces[2][1][2] = pieces[0][1][2];
            pieces[0][1][2] = pieces[0][1][0];
            pieces[0][1][0] = temp;
        }
        else if (y > 0)
        {
            GameObject temp = pieces[1][1][0];
            pieces[1][1][0] = pieces[0][1][1];
            pieces[0][1][1] = pieces[1][1][2];
            pieces[1][1][2] = pieces[2][1][1];
            pieces[2][1][1] = temp;
            temp = pieces[0][1][0];
            pieces[0][1][0] = pieces[0][1][2];
            pieces[0][1][2] = pieces[2][1][2];
            pieces[2][1][2] = pieces[2][1][0];
            pieces[2][1][0] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> M(int x, int y, int z)
    {
        pieces[1][2][2].transform.parent = Middle.transform;
        pieces[1][2][1].transform.parent = Middle.transform;
        pieces[1][2][0].transform.parent = Middle.transform;
        pieces[1][1][2].transform.parent = Middle.transform;
        pieces[1][1][0].transform.parent = Middle.transform;
        pieces[1][0][2].transform.parent = Middle.transform;
        pieces[1][0][1].transform.parent = Middle.transform;
        pieces[1][0][0].transform.parent = Middle.transform;
        Middle.transform.Rotate(x, y, z, Space.World);
        pieces[1][2][2].transform.parent = Cube.transform;
        pieces[1][2][1].transform.parent = Cube.transform;
        pieces[1][2][0].transform.parent = Cube.transform;
        pieces[1][1][2].transform.parent = Cube.transform;
        pieces[1][1][0].transform.parent = Cube.transform;
        pieces[1][0][2].transform.parent = Cube.transform;
        pieces[1][0][1].transform.parent = Cube.transform;
        pieces[1][0][0].transform.parent = Cube.transform;
        if (z < 0)
        {
            GameObject temp = pieces[1][2][1];
            pieces[1][2][1] = pieces[1][1][2];
            pieces[1][1][2] = pieces[1][0][1];
            pieces[1][0][1] = pieces[1][1][0];
            pieces[1][1][0] = temp;
            temp = pieces[1][2][2];
            pieces[1][2][2] = pieces[1][0][2];
            pieces[1][0][2] = pieces[1][0][0];
            pieces[1][0][0] = pieces[1][2][0];
            pieces[1][2][0] = temp;
        }
        else if (z > 0)
        {
            GameObject temp = pieces[1][2][1];
            pieces[1][2][1] = pieces[1][1][0];
            pieces[1][1][0] = pieces[1][0][1];
            pieces[1][0][1] = pieces[1][1][2];
            pieces[1][1][2] = temp;
            temp = pieces[1][2][2];
            pieces[1][2][2] = pieces[1][2][0];
            pieces[1][2][0] = pieces[1][0][0];
            pieces[1][0][0] = pieces[1][0][2];
            pieces[1][0][2] = temp;
        }
        return pieces;
    }
    public List<List<List<GameObject>>> RALG()    {        pieces = R(0, 0, -90);        pieces = U(0, 90, 0);        pieces = R(0, 0, 90);        pieces = U(0, -90, 0);        return pieces;    }
    public List<List<List<GameObject>>> LALG()    {        pieces = L(0, 0, -90);        pieces = U(0, -90, 0);        pieces = L(0, 0, 90);        pieces = U(0, 90, 0);        return pieces;    }
}