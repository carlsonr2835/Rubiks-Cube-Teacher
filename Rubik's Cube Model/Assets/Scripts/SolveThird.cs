using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveThird : MonoBehaviour
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
    public GameObject Y;
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
    public GameObject O;
    public GameObject OG;
    public GameObject OG_O;
    public GameObject OG_G;
    public GameObject OB;
    public GameObject OB_O;
    public GameObject OB_B;
    public GameObject B;
    public GameObject G;
    public GameObject Middle;
    public GameObject RB;
    public GameObject RB_R;
    public GameObject RB_B;
    public GameObject RG;
    public GameObject RG_R;
    public GameObject RG_G;
    public GameObject R;
    public GameObject W;
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
        pieces[1][1][0] = O;
        pieces[2][1][0] = OB;
        pieces[0][2][0] = WOG;
        pieces[1][2][0] = WO;
        pieces[2][2][0] = WOB;
        pieces[0][0][1] = YG;
        pieces[1][0][1] = Y;
        pieces[2][0][1] = YB;
        pieces[0][1][1] = G;
        pieces[1][1][1] = Middle;
        pieces[2][1][1] = B;
        pieces[0][2][1] = WG;
        pieces[1][2][1] = W;
        pieces[2][2][1] = WB;
        pieces[0][0][2] = YRG;
        pieces[1][0][2] = YR;
        pieces[2][0][2] = YRB;
        pieces[0][1][2] = RG;
        pieces[1][1][2] = R;
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

    List<int> searching(GameObject piece, List<List<List<GameObject>>> pieces)
    {
        List<int> objectIndex = new List<int>();
        for (int x = 0; x <= 2; x++)
        {
            for (int y = 0; y <= 2; y++)
            {
                for (int z = 0; z <= 2; z++)
                {
                    if (pieces[x][y][z] == piece)
                    {
                        //Debug.Log("Object: " + piece + "found at: " + x + ", " + y + ", " + z);
                        objectIndex.Add(x);
                        objectIndex.Add(y);
                        objectIndex.Add(z);
                    }
                }
            }
        }
        return objectIndex;
    }
    public List<List<List<GameObject>>> yellowCross(List<List<List<GameObject>>> pieces)
    {
        //search for each and position and orientation to make a note
        List<int> objectIndex = new List<int>();

        //<VISUAL WAY OF CHECKING>
        List<List<bool>> crossPosition = new List<List<bool>>();
        for (int i = 0; i < 3; i++)
        {
            List<bool> temp = new List<bool>();
            for (int j = 0; j < 3; j++)
            {
                temp.Add(false);
            }
            crossPosition.Add(temp);
        }
        //YR piece
        objectIndex = searching(YR, pieces);
        if (YR_Y.transform.position.y < YR_R.transform.position.y)
        {
            if (objectIndex[0] == 0)
            {
                Debug.Log("The YR piece is located at x = 0, z = 1");
                crossPosition[0][1] = true;
            }
            else if (objectIndex[0] == 2)
            {
                Debug.Log("The YR piece is located at x = 2, z = 1");
                crossPosition[2][1] = true;
            }
            else if (objectIndex[2] == 0)
            {
                Debug.Log("The YR piece is located at x = 1, z = 0");
                crossPosition[1][0] = true;
            }
            else if (objectIndex[2] == 2)
            {
                Debug.Log("The YR piece is located at x = 1, z = 2");
                crossPosition[1][2] = true;
            }
        }
        objectIndex = searching(YO, pieces);
        if (YO_Y.transform.position.y < YO_O.transform.position.y)
        {
            if (objectIndex[0] == 0)
            {
                Debug.Log("The YO piece is located at x = 0, z = 1");
                crossPosition[0][1] = true;
            }
            else if (objectIndex[0] == 2)
            {
                Debug.Log("The YO piece is located at x = 2, z = 1");
                crossPosition[2][1] = true;
            }
            else if (objectIndex[2] == 0)
            {
                Debug.Log("The YO piece is located at x = 1, z = 0");
                crossPosition[1][0] = true;
            }
            else if (objectIndex[2] == 2)
            {
                Debug.Log("The YO piece is located at x = 1, z = 2");
                crossPosition[1][2] = true;
            }
        }
        objectIndex = searching(YB, pieces);
        if (YB_Y.transform.position.y < YB_B.transform.position.y)
        {
            if (objectIndex[0] == 0)
            {
                Debug.Log("The YB piece is located at x = 0, z = 1");
                crossPosition[0][1] = true;
            }
            else if (objectIndex[0] == 2)
            {
                Debug.Log("The YB piece is located at x = 2, z = 1");
                crossPosition[2][1] = true;
            }
            else if (objectIndex[2] == 0)
            {
                Debug.Log("The YB piece is located at x = 1, z = 0");
                crossPosition[1][0] = true;
            }
            else if (objectIndex[2] == 2)
            {
                Debug.Log("The YB piece is located at x = 1, z = 2");
                crossPosition[1][2] = true;
            }
        }
        objectIndex = searching(YG, pieces);
        if (YG_Y.transform.position.y < YG_G.transform.position.y)
        {
            if (objectIndex[0] == 0)
            {
                Debug.Log("The YG piece is located at x = 0, z = 1");
                crossPosition[0][1] = true;
            }
            else if (objectIndex[0] == 2)
            {
                Debug.Log("The YG piece is located at x = 2, z = 1");
                crossPosition[2][1] = true;
            }
            else if (objectIndex[2] == 0)
            {
                Debug.Log("The YG piece is located at x = 1, z = 0");
                crossPosition[1][0] = true;
            }
            else if (objectIndex[2] == 2)
            {
                Debug.Log("The YG piece is located at x = 1, z = 2");
                crossPosition[1][2] = true;
            }
        }
        if (crossPosition[0][1] && crossPosition[2][1] && crossPosition[1][0] && crossPosition[1][2]) //solved
        {
            Debug.Log("The third layer cross is already solved"); //tracking confirmed, movement not needed
        }
        else if (crossPosition[0][1] && crossPosition[2][1] && !crossPosition[1][0] && !crossPosition[1][2]) //horz line
        {
            Debug.Log("The third layer cross is oriented in the line formation (horizontal)\nF, (red) RALG, F'"); //tracking and movement confirmed            //F, (red) RALG, F'            //F            pieces = rotateBigCube.F(-90, 0, 0);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.F(90, 0, 0);        }
        else if (crossPosition[1][0] && crossPosition[1][2] && !crossPosition[0][1] && !crossPosition[2][1]) //vert line
        {
            Debug.Log("The third layer cross is oriented in the line formation (vertical)\nD, F, (red) RALG, F'"); //movement and tracking confirmed            //D, F, (red) RALG, F'            //D            pieces = rotateBigCube.D(0, -90, 0);            //F            pieces = rotateBigCube.F(-90, 0, 0);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.F(90, 0, 0);
        }
        else if (crossPosition[1][0] && crossPosition[2][1] && !crossPosition[0][1] && !crossPosition[1][2]) 
        {
            Debug.Log("The third layer cross is oriented in the angle formation (correct .-)"); //working so far
            //f, (red) RALG, f'
        }
        else if (crossPosition[1][0] && crossPosition[0][1] && !crossPosition[2][1] && !crossPosition[1][2]) //angle -.
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect -.)");
            //D', f, (red) RALG, f'
        }
        else if (crossPosition[0][1] && crossPosition[1][2] && !crossPosition[2][1] && !crossPosition[1][0]) //angle -^
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect -^)"); 
            //D, D, f, (red) RALG, f'
        }
        else if (crossPosition[1][2] && crossPosition[2][1] && !crossPosition[1][0] && !crossPosition[0][1]) //angle ^-
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect ^-)"); 
            //D, f, (red) RALG, f'
        }
        else if (!crossPosition[0][1] && !crossPosition[2][1] && !crossPosition[1][0] && !crossPosition[1][2]) //dot
        {
            Debug.Log("The third layer cross is oriented in the dot formation\nF, (red) RALG, F', f, (red) RALG, f'"); //tracking and movement confirmed            //F, (red) RALG, F', f, (red) RALG, f'            //F, (red) RALG, F'            //F            pieces = rotateBigCube.F(-90, 0, 0);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.F(90, 0, 0);            //f, (red) RALG, f'            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.f(false);
        }
        else //error
        {
            Debug.Log("Error in code: no possible cross cases");
        }
        return pieces;
    }
    public List<List<List<GameObject>>> positionCorners(List<List<List<GameObject>>> pieces)    {        List<int> objectIndex = new List<int>();
        objectIndex = searching(B, pieces); //this block is causing issues        /*if (objectIndex[2] == 2)
        {
            Debug.Log("Positioning for YRB: blue is in front");
        }
        else if (objectIndex[2] == 0)
        {
            Debug.Log("Positioning for YRB: blue is in back\nY, Y");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        else if (objectIndex[0] == 0)
        {
            Debug.Log("Positioning for YRB: blue is in left\nY'");
            pieces = rotateBigCube.fullRotation(0, -90, 0);
        }
        else if (objectIndex[0] == 2)
        {
            Debug.Log("Positioning for YRB: blue is in right\nY");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }*/        List<List<string>> cornerPosition = new List<List<string>>();
        for (int i = 0; i < 2; i++)
        {
            List<string> temp = new List<string>();
            for (int j = 0; j < 2; j++)
            {
                temp.Add("");
            }
            cornerPosition.Add(temp);        }        //YRB        objectIndex = searching(YRB, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YRB";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YRB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YRB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YRB";        }        objectIndex = searching(YOB, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YOB";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YOB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YOB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YOB";        }        objectIndex = searching(YOG, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YOG";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YOG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YOG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YOG";        }        objectIndex = searching(YRG, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YRG";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YRG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YRG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YRG";        }        //two on left side        if (cornerPosition[0][0] == "YRB" && cornerPosition[0][1] == "YOB")        {            Debug.Log("The YRB and YOB corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YOB" && cornerPosition[0][1] == "YOG") {            Debug.Log("The YOB and YOG corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YOG" && cornerPosition[0][1] == "YRG")        {            Debug.Log("The YOG and YRG corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YRG" && cornerPosition[0][1] == "YRB")        {            Debug.Log("The YRG and YRB corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        //Two on right side        if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        //angle        //-+        //+-        //angle        //+-        //-+        return pieces;    }
}