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

        for (int x = 0; x < 3; x++)
        {
            List<List<bool>> twoDim = new List<List<bool>>();
            for (int y = 0; y < 3; y++)
            {
                List<bool> oneDim = new List<bool>();
                for (int z = 0; z < 3; z++)
                {
                    oneDim.Add(false);
                }
                twoDim.Add(oneDim);
            }
            position.Add(twoDim);
            orientation.Add(twoDim);
        }

        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();
    }

    // Update is called once per frame
    void Update()
    {    }
    public void scramble()
    {
        rotateBigCube.U(0, -90, 0);
        rotateBigCube.B(-90, 0, 0);
        rotateBigCube.R(0, 0, -90);
        rotateBigCube.F(90, 0, 0);
        rotateBigCube.L(0, 0, -90);
        rotateBigCube.B(-90, 0, 0);
    }

    List<int> searching(GameObject piece, List<List<List<GameObject>>> pieces)
    {
        List<int> objectIndex = new List<int>();
        int x = 0;
        int y = 0;
        int z = 0;
        while (true)
        {
            //Debug.Log("Index: " + x + "," + y + "," + z);
            if (pieces[x][y][z] == piece)
            {
                Debug.Log("Object: " + piece + "found at: " + x + ", " + y + ", " + z);
                objectIndex.Add(x);
                objectIndex.Add(y);
                objectIndex.Add(z);
                break;
            }
            else
            {
                if (x >= 2)
                {
                    x = 0;
                    y++;
                    if (y > 2)
                    {
                        y = 0;
                        z++;
                        if (z > 2)
                        {
                            //Debug.Log("Fully searched!");
                            break;
                        }
                    }
                }
                else
                {
                    x++;
                }
            }        }

        return objectIndex;
    }
    public List<List<List<GameObject>>> whiteCross(List<List<List<GameObject>>> pieces)
    {
        //first check if it is solved
        List<int> objectIndex = new List<int>();
        //WB PIECE
        objectIndex = searching(WB, pieces);
        if (objectIndex[0] == 2 && objectIndex[1] == 2 && objectIndex[2] == 1)
        {
            position[2][2][1] = true;
            //check if orientation is correct using coordinates
            //if up is greater y value than left
            float y1 = WB_W.transform.position.y;
            float y2 = WB_B.transform.position.y;
            if (y1 > y2)
            {
                Debug.Log("The WB piece is already correct");
                orientation[2][2][1] = true;
            }
            else
            {
                Debug.Log("The WB piece is in the right position but incorrectly oriented");
                //R, R, D, B, R', B'
                pieces = rotateBigCube.R(0, 0, -90);
                pieces = rotateBigCube.R(0, 0, -90);
                pieces = rotateBigCube.D(0, -90, 0);
                pieces = rotateBigCube.B(90, 0, 0);
                pieces = rotateBigCube.R(0, 0, 90);
                pieces = rotateBigCube.B(-90, 0, 0);
            }
        }
        else if (objectIndex[1] == 2) //else if its in the wrong spot in the top
        {
            //rotate is down to bottom layer, deal with orientation accordingly
            if (WB_W.transform.position.y > WB_B.transform.position.y) //correct orientation
            {
                if (objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the red face");
                    //F, F, D, R, R
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //green
                {
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the green face");
                    //L, L, D, D, R, R
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[2] == 0) //orange
                {
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the orange face");
                    //B, B, D', R, R
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
            else //incorrect orientation
            {
                if (objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the red face");
                    //F, R
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //green
                {
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the green face");
                    //L, L, D, F', R, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[2] == 0) //orange
                {
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the orange face");
                    //B', R'
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
        }
        else if (objectIndex[1] == 1) //if it is in the second layer
        {
            //if it's adjacent to the proper face
            if (objectIndex[0] == 2) //if its adjacent
            {
                if (objectIndex[2] == 2)
                {
                    if (WB_B.transform.position.z < WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the blue face and the red face");
                        //R
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjecant with the blue face and the red face");
                        //F, D, F', R, R
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                }
                else if (objectIndex[2] == 0)
                {
                    if (WB_B.transform.position.z > WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the blue face and the orange face");
                        //R'
                        pieces = rotateBigCube.R(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjecant with the blue face and the orange face");
                        //B', D', D, R, R
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                }
            }
            else if (objectIndex[0] == 0)//if it is not adjacent
            {
                if (objectIndex[2] == 2)
                {
                    if (WB_B.transform.position.z < WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the green face and the red face");
                        //L, D, L', D, R, R <--this works but switching from inserting the edge piece and moving the piece at 0, 2, 1 back up might be confusing
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjacant with the green face and the red face");
                        //F', D, F, R, R
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                }
                else if (objectIndex[2] == 0)
                {
                    if (WB_B.transform.position.z > WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjacent with the green face and the orange face");
                        //B', B', R', B', B'
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.B(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjacent with the green face and the orange face");
                        //B, D', R, R, B'
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                    }
                }
            }
        }
        else if (objectIndex[1] == 0)
        {
            //oriented correctly
            if (WB_B.transform.position.y > WB_W.transform.position.y)
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to blue face");
                    //R, R
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to green face");
                    //D, D, R, R
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to red face");
                    //D, R, R
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to orange face");
                    //D', R, R
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
            //oriented incorrectly
            else
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to blue face");
                    //D', F', R, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to green face");
                    //D, F', R, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to red face");
                    //F', R, F
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to orange face");
                    //B, R', B' //verify
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
            }
        }
        //WG
        objectIndex = searching(WG, pieces);
        if (objectIndex[0] == 0 && objectIndex[1] == 2 && objectIndex[2] == 1)
        {
            position[0][2][1] = true;
            //check if orientation is correct using coordinates
            //if up is greater y value than left
            float y1 = WG_W.transform.position.y;
            float y2 = WG_G.transform.position.y;
            if (y1 > y2)
            {
                Debug.Log("The WG piece is correct");
                orientation[0][2][1] = true;
            }
            else
            {
                Debug.Log("The WG piece is correctly positioned but incorrectly oriented");
                //L', L', D', B', L, B
                pieces = rotateBigCube.L(0, 0, -90);
                pieces = rotateBigCube.L(0, 0, -90);
                pieces = rotateBigCube.D(0, 90, 0);
                pieces = rotateBigCube.B(-90, 0, 0);
                pieces = rotateBigCube.L(0, 0, 90);
                pieces = rotateBigCube.B(90, 0, 0);
            }
        }
        else if (objectIndex[1] == 2) //else if its in the wrong spot in the top
        {
            //rotate is down to bottom layer, deal with orientation accordingly
            if (WG_W.transform.position.y > WG_G.transform.position.y) //correct orientation
            {
                if (objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the red face");
                    //F, F, D', L, L
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[2] == 1) //blue
                {
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the blue face");
                    //R, R, D', D', L, L
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[2] == 0) //orange
                {
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the orange face");
                    //B, B, D, L, L
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
            else //incorrect orientation
            {
                if (objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the red face");
                    //F', L'
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //blue
                {
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the blue face");
                    //R', F, D', L, L, F'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[2] == 0) //orange
                {
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the orange face");
                    //B, L
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
        }
        else if (objectIndex[1] == 1) //if it is in the second layer
        {
            //if it's adjacent to the proper face
            if (objectIndex[0] == 0) //if its adjacent
            {
                if (objectIndex[2] == 2)
                {
                    if (WG_G.transform.position.z < WG_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the green face and along the red face");
                        //L'
                        pieces = rotateBigCube.L(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the green face and along the red face");
                        //F', D', F, L, L
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                }
                else if (objectIndex[2] == 0)
                {
                    if (WG_G.transform.position.z > WG_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the green face and along the orange face");
                        //L
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the green face and along the orange face");
                        //B, D, B', L, L
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                }
            }
            else if (objectIndex[0] == 2)//if it is not adjacent
            {
                if (objectIndex[2] == 2)
                {
                    if (WG_G.transform.position.z < WG_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the blue face and along the red face");
                        //F', F', L', F', F'
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the blue face and along the red face");
                        //F, D', F', L, L
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                }
                else if (objectIndex[2] == 0)
                {
                    if (WG_G.transform.position.z > WG_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the blue face and along the orange face");
                        //B, B, L, B, B
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the blue face and along the orange face");
                        //B', D, L, L, B
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                }
            }
        }
        else if (objectIndex[1] == 0) //bottom layer
        {
            //oriented correctly
            if (WG_G.transform.position.y > WG_W.transform.position.y)
            {
                if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the green face");
                    //L, L
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the blue face");
                    //D', D', L, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the red face");
                    //D', L, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the orange face");
                    //D, L, L
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
            //oriented incorrectly
            else
            {
                if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the green face");
                    //D, F, L', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the blue face");
                    //D', F, L', F'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the red face");
                    //F, L', F'
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the orange face");
                    //B', L, B
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
        }
        //WR
        objectIndex = searching(WR, pieces);
        if (objectIndex[0] == 1 && objectIndex[1] == 2 && objectIndex[2] == 2)
        {
            position[1][2][2] = true;
            //check if orientation is correct using coordinates
            //if up is greater y value than left
            float y1 = WR_W.transform.position.y;
            float y2 = WR_R.transform.position.y;
            if (y1 > y2)
            {
                Debug.Log("The WR piece is correct");
                orientation[1][2][2] = true;
            }
            else
            {
                Debug.Log("The WR piece is correctly positioned but not correctly oriented");
                //F, F, D, R, F', R'
                pieces = rotateBigCube.F(-90, 0, 0);
                pieces = rotateBigCube.F(-90, 0, 0);
                pieces = rotateBigCube.D(0, -90, 0);
                pieces = rotateBigCube.R(0, 0, -90);
                pieces = rotateBigCube.F(90, 0, 0);
                pieces = rotateBigCube.R(0, 0, 90);
            }
        }
        else if (objectIndex[1] == 2) //else if its in the wrong spot in the top
        {
            //rotate is down to bottom layer, deal with orientation accordingly
            if (WR_W.transform.position.y > WR_R.transform.position.y) //correct orientation
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the blue face");
                    //R, R, D', F, F
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the green face");
                    //L, L, D, F, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1) //orange
                {
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the orange face");
                    //B', B', D', D', F, F
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
            else //incorrect orientation
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the blue face");
                    //R', F' 
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the green face");
                    //L, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1) //orange
                {
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the orange face");
                    //B', R, D', F, F, R'
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
        }
        else if (objectIndex[1] == 1) //if it is in the second layer
        {
            //if it's adjacent to the proper face
            if (objectIndex[2] == 2) //if its adjacent
            {
                if (objectIndex[0] == 2)
                {
                    if (WR_R.transform.position.x < WR_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the red face and along the blue face");
                        //F'
                        pieces = rotateBigCube.F(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the red face and along the blue face");
                        //R', D', R, F, F
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                }
                else if (objectIndex[0] == 0)
                {
                    if (WR_R.transform.position.x > WR_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the red face and along the green face");
                        //F
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the red face and along the green face");
                        //L, D, L', F, F
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                }
            }
            else if (objectIndex[2] == 0)//if it is not adjacent
            {
                if (objectIndex[0] == 2)
                {
                    if (WR_R.transform.position.x < WR_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the orange face and along the blue face");
                        //R', R', F', R', R'
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.R(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the orange face and along the blue face");
                        //R, D', R', F, F
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                }
                else if (objectIndex[0] == 0)
                {
                    if (WR_R.transform.position.x > WR_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the orange face and along the green face");
                        //L, L, F, L, L
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the orange face and along the green face");
                        //L', D, L, F, F
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                }
            }
        }
        else if (objectIndex[1] == 0)
        {
            //oriented correctly
            if (WR_R.transform.position.y > WR_W.transform.position.y)
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the blue face");
                    //D', F, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the green face");
                    //D, F, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the red face");
                    //F, F
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the orange face");
                    //D', D', F, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
            //oriented incorrectly
            else
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the blue face");
                    //R, F', R'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the green face");
                    //L', F, L
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the red face");
                    //D, R, F', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the orange face");
                    //D', R, F', R'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
        }
        //WO
        objectIndex = searching(WO, pieces);
        if (objectIndex[0] == 1 && objectIndex[1] == 2 && objectIndex[2] == 0)
        {
            position[1][2][0] = true;
            //check if orientation is correct using coordinates
            //if up is greater y value than left
            float y1 = WO_W.transform.position.y;
            float y2 = WO_O.transform.position.y;
            if (y1 > y2)
            {
                Debug.Log("The WO pice is correct");
                orientation[1][2][0] = true;
            }
            else
            {
                Debug.Log("The WO piece is correctly positioned but incorrectly oriented");
                //B', B', D', R', B, R
                pieces = rotateBigCube.B(-90, 0, 0);
                pieces = rotateBigCube.B(-90, 0, 0);
                pieces = rotateBigCube.D(0, 90, 0);
                pieces = rotateBigCube.R(0, 0, 90);
                pieces = rotateBigCube.B(90, 0, 0);
                pieces = rotateBigCube.R(0, 0, -90);
            }
        }
        else if (objectIndex[1] == 2) //else if its in the wrong spot in the top
        {
            //rotate is down to bottom layer, deal with orientation accordingly
            if (WO_W.transform.position.y > WO_O.transform.position.y) //correct orientation
            {
                if (objectIndex[0] == 1) //red
                {
                    Debug.Log("The WO piece is correcly oriented on the top layer on the red face");
                    //F, F, D, D, B, B
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is correcly oriented on the top layer on the green face");
                    //L', L', D', B, B
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is correcly oriented on the top layer on the blue face");
                    //R, R, D, B, B
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
            else //incorrect orientation
            {
                if (objectIndex[0] == 1) //red
                {
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the red face");
                    //F, F, D, R', B, R
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the green face");
                    //L', B'
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the blue face");
                    //R, B
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
        }
        else if (objectIndex[1] == 1) //if it is in the second layer
        {
            //if it's adjacent to the proper face
            if (objectIndex[2] == 0) //if its adjacent
            {
                if (objectIndex[0] == 2)
                {
                    if (WO_O.transform.position.x < WO_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the orange face along the blue face");
                        //B
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the orange face along the blue face");
                        //R, D, R', B, B
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                }
                else if (objectIndex[0] == 0)
                {
                    if (WO_O.transform.position.x > WO_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the orange face along the green face");
                        //B'
                        pieces = rotateBigCube.B(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the orange face along the green face");
                        //L', B', L, B, B
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                }
            }
            else if (objectIndex[2] == 2)//if it is not adjacent
            {
                if (objectIndex[0] == 2)
                {
                    if (WO_O.transform.position.x < WO_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on th esecond layer and adjacent to the red face along the blue face");
                        //R, R, B, R, R
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the red face along the blue face");
                        //F, D, F', R', B, R
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.D(0, -90, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                }
                else if (objectIndex[0] == 0)
                {
                    if (WO_O.transform.position.x > WO_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the red face along the green face");
                        //L', L', B', L', L'
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.L(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the red face along the green face");
                        //F', D', F, L, B', L'
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                    }
                }
            }
        }
        else if (objectIndex[1] == 0) //bottom layer
        {
            //oriented correctly
            if (WO_O.transform.position.y > WO_W.transform.position.y)
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the blue face");
                    //D, B, B
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the green face");
                    //D', B, B
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the red face");
                    //D, D, B, B
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the orange face");
                    //B, B
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
            //oriented incorrectly
            else
            {
                if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the blue face");
                    //R', B, R
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the green face");
                    //L, B', L'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the red face");
                    //D', L, B', L'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the orange face");
                    //D, L, B', L'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
            }
        }
        return pieces;
    }
}