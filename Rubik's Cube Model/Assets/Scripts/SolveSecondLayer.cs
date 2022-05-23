using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveSecondLayer : MonoBehaviour
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
    //
    public GameObject RB_W;
    public GameObject RB_Y;
    public GameObject OB_W;
    public GameObject OB_Y;
    public GameObject OG_W;
    public GameObject OG_Y;
    public GameObject RG_W;
    public GameObject RG_Y;
    //
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
    public List<List<List<GameObject>>> secondLayer(List<List<List<GameObject>>> pieces)
    {
        /*//FLIP CUBE UPSIDE DOWN
        rotateBigCube.fullRotation(90, 0, 0);
        rotateBigCube.fullRotation(90, 0, 0);*/

        List<int> objectIndex = new List<int>();
        //RB piece 
        objectIndex = searching(RB, pieces);//ALL RB TRACKING APPEARS TO BE CORRECT. SOME OF THE MOVEMENTS, HOWEVER, ARE CAUSING CORNERS SOME ISSUES
        //on center layer
        //
        // RB
        //
        //
        if (objectIndex[1] == 1)
        {
            //CORRECT POSITION
            if (objectIndex[0] == 2 && objectIndex[2] == 2)
            {
                //red is in the front
                if (RB_W.transform.position.y > RB_Y.transform.position.y) //verified with tracking and movement
                {
                    Debug.Log("The RB piece is correct");
                }
                else
                {
                    Debug.Log("the RB piece is oriented incorrectly\n(red) LALG RALG, D, D, (red) LALG RALG");                    //(red) LALG RALG, D, D, (red) LALG RALG    >>>                    //(red)LALG: RALG: R', D', R, D, F, D, F', D'                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            //IN THE OB spot
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //tracking is correct and moevement
            {
                if (RB_W.transform.position.y > RB_Y.transform.position.y) 
                {
                    Debug.Log("The RB piece is positioned in the OB spot with red adj to blue and blue adj orange\n(blue) LALG RALG, (blue) RALG LALG"); //                    //(blue) LALG RALG, (blue) RALG LALG    >>>                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                }                else
                {
                    Debug.Log("The RB piece is positioned in the OB spot with blue adj to blue and red adj orange\n(blue) LALG RALG, D, (red) LALG RALG"); //
                    //(blue) LALG RALG, D, (red) LALG RALG  >>>                    //(blue) LALG RALG: B', D', B, D, R, D, R', D' 
                    pieces = rotateBigCube.B(-90, 0, 0);  
                    pieces = rotateBigCube.D(0, 90, 0);  
                    pieces = rotateBigCube.B(90, 0, 0);  
                    pieces = rotateBigCube.D(0, -90, 0);  
                    pieces = rotateBigCube.R(0, 0, -90); 
                    pieces = rotateBigCube.D(0, -90, 0);  
                    pieces = rotateBigCube.R(0, 0, 90); 
                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }
                
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //OG //tracking checked and movement
            {
                if (RB_W.transform.position.y > RB_Y.transform.position.y) //checked
                {
                    Debug.Log("The RB piece is positioned in the OG spot with blue adj green and red adj orange\n(green) RALG LALG, D, (red) LALG RALG");                    //(green) RALG LALG, D, (red) LALG RALG >>>                    //(green) RALG LALG: B, D, B', D', L', D', L, D                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }                else
                {
                    Debug.Log("The RB piece is positioned in the OG spot with red adj green and blue adj orange\n(green) RALG LALG, (blue) RALG LALG");                    //(green) RALG LALG, (blue) RALG LALG   >>>                    //(green) RALG LALG: B, D, B', D', L', D', L, D                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) // RG //tracking confirmed and movement
            {
                //RB_B.transform.position.x < RB_R.transform.position.x
                if (RB_Y.transform.position.y > RB_W.transform.position.y)
                {
                    Debug.Log("The RB piece is positioned in the RG spot with red adj red and blue adj green\n(red) RALG LALG, D', (blue) RALG LALG");                    //(red) RALG LALG, D', (blue) RALG LALG >>>                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                }
                else
                {
                    Debug.Log("The RB piece is positioned in the RG spot with blue adj red and red adj green\n(red) RALG LALG, (red) LALG RALG");                    //(red) RALG LALG, (red) LALG RALG  >>>                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }
            }
        }
        else if (objectIndex[1] == 0) //its in the top
        {
            if (objectIndex[0] == 2) //YB
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y) //tracking confirmed and movement
                {
                    Debug.Log("The RB piece is in the top YB spot (blue up)\nD, D, (red) LALG RALG");                    //D, D, (red) LALG RALG   >>>                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }
                else
                {
                    Debug.Log("The RB piece is in the top YB spot (red up)\nD, (blue) RALG LALG"); //correct                    //D, (blue) RALG LALG   >>>                    pieces = rotateBigCube.D(0, -90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);
                }
            }
            else if (objectIndex[2] == 0) //YO
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y) //tracking confirmed and movement
                {
                    Debug.Log("The RB piece is in the top YO spot (blue up)\nD, (red) LALG RALG");                    //D, (red) LALG RALG    >>>                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }
                else
                {
                    Debug.Log("The RB piece is in the top YO spot (red up)\n(blue) RALG LALG"); //checked                    //(blue) RALG LALG  >>>                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);
                }
            }
            else if (objectIndex[0] == 0) //YG
            {
                if (RB_B.transform.position.y > RB_R.transform.position.y) //tracking confirmed and movement
                {
                    Debug.Log("The RB piece is in the top YG spot (red up)\nD', (blue) RALG LALG");                    //D', (blue) RALG LALG  >>                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                                        
                }
                else
                {
                    Debug.Log("The RB piece is in the top YG spot (blue up)\nLALG, Y, RALG\n(red) LALG RALG");                     //(red) LALG RALG   >>>                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            else if (objectIndex[2] == 2) //YR
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y) //tracking checked and movement
                {
                    Debug.Log("The RB piece is in the top YR spot (blue up)\nD', (red) LALG RALG");                    //D', (red) LALG RALG   >>>                    pieces = rotateBigCube.D(0, 90, 0);                    //(red) LALG: RALG: R', D', R, D, F, D, F', D'                     pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);
                }
                else
                {
                    Debug.Log("The RB piece is in the top YR spot (red up)\nD, D, (blue) RALG LALG");                    //D, D, (blue) RALG LALG    >>>                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(blue) RALG LALG: F, D, F', D', R', D', R, D                      pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                }
            }
        }
        //
        //
        //
        //
        //
        //
        // OB
        //
        //
        //
        //
        //
        //OB //tracking and movement confirmed
        objectIndex = searching(OB, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 0)//OB //
            {
                if (OB_W.transform.position.y > OB_Y.transform.position.y) //tracking is confirmed and movement
                {
                    Debug.Log("The OB piece is correct");
                }
                else
                {
                    Debug.Log("The OB piece is in oriented incorrectly\n(blue) LALG RALG, D', D', (blue) LALG RALG"); //correct                    //(blue) LALG RALG, D', D', (blue) LALG RALG                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //OG 
            {
                if (OB_W.transform.position.y < OB_Y.transform.position.y) //tracking and movement confirmed
                {
                    Debug.Log("The OB piece is located in OG with orange adj orange and blue adj green\n(green) RALG LALG, D, (orange) RALG LALG");                    //(green) RALG LALG, D, (orange) RALG LALG                    //(green) RALG LALG: B, D, B', D', L', D', L, D                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                }                else
                {
                    Debug.Log("The OB piece is located in OG with blue adj orange and orange adj green\n(green) RALG LALG, D', D', (blue) LALG RALG");                    //(green) RALG LALG, D', D', (blue) LALG RALG                    //(green) RALG LALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, 90, 0);
                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) // RG
            {
                if (OB_W.transform.position.y < OB_Y.transform.position.y) //tracking and movement confirmed
                {
                    Debug.Log("The OB piece is located in RG with blue adj red and orange adj green\n(red) RALG LALG, (orange) RALG LALG");                    //(red) RALG LALG, (orange) RALG LALG                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                }
                else
                {
                    Debug.Log("The OB piece is located in RG with orange adj red and blue adj green\n(red) RALG LALG, D, (blue) LALG RALG");                    //(red) RALG LALG, D, (blue) LALG RALG                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                    pieces = rotateBigCube.D(0, -90, 0);//                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
        }
        else if (objectIndex[1] == 0) //its in the top
        {
            if (objectIndex[0] == 2) //YB //tracking and movement confirmed
            {
                //OB_O.transform.position.y < OB_B.transform.position.y
                
                if (OB.transform.rotation.x == 0)
                {
                    Debug.Log("The OB piece is in the top YB spot with orange facing up\nD', (blue) LALG RALG"); //(0.0, 0.0, -0.7, 0.7)                    //D', (blue) LALG RALG                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
                else
                {
                    Debug.Log("The OB piece is in the top YB spot with blue facing up\nD, D, (orange) RALG LALG"); //(-0.5, 0.5. 0.5. 0.5)                    //D, D, (orange) RALG LALG                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                }
            }
            else if (objectIndex[2] == 0) //YO //Tracking and movement confirmed
            {
                if (OB.transform.rotation.x > 0)
                {
                    Debug.Log("The OB piece is in the top YO spot with orange facing up\nD', D', (blue) LALG RALG"); //(-0.7, 0.0, 0.0, 0.7)                    //D', D', (blue) LALG RALG                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
                else
                {
                    Debug.Log("The OB piece is in the top YO spot with blue facing up\nD, (orange) RALG LALG"); //(0.5, -0.5, -0.5, 0.5)                    //D, (orange) RALG LALG                    pieces = rotateBigCube.D(0, -90, 0);                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                }
            }
            else if (objectIndex[0] == 0) //YG //tracking and movement confirmed
            {
                if (OB.transform.rotation.y > 0)
                {
                    Debug.Log("The OB piece is in the top YG spot with orange facing up\nD, (blue) LALG RALG"); //(-0.7, 0.7, 0.0, 0.0)                    //D, (blue) LALG RALG                    pieces = rotateBigCube.D(0, -90, 0);                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
                else
                {
                    Debug.Log("The OB piece is in the top YG spot with blue facing up\n(orange) RALG LALG"); //(-0.5, -0.5, -0.5, 0.5)                    //(orange) RALG LALG                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                }
            }
            else if (objectIndex[2] == 2) //YR //tracking and movement confirmed
            {
                if (OB.transform.rotation.x != 0)
                {
                    Debug.Log("The OB piece is in the top YR spot with orange facing up\nLALG, Y', RALG\n(blue) LALG RALG"); //(-0.5, 0.5, -0.5, 0.5)                    //(blue) LALG RALG                    //(blue) LALG RALG: B', D', B, D, R, D, R', D'                     pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
                else
                {
                    Debug.Log("The OB piece is in the top YR spot with blue facing up\nD', (orange) RALG LALG"); //(0.0, 0.7, 0.7, 0.0)                    //D', (orange) RALG LALG                    pieces = rotateBigCube.D(0, 90, 0);                    //(orange) RALG LALG: R, D, R', D', B', D', B, D                     pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                }
            }
        }
        //
        //
        //
        //
        //
        // OG
        //
        //CHANGE TRACKING, CHECK, FIX SOLVING CODE
        //
        //
        //
        //PIECE: OG set up for orange
        objectIndex = searching(OG, pieces);
        Debug.Log("OG: " + OG.transform.rotation);
        //on center layer
        if (objectIndex[1] == 1)
        {            if (objectIndex[0] == 0 && objectIndex[2] == 0) //OG
            {
                if (OG_W.transform.position.y > OG_Y.transform.position.y) //tracking is confirmed and movement
                {
                    Debug.Log("The OG piece is correct");
                }
                else
                {
                    Debug.Log("The OG piece is oriented incorrectly\n(orange) LALG RALG, D', D', (orange) LALG RALG");                    //(orange) LALG RALG, D', D', (orange) LALG RALG                    //(orange) LALG RALG: L', D', L, D, B, D, B', D'                     pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    //                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    //(orange) LALG RALG: L', D', L, D, B, D, B', D'                     pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) // RG
            {
                if (OG_W.transform.position.y > OG_Y.transform.position.y) //tracking and movement confirmed
                {
                    Debug.Log("The OG piece is positioned at RG with orange adj green and green adj red\n(green) LALG RALG, (green) RALG LALG");                    //(green) LALG RALG, (green) RALG LALG                    //(green) LALG RALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    //(green) RALG LALG: B, D, B', D', L', D', L, D                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                }
                else
                {
                    Debug.Log("The OG piece is positioned at RG with green adj green and orange adj red\n(red) RALG LALG, D, (green) RALG LALG");                    //(red) RALG LALG, D, (green) RALG LALG                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //                    pieces = rotateBigCube.D(0, -90, 0);                    //(green) RALG LALG: B, D, B', D', L', D', L, D                     pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                }
            }
        }
        else if (objectIndex[1] == 0) //its in the top
        {
            if (objectIndex[0] == 2) //YB
            {
                if (OG_O.transform.position.y < OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YB with orange facing up");
                    //D', (green) RALG

                    /*//Y', U', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YB with green facing up");
                    //(orange) LALG

                    /*//LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
            else if (objectIndex[2] == 0) //YO
            {
                if (OG_O.transform.position.y < OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YO with orange facing up");
                    //D, D, (green) RALG

                    /*//Y', U, U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YO with green facing up");
                    //D', (orange) LALG

                    /*//U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
            else if (objectIndex[0] == 0) //YG
            {
                if (OG_O.transform.position.y < OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YG with orange facing up");
                    //D, (green) RALG

                    /*//Y', U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YG with green facing up");
                    //D, D, (orange) LALG

                    /*//U', U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
            else if (objectIndex[2] == 2) //YR
            {
                if (OG_O.transform.position.y < OG_G.transform.position.y) 
                {
                    Debug.Log("The OG piece is positioned in the top at YR with orange facing up");
                    //(green) RALG

                    /*//Y', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/

                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YR with green facing up");
                    //D, (orange) LALG

                    /*//U, LALG, Y', RALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
        }
        //
        //
        //
        //
        //
        // RG tracking and movement confirmed
        //
        //
        //
        //
        //
        //
        objectIndex = searching(RG, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            if (objectIndex[0] == 0 && objectIndex[2] == 2) // RG
            {
                if (RG_W.transform.position.y > RG_Y.transform.position.y) //tracking is confirmed and movement
                {
                    Debug.Log("The RG piece is correct"); //checked
                }
                else
                {
                    Debug.Log("The RG piece is oriented incorrectly\n(red) RALG LALG, D', D', (red) RALG LALG"); //checked                    //(red) RALG LALG, D', D', (red) RALG LALG                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                }
            }
        }
        else if (objectIndex[1] == 0) //its in the top
        {
            if (objectIndex[0] == 2) //YB //tracking and movement confirmed
            {
                if (RG.transform.rotation.z != 0)
                {
                    Debug.Log("The RG piece is in the top YB place with green facing up\n(red) RALG"); //(0.5, -0.5, 0.5, 0.5)                    //(red) RALG                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                }
                else
                {
                    Debug.Log("The RG piece is in the top YB place with red facing up\nD, (green) LALG"); //(-0.7, -0.7, 0.0, 0.0)                    //D, (green) LALG                    pieces = rotateBigCube.D(0, -90, 0);                    //(green) LALG RALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                }
            }
            else if (objectIndex[2] == 0) //YO
            {
                if (RG.transform.rotation.x == 0)
                {
                    Debug.Log("The RG piece is in the top YO place with green facing up\nD', (red) RALG"); //(0.0, 0.7, -0.7, 0.0)                    //D', (red) RALG                    pieces = rotateBigCube.D(0, 90, 0);                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                }
                else
                {
                    Debug.Log("The RG piece is in the top YO place with red facing up\n(green) LALG"); //(0.5, 0.5, 0.5, 0.5)                    //(green) LALG                    //(green) LALG RALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            else if (objectIndex[0] == 0) //YG
            {
                if (RG.transform.rotation.x != 0) //tracking and movement confirmed
                {
                    Debug.Log("The RG piece is in the top YG place with green facing up\nD', D', (red) RALG"); //(0.5, 0.5, -0.5, 0.5)                    //D', D', (red) RALG                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);
                }
                else
                {
                    Debug.Log("The RG piece is in the top YG place with red facing up\nD', (green) LALG"); //(0.0, 0.0, 0.7, 0.7)
                    //D', (green) LALG
                    pieces = rotateBigCube.D(0, 90, 0);                    //(green) LALG RALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
            else if (objectIndex[2] == 2) //YR //tracking and movement confirmed
            {
                if (RG.transform.rotation.x > 0)
                {
                    Debug.Log("The RG piece is in the top YR place with green facing up\nD, (red) RALG LALG"); //(0.7, 0.0, 0.0, 0.7)
                    //D, (red) RALG LALG
                    pieces = rotateBigCube.D(0, -90, 0);                    //(red) RALG LALG: L, D, L', D', F', D', F, D                     pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                                                                                                                                                                         }
                else
                {
                    Debug.Log("The RG piece is in the top YR place with red facing up\nD, D, (green) LALG"); //(-0.5, -0.5, 0.5, 0.5)                    //D, D, (green) LALG                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    //(green) LALG RALG: F', D', F, D, L, D, L', D'                     pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.D(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.D(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.D(0, 90, 0);
                }
            }
        }
        //
        //
        //
        //
        //
        //
        //
        return pieces;
    }
}