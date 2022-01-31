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
    {

    }
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
                //Debug.Log("Object: " + piece + "found at: " + x + ", " + y + ", " + z);
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
            }

        }

        return objectIndex;
    }
    public List<List<List<GameObject>>> whiteCross(List<List<List<GameObject>>> pieces)
    {
        //first check if it is solved
        List<int> objectIndex = new List<int>();

        //CENTER PIECE
        /*if (Up.transform.position.y < Down.transform.position.y) //down is up and up is down
        {
            //rotate twice on the z axis
            rotateBigCube.fullRotation(0, 0, 180);
        }
        else if (Up.transform.position.y == Down.transform.position.y) //middle layer
        {
            //rotate once on the z axis (positively)?
            rotateBigCube.fullRotation(0, 0, 90);
        }

        if (Front.transform.position.z < Back.transform.position.z) //ront is back and back is front
        {
            //rotate twice on the y axis
            rotateBigCube.fullRotation(0, 180, 0);
        }
        else if (Front.transform.position.z == Back.transform.position.z)
        {
            if (Left.transform.position.z > Right.transform.position.z) //green is in the front
            {
                //rotate once (positively?) on the y axis
                rotateBigCube.fullRotation(0, 90, 0);
            }
            else //blue is in the front
            {
                //rotate once the other way on the y axis
                rotateBigCube.fullRotation(0, -90, 0);
            }
        }*/
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
                Debug.Log("The WB piece is in the right position but incorrectly oriented\nR, R, D, B, R', B'");
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
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the red face\nF, F, D, R, R");
                    //F, F, D, R, R
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //green
                {
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the green face\nL, L, D, D, R, R");
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
                    Debug.Log("The WB piece is correctly oriented on the lop layer of the orange face\nB, B, D', R, R");
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
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the red face\nF, R");
                    //F, R
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //green
                {
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the green face\nL, L, D, F', R, F");
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
                    Debug.Log("The WB piece is incorrectly oriented on the lop layer of the orange face\nB', R'");
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
                    if (WB_B.transform.position.z < WB_W.transform.position.z) //if the position is correct (adj orange)
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the blue face and the red face\nR");
                        //R
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjecant with the blue face and the red face\nF, D, F', R, R");
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
                    if (WB_B.transform.position.z < WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the blue face and the orange face\nR'");
                        //R'
                        pieces = rotateBigCube.R(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjecant with the blue face and the orange face\nB', D', B, R, R");
                        //B', D', B, R, R
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                }
            }
            else if (objectIndex[0] == 0)//if it is not adjacent
            {
                if (objectIndex[2] == 2)
                {
                    if (WB_B.transform.position.z > WB_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjecant with the green face and the red face\nL, D, L', D, R, R");
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
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjacant with the green face and the red face\nF', D, F, R, R");
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
                        Debug.Log("The WB piece is correctly oriented and in the second layer and adjacent with the green face and the orange face\nB', B', R', B', B'");
                        //B', B', R', B', B'
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.B(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WB piece is incorrectly oriented and in the second layer and adjacent with the green face and the orange face\nB, D', R, R, B'");
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
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to blue face\nR, R");
                    //R, R
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to green face\nD, D, R, R");
                    //D, D, R, R
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to red face\nD, R, R");
                    //D, R, R
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WB piece is correctly oriented and in the bottom layer adjacent to orange face\nD', R, R");
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
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to blue face\nD', F', R, F");
                    //D', F', R, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to green face\nD, F', R, F");
                    //D, F', R, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to red face\nF', R, F");
                    //F', R, F
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WB piece is incorrectly oriented and in the bottom layer adjacent to orange face\nB, R', B'");
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
                Debug.Log("The WG piece is correctly positioned but incorrectly oriented\nL', L', D', B', L, B");
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
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the red face\nF, F, D', L, L");
                    //F, F, D', L, L
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[2] == 1) //blue
                {
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the blue face\nR, R, D', D', L, L");
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
                    Debug.Log("The WG piece is correctly oriented in the top layer adjacent to the orange face\nB, B, D, L, L");
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
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the red face\nF', L'");
                    //F', L'
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[2] == 1) //blue
                {
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the blue face\nR', F, D', L, L, F'");
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
                    Debug.Log("The WG piece is incorrectly oriented in the top layer adjacent to the orange face\nB, L");
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
                    if (WG_G.transform.position.z > WG_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the green face and along the red face\nL'");
                        //L'
                        pieces = rotateBigCube.L(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the green face and along the red face\nF', D', F, L, L");
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
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the green face and along the orange face\nL");
                        //L
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the green face and along the orange face\nB, D, B', L, L");
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
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the blue face and along the red face\nF', F', L', F', F'");
                        //F', F', L', F', F'
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.F(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the blue face and along the red face\nF, D', F', L, L");
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
                        Debug.Log("The WG piece is correctly oriented in the second layer adjacent to the blue face and along the orange face\nB, B, L, B, B");
                        //B, B, L, B, B
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WG piece is incorrectly oriented in the second layer adjacent to the blue face and along the orange face\nB', D, L, L, B");
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
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the green face\nL, L");
                    //L, L
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the blue face\nD', D', L, L");
                    //D', D', L, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the red face\nD', L, L");
                    //D', L, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WG piece is correctly oriented in the bottom layer adjacent to the orange face\nD, L, L");
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
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the green face\nD, F, L', F'");
                    //D, F, L', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the blue face\nD', F, L', F'");
                    //D', F, L', F'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the red face\nF, L', F'");
                    //F, L', F'
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WG piece is incorrectly oriented in the bottom layer adjacent to the orange face\nB', L, B");
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
                Debug.Log("The WR piece is correctly positioned but not correctly oriented\nF, F, D, R, F', R'");
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
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the blue face\nR, R, D', F, F");
                    //R, R, D', F, F
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the green face\nL, L, D, F, F");
                    //L, L, D, F, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1) //orange
                {
                    Debug.Log("The WR piece is correctly oriented in the top layer adjacent to the orange face\nB', B', D', D', F, F");
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
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the blue face\nR', F'");
                    //R', F' 
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the green face\nL, F");
                    //L, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1) //orange
                {
                    Debug.Log("The WR piece is incorrectly oriented in the top layer adjacent to the orange face\nB', R, D', F, F, R'");
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
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the red face and along the blue face\nF'");
                        //F'
                        pieces = rotateBigCube.F(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the red face and along the blue face\nR', D', R, F, F");
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
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the red face and along the green face\nF");
                        //F
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the red face and along the green face\nL, D, L', F, F");
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
                    if (WR_R.transform.position.x > WR_W.transform.position.x) //if the position is correct SHOULD BE OPPOSITE?
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the orange face and along the blue face\nR', R', F', R', R'");
                        //R', R', F', R', R'
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.F(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.R(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the orange face and along the blue face\nR, D', R', F, F"); //SOMETHING WRONG?
                        //R, D', R', F, F
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.D(0, 90, 0);
                        pieces = rotateBigCube.R(0, 0, 90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.F(-90, 0, 0);
                    }
                }
                else if (objectIndex[0] == 0)
                {
                    if (WR_R.transform.position.x > WR_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WR piece is correctly oriented in the second layer adjacent to the orange face and along the green face\nL, L, F, L, L");
                        //L, L, F, L, L
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.F(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, 90);
                        pieces = rotateBigCube.L(0, 0, 90);
                    }
                    else
                    {
                        Debug.Log("The WR piece is incorrectly oriented in the second layer adjacent to the orange face and along the green face\nL', D, L, F, F");
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
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the blue face\nD', F, F");
                    //D', F, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the green face\nD, F, F");
                    //D, F, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the red face\nF, F");
                    //F, F
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WR piece is correctly oriented on the bottom layer adjacent to the orange face\nD', D', F, F");
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
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the blue face\nR, F', R'");
                    //R, F', R'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the green face\nL', F, L");
                    //L', F, L
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the red face\nD, R, F', R'");
                    //D, R, F', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WR piece is incorrectly oriented on the bottom layer adjacent to the orange face\nD', R, F', R'");
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
                Debug.Log("The WO piece is correctly positioned but incorrectly oriented\nB', B', D', R', B, R");
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
                    Debug.Log("The WO piece is correcly oriented on the top layer on the red face\nF, F, D, D, B, B");
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
                    Debug.Log("The WO piece is correcly oriented on the top layer on the green face\nL', L', D', B, B");
                    //L', L', D', B, B
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is correcly oriented on the top layer on the blue face\nR, R, D, B, B");
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
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the red face\nF, F, D, R', B, R");
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
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the green face\nL', B'");
                    //L', B'
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (objectIndex[0] == 2) //blue
                {
                    Debug.Log("The WO piece is incorrecly oriented on the top layer on the blue face\nR, B");
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
                    if (WO_O.transform.position.x > WO_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the orange face along the blue face\nB");
                        //B
                        pieces = rotateBigCube.B(90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the orange face along the blue face\nR, D, R', B, B");
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
                    if (WO_O.transform.position.x < WO_W.transform.position.z) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the orange face along the green face\nB'");
                        //B'
                        pieces = rotateBigCube.B(-90, 0, 0);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the orange face along the green face\nL', D', L, B, B");
                        //L', D', L, B, B
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.D(0, 90, 0);
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
                        Debug.Log("The WO piece is correctly oriented on th esecond layer and adjacent to the red face along the blue face\nR, R, B, R, R");
                        //R, R, B, R, R
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.B(90, 0, 0);
                        pieces = rotateBigCube.R(0, 0, -90);
                        pieces = rotateBigCube.R(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the red face along the blue face\nF, D, F', R', B, R");
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
                    if (WO_O.transform.position.x < WO_W.transform.position.x) //if the position is correct
                    {
                        Debug.Log("The WO piece is correctly oriented on the second layer and adjacent to the red face along the green face\nL', L', B', L', L'");
                        //L', L', B', L', L'
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.B(-90, 0, 0);
                        pieces = rotateBigCube.L(0, 0, -90);
                        pieces = rotateBigCube.L(0, 0, -90);
                    }
                    else
                    {
                        Debug.Log("The WO piece is incorrectly oriented on the second layer and adjacent to the red face along the green face\nF', D', F, L, B', L'");
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
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the blue face\nD, B, B");
                    //D, B, B
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the green face\nD', B, B");
                    //D', B, B
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the red face\nD, D, B, B");
                    //D, D, B, B
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WO piece is correctly oriented on the bottom layer adjacent to the orange face\nB, B");
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
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the blue face\nR', B, R");
                    //R', B, R
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (objectIndex[0] == 0) //green
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the green face\nL, B', L'");
                    //L, B', L'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 2) //red
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the red face\nD', L, B', L'");
                    //D', L, B', L'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (objectIndex[0] == 1 && objectIndex[2] == 0) // orange
                {
                    Debug.Log("The WO piece is incorrectly oriented on the bottom layer adjacent to the orange face\nD, L, B', L'");
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
    public List<List<List<GameObject>>> whiteCorners(List<List<List<GameObject>>> pieces)
    {
        //first check if it is solved
        List<int> objectIndex = new List<int>();

        //WRB
        objectIndex = searching(WRB, pieces);
        //if it's in the top
        if (objectIndex[1] == 2)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2) //correct position
            {
                if (WRB_W.transform.position.y > WRB_R.transform.position.y) //correct orientation
                {
                    Debug.Log("The WRB corner is correct");
                }
                else if (WRB_R.transform.position.y > WRB_B.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRB corner is correctly positioned but incorrectly oriented (red facing up)\nR', D', R, D, D, F, D', F'");
                    //R', D', R, D, D, F, D', F'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else //the blue side is facing up
                {
                    Debug.Log("The WRB corner is correctly positioned but incorrectly oriented (blue facing up)\nR', D, R, D', R', D, R");
                    //R', D, R, D', R', D, R
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //the piece is in the top but in the blue orange corner
            {
                if (WRB_W.transform.position.y > WRB_R.transform.position.y) //white facing up //untested but probably right
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WBO (white facing up)\nB', D', B, D', R', D, R");
                    //B', D', B, D', R', D, R
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (WRB_R.transform.position.y > WRB_B.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WBO (red facing up)\nB', D', B, D, F, D', F'");
                    //B', D', B, D, F, D', F'
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else //the blue side is facing up //untested but probably right
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WBO (blue facing up)\nB', D, B, D', D', R', D, R");
                    //B', D, B, D', D', R', D, R
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //the piece is in the top but in the red green corner
            {
                if (WRB_W.transform.position.y > WRB_R.transform.position.y) //white facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WRG (white facing up)\nL, D, L', D, F, D', F'");
                    //L, D, L', D, F, D', F'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y > WRB_B.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WRG (red facing up)\nL, D', L', D, D, F, D', F'");
                    //L, D', L', D, D, F, D', F'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else //the blue side is facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WRG (blue facing up)\nL, D, L, D', R', D, R");
                    //L, D, L, D', R', D, R
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //the piece is in the top but in the green orange corner
            {
                if (WRB_W.transform.position.y > WRB_R.transform.position.y) //white facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WGO (white facing up)\nB, D, B', D, D, F, D', F'");
                    //B, D, B', D, D, F, D', F'
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y > WRB_B.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WGO (red facing up)\nB, D', B', D', F, D', F'");
                    //B, D', B', D', F, D', F'
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else //the blue side is facing up
                {
                    Debug.Log("The WRB corner is incorrectly positioned at WGO (blue facing up)\nB, D, B', R', D, R");
                    //B, D, B', R', D, R
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
            }
        }
        //bottom layer
        else if (objectIndex[1] == 0)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2) //bottom red blue
            {
                if (WRB_W.transform.position.y < WRB_R.transform.position.y) //white down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBR corner (white facing down)\nR', D', D', R, D, D, F, D', F'");
                    //R', D', D', R, D, D, F, D', F'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y < WRB_W.transform.position.y) //red down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBR corner (red facing down)\nD', R', D, R");
                    //D', R', D, R
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (WRB_B.transform.position.y < WRB_W.transform.position.y) //blue down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBR corner (blue facing down)\nD, F, D', F'");
                    //D, F, D', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //blue orange
            {
                if (WRB_W.transform.position.y < WRB_R.transform.position.y) //white down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBO corner (white facing down)\nD', R', D', D', R, D, D, F, D', F'");
                    //D', R', D', D', R, D, D, F, D', F'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y < WRB_W.transform.position.y) //red down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBO corner (red facing down)\nD', D', R', D, R");
                    //D', D', R', D, R
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (WRB_B.transform.position.y < WRB_W.transform.position.y) //blue down
                {
                    Debug.Log("The WRB corner is in the bottom layer YBO corner (blue facing down)\nF, D', F'");
                    //F, D', F'
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //red green
            {
                if (WRB_W.transform.position.y < WRB_R.transform.position.y) //white down
                {
                    Debug.Log("The WRB corner is in the bottom layer YRG corner (white facing down)\nD, R', D', D', R, D, D, F, D', F'");
                    //D, R', D', D', R, D, D, F, D', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y < WRB_W.transform.position.y) //red down
                {
                    Debug.Log("The WRB corner is in the bottom layer YRG corner (red facing down)\nR', D, R");
                    //R', D, R
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (WRB_B.transform.position.y < WRB_W.transform.position.y) //blue down
                {
                    Debug.Log("The WRB corner is in the bottom layer YRG corner (blue facing down)\nD, D, F, D', F'");
                    //D, D, F, D', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //green orange
            {
                if (WRB_W.transform.position.y < WRB_R.transform.position.y && WRB_W.transform.position.y < WRB_B.transform.position.y) //white down
                {
                    Debug.Log("The WRB corner is in the bottom layer YGO corner (white facing down)\nD, D, R', D', D', R, D, D, F, D', F'");
                    //D, D, R', D', D', R, D, D, F, D', F'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
                else if (WRB_R.transform.position.y < WRB_B.transform.position.y) //red down
                {
                    Debug.Log("The WRB corner is in the bottom layer YGO corner (red facing down)\nD, R', D, R");
                    //D, R', D, R
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                }
                else if (WRB_B.transform.position.y < WRB_W.transform.position.y) //blue down
                {
                    Debug.Log("The WRB corner is in the bottom layer YGO corner (blue facing down)\nD', F, D', F'");
                    //D', F, D', F'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                }
            }
        }
        //WOB
        objectIndex = searching(WOB, pieces);
        //if it's in the top
        if (objectIndex[1] == 2)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 0) //correct position
            {
                if (WOB_W.transform.position.y > WOB_B.transform.position.y) //correct orientation
                {
                    Debug.Log("The WOB corner is correct");
                }
                else if (WOB_B.transform.position.y > WOB_W.transform.position.y) //the blue side is facing up
                {
                    Debug.Log("The WOB corner is correctly positioned but incorrectly oriented (blue facing up)\nR, D', R', D, R, D', R'");
                    //R, D', R', D, R, D', R'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else //the orange side is facing up
                {
                    Debug.Log("The WOB corner is correctly positioned but incorrectly oriented (orange facing up)\nB', D, B, D', B', D, B");
                    //B', D, B, D', B', D, B
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //the piece is in the top but in the red green corner
            {
                if (WOB_W.transform.position.y > WOB_B.transform.position.y) //white facing up //untested but probably right
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRG (white facing up)\nL, D, L', D, D, R, D', R'");
                    //L, D, L', D, D, R, D', R'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (WOB_B.transform.position.y > WOB_O.transform.position.y) //the blue side is facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRG (blue facing up)\nL, D', L', D', R, D', R'");
                    //L, D', L', D', R, D', R', 
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else //the orange side is facing up //untested but probably right
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRG (orange facing up)\nL, D, L', B', D, B");
                    //L, D, L', B', D, B
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) //the piece is in the top but in the red blue corner
            {
                if (WOB_W.transform.position.y > WOB_B.transform.position.y) //white facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRB (white facing up)\nR', D', R, D, B', D, B");
                    //R', D', R, D, B', D, B
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_B.transform.position.y > WOB_O.transform.position.y) //the blue side is facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRB (blue facing up)\nR', D', R, D', R, D', R'");
                    //R', D', R, D', R, D', R'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else //the green side is facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WRB (orange facing up)\nR', D, R, B', D, B");
                    //R', D, R, B', D, B
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //the piece is in the top but in the green orange corner
            {
                if (WOB_W.transform.position.y > WOB_B.transform.position.y) //white facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WGO (white facing up)\nL, D, L', D, D, R, D', R'");
                    //L, D, L', D, D, R, D', R'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (WOB_B.transform.position.y > WOB_O.transform.position.y) //the blue side is facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WGO (blue facing up)\nL, D', L', D', R, D', R'");
                    //L', D', L, D, R, D', R'
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else //the orange side is facing up
                {
                    Debug.Log("The WOB corner is incorrectly positioned at WGO (orange facing up)\nL, D, L', B', D, B");
                    //L, D, L', B', D, B
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
            }
        }
        //bottom layer
        else if (objectIndex[1] == 0)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2) //bottom red blue
            {
                if (WOB_W.transform.position.y < WOB_B.transform.position.y) //white down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBR corner (white facing down)\nD, B', D', D', B, D, D, R, D', R'");
                    //D, B', D', D', B, D, D, R, D', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (WOB_B.transform.position.y < WOB_O.transform.position.y) //blue down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBR corner (blue facing down)\nB', D, B");
                    //B', D, B
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_O.transform.position.y < WOB_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBR corner (orange facing down)\nD, D, R, D', R'");
                    //D, D, R, D', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //blue orange
            {
                if (WOB_W.transform.position.y < WOB_B.transform.position.y) //white down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBO corner (white facing down)\nB', D', D', B, D, D, R, D', R'");
                    //B', D', D', B, D, D, R, D', R'
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (WOB_B.transform.position.y < WOB_O.transform.position.y) //blue down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBO corner (blue facing down)\nD', B', D, B");
                    //D', B', D, B
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_O.transform.position.y < WOB_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOB corner is in the bottom layer YBO corner (orange facing down)\nD, R, D', R'");
                    //D, R, D', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //red green
            {
                if (WOB_W.transform.position.y < WOB_B.transform.position.y) //white down
                {
                    Debug.Log("The WOB corner is in the bottom layer YRG corner (white facing down)\nD, D, B', D', D', B, D, D, R, D', R'");
                    //D, D, B', D', D', B, D, D, R, D', R'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else if (WOB_B.transform.position.y < WOB_O.transform.position.y) //blue down
                {
                    Debug.Log("The WOB corner is in the bottom layer YRG corner (blue facing down)\nD, B', D, B");
                    //D, B', D, B
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_O.transform.position.y < WOB_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOB corner is in the bottom layer YRG corner (orange facing down)\nD', R, D', R'");
                    //D', R, D', R'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //green orange
            {
                if (WOB_W.transform.position.y < WOB_B.transform.position.y) //white down
                {
                    Debug.Log("The WOB corner is in the bottom layer YGO corner (white facing down)\nD', R, D, D, R', D', D', B', D, B");
                    //D', R, D, D, R', D', D', B', D, B
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_B.transform.position.y < WOB_O.transform.position.y) //blue down
                {
                    Debug.Log("The WOB corner is in the bottom layer YGO corner (blue facing down)\nD', D', B', D, B");
                    //D', D', B', D, B
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                }
                else if (WOB_O.transform.position.y < WOB_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOB corner is in the bottom layer YGO corner (orange facing down)\nR, D', R'");
                    //R, D', R'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
            }
        }
        //WOG
        objectIndex = searching(WOG, pieces);
        //if it's in the top
        if (objectIndex[1] == 2)
        {
            if (objectIndex[0] == 0 && objectIndex[2] == 0) //correct position
            {
                if (WOG_W.transform.position.y > WOG_G.transform.position.y) //correct orientation
                {
                    Debug.Log("The WOG corner is correct");
                }
                else if (WOG_G.transform.position.y > WOG_O.transform.position.y) //the green side is facing up
                {
                    Debug.Log("The WOG corner is correctly positioned but incorrectly oriented (green facing up)\nL', D, L, D', L', D, L");
                    //L', D, L, D', L', D, L
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else //the orange side is facing up
                {
                    Debug.Log("The WOG corner is correctly positioned but incorrectly oriented (orange facing up)\nL', D', L, D, D, B, D', B'");
                    //L', D', L, D, D, B, D', B'
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //the piece is in the top but in the blue orange corner
            {
                if (WOG_W.transform.position.y > WOG_G.transform.position.y) //white facing up //untested but probably right
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WBO (white facing up)\nR, D, D, R', B, D', B'");
                    //R, D, D, R', B, D', B'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_G.transform.position.y > WOG_O.transform.position.y) //the green side is facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WBO (green facing up)\nR, L', D, L, R'");
                    //R, L', D, L, R'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.R(0, 0, 90);
                }
                else //the orange side is facing up //untested but probably right
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WBO (orange facing up)\nR, D', R', D, D, B, D', B'");
                    //R, D', R', D, D, B, D', B'
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) //the piece is in the top but in the red blue corner
            {
                if (WOG_W.transform.position.y > WOG_G.transform.position.y && WOB_W.transform.position.y > WOG_O.transform.position.y) //white facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRB (white facing up)\nR', D', D', R, D', L', D, L");
                    //R', D', D', R, D', L', D, L
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (WOG_G.transform.position.y > WOG_O.transform.position.y) //the green side is facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRB (green facing up)\nR', D, R, D, L', D, L");
                    //R', D, R, D, L', D, L
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else //the orange side is facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRB (orange facing up)\nR', D', R, B, D', B'");
                    //R', D', R, B, D', B'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //the piece is in the top but in the red green corner
            {
                if (WOG_W.transform.position.y > WRG_R.transform.position.y) //white facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRG (white facing up)\nL, D, L', D', B, D', B'");
                    //L, D, L', D', B, D', B'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_G.transform.position.y > WOG_O.transform.position.y) //the green side is facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRG (green facing up)\nL, D, L', D, L', D, L");
                    //L, D, L', D, L', D, L
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (WOG_O.transform.position.y > WOG_W.transform.position.y)//the orange side is facing up
                {
                    Debug.Log("The WOG corner is incorrectly positioned at WRG (orange facing up)\nL, D', L', B, D', B'");
                    //L, D', L', B, D', B'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
            }
        }
        //bottom layer
        else if (objectIndex[1] == 0)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2) //bottom red blue
            {
                if (WOG_W.transform.position.y < WOG_G.transform.position.y) //white down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBR corner (white facing down)\nD', D', B, D, D, B', D', D', L', D, L ");
                    //D', D', B, D, D, B', D', D', L', D, L 
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (WOG_G.transform.position.y < WOG_O.transform.position.y) //green down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBR corner (green facing down)\nD', B, D', B'");
                    //D, B, D', B'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_O.transform.position.y < WOG_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBR corner (orange facing down)\nD, L', D, L");
                    //D, L', D, L
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //blue orange
            {
                if (WOG_W.transform.position.y < WOG_G.transform.position.y) //white down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBO corner (white facing down)\nD, L', D', D', L, D, D, B, D', B'");
                    //D, L', D', D', L, D, D, B, D', B'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_G.transform.position.y < WOG_O.transform.position.y) //green down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBO corner (green facing down)\nD, D, B, D', B'");
                    //D, D, B, D', B'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_O.transform.position.y < WOG_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOG corner is in the bottom layer YBO corner (orange facing down)\nL', D, L");
                    //L', D, L
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //red green
            {
                if (WOG_W.transform.position.y < WOG_G.transform.position.y) //white down
                {
                    Debug.Log("The WOG corner is in the bottom layer YRG corner (white facing down)\nD', L', D, L, D', B, D', B'");
                    //D', L', D, L, D', B, D', B'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);

                }
                else if (WOG_G.transform.position.y < WOG_O.transform.position.y) //green down
                {
                    Debug.Log("The WOG corner is in the bottom layer YRG corner (green facing down)\nB, D', B'");
                    //B, D', B'
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_O.transform.position.y < WOG_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOG corner is in the bottom layer YRG corner (orange facing down)\nD', D', L', D, L");
                    //D', D', L', D, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //green orange
            {
                if (WOG_W.transform.position.y < WOG_G.transform.position.y) //white down
                {
                    Debug.Log("The WOG corner is in the bottom layer YGO corner (white facing down)\nB, D, D, B', D', D', L', D, L");
                    //B, D, D, B', D', D', L', D, L
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
                else if (WOG_G.transform.position.y < WOG_O.transform.position.y) //green down
                {
                    Debug.Log("The WOG corner is in the bottom layer YGO corner (green facing down)\nD, B, D', B'");
                    //D, B, D', B'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else if (WOG_O.transform.position.y < WOG_W.transform.position.y) //orange down
                {
                    Debug.Log("The WOG corner is in the bottom layer YGO corner (orange facing down)\nD', L', D, L");
                    //D', L', D, L
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                }
            }
        }
        //WRG
        objectIndex = searching(WRG, pieces);
        //if it's in the top
        if (objectIndex[1] == 2)
        {
            if (objectIndex[0] == 0 && objectIndex[2] == 2) //correct position
            {
                if (WRG_W.transform.position.y > WRG_R.transform.position.y) //correct orientation
                {
                    Debug.Log("The WRG corner is correct");
                }
                else if (WRG_R.transform.position.y > WRG_G.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRG corner is correctly positioned but incorrectly oriented (red facing up)\nF', D, F, D', F', D, F");
                    //F', D, F, D', F', D, F
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else //the green side is facing up
                {
                    Debug.Log("The WRG corner is correctly positioned but incorrectly oriented (green facing up)\nL, D', L', D, L, D', L'");
                    //L, D', L', D, L, D', L'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //the piece is in the top but in the blue orange corner
            {
                if (WRG_W.transform.position.y > WRG_R.transform.position.y) //white facing up //untested but probably right
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WBO (white facing up)\nB', D', D', B, D', F', D, F");
                    //B', D', D', B, D', F', D, F
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y > WRG_G.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WBO (red facing up)\nB', D, B, D, F', D, F");
                    //B', D, B, D, F', D, F
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else //the green side is facing up //untested but probably right
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WBO (green facing up)\nB', D', B, L, D', L'");
                    //B', D', B, L, D', L'
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) //the piece is in the top but in the red blue corner
            {
                if (WRG_W.transform.position.y > WRG_R.transform.position.y) //white facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WRB (white facing up)\nR', D', D', R, F', D, F");
                    //R', D', D', R, F', D, F
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y > WRG_G.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WRB (red facing up)\nR', D, R, D', D', F', D, F");
                    //R', D, R, D', D', F', D, F
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else //the green side is facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WRB (green facing up)\nR', D', R, D, L, D', L'");
                    //R', D', R, D, L, D', L'
                    pieces = rotateBigCube.R(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.R(0, 0, -90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //the piece is in the top but in the green orange corner
            {
                if (WRG_W.transform.position.y > WRG_R.transform.position.y) //white facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WOG (white facing up)\nB, D', B', F', D, F");
                    //B, D', B', F', D, F
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y > WRG_G.transform.position.y) //the red side is facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WOG (red facing up)\nB, F', D, F, B'");
                    //B, F', D, F, B'
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                }
                else //the green side is facing up
                {
                    Debug.Log("The WRG corner is incorrectly positioned at WOG (green facing up)\nB, D', B', D, D, L, D', L'");
                    //B, D', B', D, D, L, D', L'
                    pieces = rotateBigCube.B(90, 0, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.B(-90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
            }
        }
        //bottom layer
        else if (objectIndex[1] == 0)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2) //bottom red blue
            {
                if (WRG_W.transform.position.y < WRG_R.transform.position.y) //white down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBR corner (white facing down)\nD', L, D, D, L', D', D', F', D, F");
                    //D', L, D, D, L', D', D', F', D, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y < WRG_G.transform.position.y) //red down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBR corner (red facing down)\nL, D', L'");
                    //L, D', L'
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (WRG_G.transform.position.y < WRG_W.transform.position.y) //green down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBR corner (green facing down)\nD', D', F', D, F");
                    //D', D', F', D, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //blue orange
            {
                if (WRG_W.transform.position.y < WRG_R.transform.position.y) //white down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBO corner (white facing down)\nD, L, D, D, L', D', D', F', D, F");
                    //D, L, D, D, L', D', D', F', D, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y < WRG_G.transform.position.y) //red down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBO corner (red facing down)\nD', L, D', L'");
                    //D', L, D', L'
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (WRG_G.transform.position.y < WRG_W.transform.position.y) //green down
                {
                    Debug.Log("The WRG corner is in the bottom layer YBO corner (green facing down)\nD, F', D, F");
                    //D, F', D, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //red green
            {
                if (WRG_W.transform.position.y < WRG_R.transform.position.y) //white down
                {
                    Debug.Log("The WRG corner is in the bottom layer YRG corner (white facing down)\nL, D, D, L', D', D', F', D, F");
                    //L, D, D, L', D', D', F', D, F
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y < WRG_G.transform.position.y) //red down
                {
                    Debug.Log("The WRG corner is in the bottom layer YRG corner (green facing down)\nD, L, D', L'");
                    //D, L, D', L'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (WRG_G.transform.position.y < WRG_W.transform.position.y) //green down
                {
                    Debug.Log("The WRG corner is in the bottom layer YRG corner (green facing down)\nD', F', D, F");
                    //D', F', D, F
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //green orange
            {
                if (WRG_W.transform.position.y < WRG_R.transform.position.y) //white down
                {
                    Debug.Log("The WRG corner is in the bottom layer YGO corner (white facing down)\nD, L, D, D, L', D', D', F', D, F");
                    //D, L, D, D, L', D', D', F', D, F
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
                else if (WRG_R.transform.position.y < WRG_G.transform.position.y) //red down
                {
                    Debug.Log("The WRG corner is in the bottom layer YGO corner (red facing down)\nD, D, L, D', L'");
                    //D, D, L, D', L'
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, 90);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);
                }
                else if (WRG_G.transform.position.y < WRG_W.transform.position.y) //green down
                {
                    Debug.Log("The WRG corner is in the bottom layer YGO corner (green facing down)\nF', D, F");
                    //F', D, F
                    pieces = rotateBigCube.F(90, 0, 0);
                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);
                }
            }
        }
        return pieces;
    }
    public List<List<List<GameObject>>> secondLayer(List<List<List<GameObject>>> pieces)
    {
        //temporary solution for rotation
        //B', B', S, S, F, F
        pieces = rotateBigCube.B(-90, 0, 0);
        pieces = rotateBigCube.B(-90, 0, 0);
        pieces = rotateBigCube.S(-90, 0, 0);
        pieces = rotateBigCube.S(-90, 0, 0);
        pieces = rotateBigCube.F(-90, 0, 0);
        pieces = rotateBigCube.F(-90, 0, 0);

        return pieces;
    }
}