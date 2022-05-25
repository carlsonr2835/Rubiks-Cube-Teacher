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
    public bool yellowCross(List<List<List<GameObject>>> pieces)
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
        else if (crossPosition[0][1] && crossPosition[1][2] && !crossPosition[2][1] && !crossPosition[1][0]) //angle .-
        {
            Debug.Log("The third layer cross is oriented in the angle formation (correct .-)\nf, (red) RALG, f'"); //tracking and movement confirmed            //f, (red) RALG, f'            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //f'            pieces = rotateBigCube.f(false);
        }
        else if (crossPosition[1][2] && crossPosition[2][1] && !crossPosition[1][0] && !crossPosition[0][1]) //angle -.
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect -.)\nD', f, (red) RALG, f'"); //tracking and movement confirmed            //D', f, (red) RALG, f'            //D'            pieces = rotateBigCube.D(0, 90, 0);            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //f'            pieces = rotateBigCube.f(false);
        }
        else if (crossPosition[1][0] && crossPosition[2][1] && !crossPosition[0][1] && !crossPosition[1][2]) //angle -^
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect -^)\nD, D, f, (red) RALG, f'"); //tracking and movement confirmed            //D, D, f, (red) RALG, f'            //D, D            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.D(0, -90, 0);            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //f'            pieces = rotateBigCube.f(false);        }
        else if (crossPosition[1][0] && crossPosition[0][1] && !crossPosition[2][1] && !crossPosition[1][2]) //angle ^-
        {
            Debug.Log("The third layer cross is oriented in the angle formation (Incorrect ^-)\nD, f, (red) RALG, f'"); //tracking and movement confirmed            //D, f, (red) RALG, f'            //D            pieces = rotateBigCube.D(0, -90, 0);            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //f'            pieces = rotateBigCube.f(false);
        }
        else if (!crossPosition[0][1] && !crossPosition[2][1] && !crossPosition[1][0] && !crossPosition[1][2]) //dot
        {
            Debug.Log("The third layer cross is oriented in the dot formation\nF, (red) RALG, F', f, (red) RALG, f'"); //tracking and movement confirmed            //F, (red) RALG, F', f, (red) RALG, f'            //F, (red) RALG, F'            //F            pieces = rotateBigCube.F(-90, 0, 0);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.F(90, 0, 0);            //f, (red) RALG, f'            //f            pieces = rotateBigCube.f(true);            //(red) RALG: L, D, L', D'            pieces = rotateBigCube.L(0, 0, 90);            pieces = rotateBigCube.D(0, -90, 0);            pieces = rotateBigCube.L(0, 0, -90);            pieces = rotateBigCube.D(0, 90, 0);            //F'            pieces = rotateBigCube.f(false);
        }
        else //error
        {
            Debug.Log("Error in code: no possible cross cases");
            return false;
        }
        return true;
    }
    public List<List<List<GameObject>>> positionCorners(List<List<List<GameObject>>> pieces)    {        List<int> objectIndex = new List<int>();        List<List<int>> objectIndexes = new List<List<int>>();        objectIndexes.Add(searching(YRB, pieces));        objectIndexes.Add(searching(YOB, pieces));        objectIndexes.Add(searching(YOG, pieces));        objectIndexes.Add(searching(YRG, pieces));        //all correct positioning        if (/*YRB*/objectIndexes[0][0] == 2 && objectIndexes[0][2] == 2 && /*YOB*/objectIndexes[1][0] == 2 && objectIndexes[1][2] == 0            && /*YOG*/objectIndexes[2][0] == 0 && objectIndexes[2][2] == 0 && /*YRG*/objectIndexes[3][0] == 0 && objectIndexes[3][2] == 2) //all correct spots        {            Debug.Log("Yellow corners are possitioned all correct and in the correct spots"); //tracking and movement confirmed        }        else if (/*YRB*/objectIndexes[0][0] == 2 && objectIndexes[0][2] == 0 && /*YOB*/objectIndexes[1][0] == 0 && objectIndexes[1][2] == 0            && /*YOG*/objectIndexes[2][0] == 0 && objectIndexes[2][2] == 2 && /*YRG*/objectIndexes[3][0] == 2 && objectIndexes[3][2] == 2) //rotated D over        {            Debug.Log("Yellow corners are positioned all correct but not in the correct spots\nD'");            //D'        }        else if (/*YRB*/objectIndexes[0][0] == 0 && objectIndexes[0][2] == 0 && /*YOB*/objectIndexes[1][0] == 0 && objectIndexes[1][2] == 2 //rotated 2D over            && /*YOG*/objectIndexes[2][0] == 2 && objectIndexes[2][2] == 2 && /*YRG*/objectIndexes[3][0] == 2 && objectIndexes[3][2] == 0)        {            Debug.Log("Yellow corners are positioned all correct but not in the correct spots\nD, D");            //D, D        }        else if (/*YRB*/objectIndexes[0][0] == 0 && objectIndexes[0][2] == 2 && /*YOB*/objectIndexes[1][0] == 2 && objectIndexes[1][2] == 2 //rotated D' over            && /*YOG*/objectIndexes[2][0] == 2 && objectIndexes[2][2] == 0 && /*YRG*/objectIndexes[3][0] == 0 && objectIndexes[3][2] == 0)        {            Debug.Log("Yellow corners are positioned all correct but not in the correct spots\n\nD");            //D        }        //side positioning        //REDS        else if (/*YRG*/objectIndexes[3][0] == 0 && objectIndexes[3][2] == 2 && /*YRB*/ objectIndexes[0][0] == 2 && objectIndexes[0][2] == 2) //line in red face        {            Debug.Log("Yellow corners YRB and YRG are correctly positioned (line) but in the red face of the cube\nD, (red) RALG x3, (green) LALG x3, D'");            //D, (red) RALG x3, (green) LALG x3, D'        }        else if (/*YRG*/objectIndexes[3][0] == 2 && objectIndexes[3][2] == 2 && /*YRB*/ objectIndexes[0][0] == 2 && objectIndexes[0][2] == 0) //line in blue face        {            Debug.Log("Yellow corners YRB and YRG are correctly positioned (line) but in the blue face of the cube\n(red) RALG x3, (green) LALG x3, D'");            //(red) RALG x3, (green) LALG x3, D'        }        else if (/*YRG*/objectIndexes[3][0] == 2 && objectIndexes[3][2] == 0 && /*YRB*/ objectIndexes[0][0] == 0 && objectIndexes[0][2] == 0) //line in orange face        {            Debug.Log("Yellow corners YRB and YRG are correctly positioned (line) but in the orange face of the cube\nD', (red) RALG x3, (green) LALG x3, D'");            //D', (red) RALG x3, (green) LALG x3, D'        }        else if (/*YRG*/objectIndexes[3][0] == 0 && objectIndexes[3][2] == 0 && /*YRB*/ objectIndexes[0][0] == 0 && objectIndexes[0][2] == 2) //line in green face        {            Debug.Log("Yellow corners YRB and YRG are correctly positioned (line) but in the green face of the cube\nD, D, (red) RALG x3, (green) LALG x3, D'");            //D, D, (red) RALG x3, (green) LALG x3, D'        }        //BLUES        else if (/*YRB*/objectIndexes[0][0] == 0 && objectIndexes[0][2] == 2 && /*YOB*/ objectIndexes[1][0] == 2 && objectIndexes[1][2] == 2) //line in red face        {            Debug.Log("Yellow corners YRB and YOB are correctly positioned (line) but in the red face of the cube\nD, (red) RALG x3, (green) LALG x3, D'");            //D, (red) RALG x3, (green) LALG x3, D'        }        else if (/*YRB*/objectIndexes[0][0] == 2 && objectIndexes[0][2] == 2 && /*YOB*/ objectIndexes[1][0] == 2 && objectIndexes[1][2] == 0) //line in blue face        {            Debug.Log("Yellow corners YRB and YOB are correctly positioned (line) but in the blue face of the cube\n(red) RALG x3, (green) LALG x3, D'");            //(red) RALG x3, (green) LALG x3, D'        }        else if (/*YRB*/objectIndexes[0][0] == 2 && objectIndexes[0][2] == 0 && /*YOB*/ objectIndexes[1][0] == 0 && objectIndexes[1][2] == 0) //line in orange face        {            Debug.Log("Yellow corners YRB and YOB are correctly positioned (line) but in the orange face of the cube\nD', (red) RALG x3, (green) LALG x3, D'");            //D', (red) RALG x3, (green) LALG x3, D'        }        else if (/*YRB*/objectIndexes[0][0] == 0 && objectIndexes[0][2] == 0 && /*YOB*/ objectIndexes[1][0] == 0 && objectIndexes[1][2] == 2) //line in green face        {            Debug.Log("Yellow corners YRB and YOB are correctly positioned (line) but in the green face of the cube\nD, D, (red) RALG x3, (green) LALG x3, D'");            //D, D, (red) RALG x3, (green) LALG x3, D'        }        //ORANGES        else if (/*YOB*/objectIndexes[1][0] == 0 && objectIndexes[1][2] == 2 && /*YOG*/ objectIndexes[2][0] == 2 && objectIndexes[2][2] == 2) //line in red face        {            Debug.Log("Yellow corners YOB and YOG are correctly positioned (line) but in the red face of the cube\nD, (red) RALG x3, (green) LALG x3, D'");            //D, (red) RALG x3, (green) LALG x3, D'        }        else if (/*YOB*/objectIndexes[1][0] == 2 && objectIndexes[1][2] == 2 && /*YOG*/ objectIndexes[2][0] == 2 && objectIndexes[2][2] == 0) //line in blue face        {            Debug.Log("Yellow corners YOB and YOG are correctly positioned (line) but in the blue face of the cube\n(red) RALG x3, (green) LALG x3, D'");            //(red) RALG x3, (green) LALG x3, D'        }        else if (/*YOB*/objectIndexes[1][0] == 2 && objectIndexes[1][2] == 0 && /*YOG*/ objectIndexes[2][0] == 0 && objectIndexes[2][2] == 0) //line in orange face        {            Debug.Log("Yellow corners YOB and YOG are correctly positioned (line) but in the orange face of the cube\nD', (red) RALG x3, (green) LALG x3, D'");            //D', (red) RALG x3, (green) LALG x3, D'        }        else if (/*YOB*/objectIndexes[1][0] == 0 && objectIndexes[1][2] == 0 && /*YOG*/ objectIndexes[2][0] == 0 && objectIndexes[2][2] == 2) //line in green face        {            Debug.Log("Yellow corners YOB and YOG are correctly positioned (line) but in the green face of the cube\nD, D, (red) RALG x3, (green) LALG x3, D'");            //D, D, (red) RALG x3, (green) LALG x3, D'        }        //GREENS        else if (/*YOG*/objectIndexes[2][0] == 0 && objectIndexes[2][2] == 2 && /*YRG*/ objectIndexes[3][0] == 2 && objectIndexes[3][2] == 2) //line in red face        {            Debug.Log("Yellow corners YOG and YRG are correctly positioned (line) but in the red face of the cube\nD, (red) RALG x3, (green) LALG x3, D'");            //D, (red) RALG x3, (green) LALG x3, D'        }        else if (/*YOG*/objectIndexes[2][0] == 2 && objectIndexes[2][2] == 2 && /*YRG*/ objectIndexes[3][0] == 2 && objectIndexes[3][2] == 0) //line in blue face        {            Debug.Log("Yellow corners YOG and YRG are correctly positioned (line) but in the blue face of the cube\n(red) RALG x3, (green) LALG x3, D'");            //(red) RALG x3, (green) LALG x3, D'        }        else if (/*YOG*/objectIndexes[2][0] == 2 && objectIndexes[2][2] == 0 && /*YRG*/ objectIndexes[3][0] == 0 && objectIndexes[3][2] == 0) //line in orange face        {            Debug.Log("Yellow corners YOG and YRG are correctly positioned (line) but in the orange face of the cube\nD', (red) RALG x3, (green) LALG x3, D'");            //D', (red) RALG x3, (green) LALG x3, D'        }        else if (/*YOG*/objectIndexes[2][0] == 0 && objectIndexes[2][2] == 0 && /*YRG*/ objectIndexes[3][0] == 0 && objectIndexes[3][2] == 2) //line in green face        {            Debug.Log("Yellow corners YOG and YRG are correctly positioned (line) but in the green face of the cube\nD, D, (red) RALG x3, (green) LALG x3, D'");            //D, D, (red) RALG x3, (green) LALG x3, D'        }        //diagonals        //YRB and YOG        else if (/*YRB*/objectIndexes[0][0] == && objectIndexes[0][2] == && /*YOG*/objectIndexes[2][0] == && objectIndexes[2][2] == )        {            Debug.Log("The YRB and YOG corners are diagonals and positioned with YRB positioned at the YRB corner");            //        }        else if (/*YRB*/objectIndexes[0][0] == && objectIndexes[0][2] == && /*YOG*/objectIndexes[2][0] == && objectIndexes[2][2] == )        {            Debug.Log("The YRB and YOG corners are diagonals and positioned with YRB positioned at the YOB corner");            //        }        else if (/*YRB*/objectIndexes[0][0] == && objectIndexes[0][2] == && /*YOG*/objectIndexes[2][0] == && objectIndexes[2][2] == )        {            Debug.Log("The YRB and YOG corners are diagonals and positioned with YRB positioned at the YOG corner");            //        }        else if (/*YRB*/objectIndexes[0][0] == && objectIndexes[0][2] == && /*YOG*/objectIndexes[2][0] == && objectIndexes[2][2] == )        {            Debug.Log("The YRB and YOG corners are diagonals and positioned with YRB positioned at the YRG corner");            //        }        //YRG and YOB        else if (/*YRG*/objectIndexes[3][0] == && objectIndexes[3][2] == && /*YOB*/objectIndexes[1][0] == && objectIndexes[1][2] == )        {            Debug.Log("The YRG and YOB corners are diagonals and positioned with YRG positioned at YRB corner");            //        }        else if (/*YRG*/objectIndexes[3][0] == && objectIndexes[3][2] == && /*YOB*/objectIndexes[1][0] == && objectIndexes[1][2] == )        {            Debug.Log("The YRG and YOB corners are diagonals and positioned with YRG positioned at YOB corner");            //        }        else if (/*YRG*/objectIndexes[3][0] == && objectIndexes[3][2] == && /*YOB*/objectIndexes[1][0] == && objectIndexes[1][2] == )        {            Debug.Log("The YRG and YOB corners are diagonals and positioned with YRG positioned at YOG corner");            //        }        else if (/*YRG*/objectIndexes[3][0] == && objectIndexes[3][2] == && /*YOB*/objectIndexes[1][0] == && objectIndexes[1][2] == )        {            Debug.Log("The YRG and YOB corners are diagonals and positioned with YRG positioned at YRG corner");            //        }        /*List<List<string>> cornerPosition = new List<List<string>>();        for (int i = 0; i < 2; i++)        {        List<string> temp = new List<string>();        for (int j = 0; j < 2; j++)        {            temp.Add("");        }        cornerPosition.Add(temp);        }        //YRB        objectIndex = searching(YRB, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YRB";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YRB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YRB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YRB";        }        objectIndex = searching(YOB, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YOB";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YOB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YOB";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YOB";        }        objectIndex = searching(YOG, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YOG";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YOG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YOG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YOG";        }        objectIndex = searching(YRG, pieces);        if (objectIndex[0] == 0 && objectIndex[2] == 0)        {            cornerPosition[0][0] = "YRG";        }        else if (objectIndex[0] == 0 && objectIndex[2] == 2)        {            cornerPosition[0][1] = "YRG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 0)        {            cornerPosition[1][0] = "YRG";        }        else if (objectIndex[0] == 2 && objectIndex[2] == 2)        {            cornerPosition[1][1] = "YRG";        }        //two on left side        if (cornerPosition[0][0] == "YRB" && cornerPosition[0][1] == "YOB")        {            Debug.Log("The YRB and YOB corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YOB" && cornerPosition[0][1] == "YOG") {            Debug.Log("The YOB and YOG corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YOG" && cornerPosition[0][1] == "YRG")        {            Debug.Log("The YOG and YRG corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[0][0] == "YRG" && cornerPosition[0][1] == "YRB")        {            Debug.Log("The YRG and YRB corners are on the left side\nRALG, RALG, RALG, Y, LALG, LALG, LALG");        }        //Two on right side        if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        else if (cornerPosition[1][0] == "" && cornerPosition[1][1] == "")        {            Debug.Log("The _ and _ corners are on the right side\nY', Y', RALG, RALG, RALG, Y, LALG, LALG, LALG");        }        //angle        //-+        //+-        //angle        //+-        //-+*/                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    return pieces;    }
}