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
        //FLIP CUBE UPSIDE DOWN
        rotateBigCube.fullRotation(90, 0, 0);
        rotateBigCube.fullRotation(90, 0, 0);

        List<int> objectIndex = new List<int>();
        //RB piece
        objectIndex = searching(RB, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            //CORRECT POSITION
            if (objectIndex[0] == 0 && objectIndex[2] == 2)
            {
                //red is in the front
                if (RB_B.transform.position.z > RB_R.transform.position.z)
                {
                    //the piece is correct
                    Debug.Log("The RB piece is correct"); //checked
                }
                else if (RB_B.transform.position.z < RB_R.transform.position.z)
                {
                    Debug.Log("the RB piece is oriented incorrectly\nLALG RALG (red), U, LALG RALG (red)\nL’, U’, L, U, F, U, F’, U’, U, U, L’, U’, L, U, F, U, F’, U’");
                    //the piece is oriented incorrectly
                    //LALG RALG (red), U, U, LALG RALG (red)
                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);//                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);//                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    /*//L', U', L, U(LALG), Y', R, U, R' U', (RALG), Y (back), U', U', L', U', L, U (LALG), Y', R, U, R', U'(RALG)                        //LALG, Y', RALG, Y, U', U', LALG, Y', RALG                        pieces = rotateBigCube.LALG();                        pieces = rotateBigCube.fullRotation(0, -90, 0);                        pieces = rotateBigCube.RALG();                        pieces = rotateBigCube.fullRotation(0, 90, 0);                        pieces = rotateBigCube.U(0, -90, 0);                        pieces = rotateBigCube.U(0, -90, 0);                        pieces = rotateBigCube.LALG();                        pieces = rotateBigCube.fullRotation(0, -90, 0);                        pieces = rotateBigCube.RALG();*/                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }
            }
            //IN THE OB spot
            else if (objectIndex[0] == 0 && objectIndex[2] == 0)
            {
                if (RB_B.transform.position.x > RB_R.transform.position.x)
                {
                    Debug.Log("The RB piece is positioned in the OB spot with red adj to blue and blue adj orange\nY', LALG, Y', RALG, Y, Y, LALG, Y', RALG\nB’, U’, B, U, L, U, L’, U’, F, U, F’, U’, L’, U’, L, U"); //
                    //B’, U’, B, U, L, U, L’, U’, F, U, F’, U’, L’, U’, L, U
                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0);//                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//Y', LALG, Y', RALG, Y, Y, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }                else if (RB_B.transform.position.x < RB_R.transform.position.x) //
                {
                    Debug.Log("The RB piece is positioned in the OB spot with blue adj to blue and red adj orange\nY', LALG, Y', RALG, Y, Y, U, LALG, Y', RALG\nB’, U’, B, U, L, U, L’, U’, U, L’, U’, L, U, F, U, F’, U’"); //
                    //B’, U’, B, U, L, U, L’, U’, U, L’, U’, L, U, F, U, F’, U’                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);//
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);//                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);

                    /*//Y', LALG, Y', RALG, Y, Y, U, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
                
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //OG
            {
                if (RB_B.transform.position.x > RB_R.transform.position.x)
                {
                    Debug.Log("The RB piece is positioned in the OG spot with blue adj green and red adj orange\nY, RALG, Y, LALG, Y, Y, (red in front), U', U', LALG, Y', RALG\nB, U, B’, U’, R’, U’, R, U, U, L’, U’, L, U, F, U, F’, U’");
                    //B, U, B’, U’, R’, U’, R, U, U, L’, U’, L, U, F, U, F’, U’
                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.U(0, 90, 0);//green ralg lalg
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90);//red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
                    /*//Y, RALG, Y, LALG, Y, Y, (red in front), U', U', LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
                else
                {
                    Debug.Log("The RB piece is positioned in the OG spot with red adj green and blue adj orange\nY, RALG, Y (i think), LALG, Y (again to get to blue), U, RALG, Y, LALG\nB, U, B’, U’, R’, U’, R, U, F, U, F’, U’, L’, U’, L, U");
                    //B, U, B’, U’, R’, U’, R, U, F, U, F’, U’, L’, U’, L, U
                    pieces = rotateBigCube.B(90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.B(-90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.R(0, 0, -90);                    pieces = rotateBigCube.U(0, 90, 0);//green ralg lalg
                    pieces = rotateBigCube.F(-90, 0, 0);//blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//Y, RALG, Y (i think), LALG, Y (again to get to blue), U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) // RG
            {
                if (RB_B.transform.position.x > RB_R.transform.position.x)
                {
                    Debug.Log("The RB piece is positioned in the RG spot with red adj red and blue adj green\nRALG, Y, LALG, Y', Y', (blue front), RALG, Y, LALG\nR, U, R’, U’, F’, U’, F, U (red ralg lalg), <U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)");
                    //R, U, R’, U’, F’, U’, F, U (red ralg lalg), <U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)
                    pieces = rotateBigCube.R(0, 0, -90); //red ralg lalg                     pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);//
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0); //blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//RALG, Y, LALG, Y', Y', (blue front), RALG, Y, LALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
                else
                {
                    Debug.Log("The RB piece is positioned in the RG spot with blue adj red and red adj green\nRALG, Y, LALG, Y', LALG, Y', RALG\nR, U, R’, U’, F’, U’, F, U (red ralg lalg), L’, U’, L, U, F, U, F’, U’ (red lalg ralg)");
                    //R, U, R’, U’, F’, U’, F, U (red ralg lalg), L’, U’, L, U, F, U, F’, U’ (red lalg ralg)
                    pieces = rotateBigCube.R(0, 0, -90); //red ralg lalg                     pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.R(0, 0, 90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90); //red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
                    /*//RALG, Y, LALG, Y', LALG, Y', RALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
        }
        else if (objectIndex[1] == 2) //its in the top
        {
            if (objectIndex[0] == 0) //YB
            {
                if (RB_B.transform.position.y > RB_R.transform.position.y)//tracking problem!!!
                {
                    Debug.Log("The RB piece is in the top YB spot with red adj blue\nU', U', LALG, Y', RALG\n<U', U'>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)");
                    //<U', U'>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.L(0, 0, -90); //red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
                    /*//U', U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
                else
                {
                    Debug.Log("The RB piece is in the top YB spot with blue adj blue\nY', U, RALG, Y, LALG\n<U>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)"); //correct
                    //<U>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0); //blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//Y', U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
            }
            else if (objectIndex[2] == 0) //YO
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y)
                {
                    Debug.Log("The RB piece is in the top YO spot with R adj orange\nU, LALG, Y', RALG\n<U>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)");                    //<U>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.L(0, 0, -90); //red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
                    /*//U, LALG, Y', RALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
                else
                {
                    Debug.Log("The RB piece is in the top YO spot with B adj orange\nY, (blue), RALG, Y', LALG\nF, U, F’, U’, L’, U’, L, U (blue ralg lalg)");
                    //F, U, F’, U’, L’, U’, L, U (blue ralg lalg)
                    pieces = rotateBigCube.F(-90, 0, 0); //blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//Y, (blue), RALG, Y', LALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
            }
            else if (objectIndex[0] == 2) //YG
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y)
                {
                    Debug.Log("The RB piece is in the top YG spot with R adj green\nLALG, Y, RALG\nL’, U’, L, U, F, U, F’, U’ (red lalg ralg)");                    //L’, U’, L, U, F, U, F’, U’ (red lalg ralg)                    pieces = rotateBigCube.L(0, 0, -90); //red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
                    /*//LALG, Y, RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
                else
                {
                    Debug.Log("The RB piece is in the top YG spot with B adj green\nY', U', RALG, Y, LALG\n<U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)");
                    //<U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0); //blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//Y', U', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();*/
                }
            }
            else if (objectIndex[2] == 2) //YR
            {
                if (RB_B.transform.position.y < RB_R.transform.position.y)
                {
                    Debug.Log("The RB piece is in the top YR spot with R adj red\nY', U, U, RALG, Y, LALG\n<U>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)");
                    //<U>, L’, U’, L, U, F, U, F’, U’ (red lalg ralg)
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.L(0, 0, -90); //red lalg ralg                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(-90, 0, 0);                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);
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
                    Debug.Log("The RB piece is in the top YR spot with B adj red\nU', LALG, Y', RALG\n<U', U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)");
                    //<U', U'>, F, U, F’, U’, L’, U’, L, U (blue ralg lalg)
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.F(-90, 0, 0); //blue ralg lalg                    pieces = rotateBigCube.U(0, 90, 0);                    pieces = rotateBigCube.F(90, 0, 0);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, -90);                    pieces = rotateBigCube.U(0, -90, 0);                    pieces = rotateBigCube.L(0, 0, 90);                    pieces = rotateBigCube.U(0, 90, 0);
                    /*//U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();*/
                }
            }
        }
        /*objectIndex = searching(B, pieces); //this block is causing issues
        if (objectIndex[2] == 2)
        {
            Debug.Log("Positioning for OB: blue is in front");
        }
        else if (objectIndex[2] == 0)
        {
            Debug.Log("Positioning for OB: blue is in back\nY, Y");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        else if (objectIndex[0] == 0)
        {
            Debug.Log("Positioning for OB: blue is in left\nY'");
            pieces = rotateBigCube.fullRotation(0, -90, 0);
        }
        else if (objectIndex[0] == 2)
        {
            Debug.Log("Positioning for OB: blue is in right\nY");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        //PIECE: OB ((((make sure cube s faceing blue side
        objectIndex = searching(OB, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 2)//RB
            {
                if (OB_O.transform.position.x > OB_B.transform.position.x)
                {
                    Debug.Log("The OB piece is located at RB with blue adj blue and orange adj red\nRALG, Y, LALG, Y', Y', RALG, Y, LALG");
                    //RALG, Y, LALG, Y', Y', RALG, Y, LALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OB piece is located at RB with orange adj blue and blue adj red\nRALG, Y, LALG, Y', U, LALG, Y', RALG");
                    //RALG, Y, LALG, Y', U, LALG, Y', RALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2)//OB //verified
            {
                if (OB_O.transform.position.z > OB_B.transform.position.z)
                {
                    Debug.Log("The OB piece is correct");
                }
                else if (OB_O.transform.position.z < OB_B.transform.position.z)
                {
                    Debug.Log("The OB piece is in the correct spot but incorrectly positioned\nLALG, Y', RALG, Y, U, U, LALG, Y', RALG"); //correct
                    //LALG, Y', RALG, Y, U, U, LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //OG
            {
                if (OB_O.transform.position.z > OB_B.transform.position.z)
                {
                    Debug.Log("The OB piece is located in OG with orange adj orange and blue adj green\nY', LALG, Y', RALG, Y, Y, LALG, Y', RALG");
                    //Y', LALG, Y', RALG, Y, Y, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The OB piece is located in OG with blue adj orange and orange adj green\nY', LALG, Y', RALG, Y, U', RALG, Y, LALG");
                    //Y', LALG, Y', RALG, Y, U', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) // RG
            {
                if (OB_B.transform.position.z > OB_O.transform.position.z)
                {
                    Debug.Log("The OB piece is located in RG with blue adj red and orange adj green\nY, RALG, Y, LALG, Y, U, RALG, Y, LALG");
                    //Y, RALG, Y, LALG, Y, U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OB piece is located in RG with orange adj red and blue adj green\nY, RALG, Y, LALG, Y, Y, U', U', LALG, Y', RALG");
                    //Y, RALG, Y, LALG, Y, Y, U', U', LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
        }
        else if (objectIndex[1] == 2) //its in the top
        {
            if (objectIndex[0] == 1 && objectIndex[2] == 2) //YB
            {
                if (OB_O.transform.position.y < OB_B.transform.position.y)
                {
                    Debug.Log("The OB piece is in the top YB spot with orange facing up\nU', LALG, Y', RALG");
                    //U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The OB piece is in the top YB spot with blue facing up\nY', U, U, RALG, Y, LALG");
                    //Y', U, U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 1) //YO
            {
                if (OB_O.transform.position.y < OB_B.transform.position.y)
                {
                    Debug.Log("The OB piece is in the top YO spot with orange facing up\nY, U', U', LALG, Y', RALG");
                    //U', U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The OB piece is in the top YO spot with blue facing up\nY', U, RALG, Y, LALG");
                    //Y', U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
            else if (objectIndex[0] == 1 && objectIndex[2] == 0) //YG
            {
                if (OB_O.transform.position.y > OB_B.transform.position.y)
                {
                    Debug.Log("The OB piece is in the top YG spot with orange facing up\nU, LALG, Y', RALG");
                    //U, LALG, Y', RALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The OB piece is in the top YG spot with blue facing up\nY', RALG, Y, LALG");
                    //Y', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 1) //YR
            {
                if (OB_O.transform.position.y > OB_B.transform.position.y)
                {
                    Debug.Log("The OB piece is in the top YR spot with orange facing up\nLALG, Y', RALG");
                    //LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The OB piece is in the top YR spot with blue facing up");
                    //Y', U', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
        }
        objectIndex = searching(O, pieces);
        if (objectIndex[2] == 2) //orange front
        {
            Debug.Log("Positioning for OG: orange is in front");
        }
        else if (objectIndex[2] == 0) //back
        {
            Debug.Log("Positioning for OG: orange is in back\nY, Y");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        else if (objectIndex[0] == 0)
        {
            Debug.Log("Positioning for OG: orange is in left\nY'");
            pieces = rotateBigCube.fullRotation(0, -90, 0);
        }
        else if (objectIndex[0] == 2)
        {
            Debug.Log("Positioning for OG: orange is in right\nY");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        //PIECE: OG
        objectIndex = searching(OG, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            if (objectIndex[0] == 2 && objectIndex[2] == 0) //RB
            {
                if (OG_O.transform.position.z > OG_G.transform.position.z)
                {
                    Debug.Log("The OG piece is positioned at RB with orange adj blue and green adj red");
                    //Y, RALG, Y, LALG, Y, U, RALG, Y, LALG

                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OG piece is positioned at RB with green adj blue and orange adj red");
                    //Y, RALG, Y, LALG, Y, Y, U', U', LALG, Y', RALG

                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 2) //OG
            {
                if (OG_O.transform.position.z > OG_G.transform.position.z)
                {
                    Debug.Log("The OG piece is correct");
                }
                else if (OG_O.transform.position.z < OG_G.transform.position.z)
                {
                    Debug.Log("The OG piece is correctly placed but incorrectly positioned\nLALG, Y', RALG, Y, U, U, LALG, Y', RALG");
                    //LALG, Y', RALG, Y, U, U, LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) //OB
            {
                if (OG_O.transform.position.z > OG_G.transform.position.z)
                {
                    Debug.Log("The OG piece is positioned at OB with orange adj orange and green adj blue\nRALG, Y, LALG, Y', Y', RALG, Y, LALG");
                    //RALG, Y, LALG, Y', Y', RALG, Y, LALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OG piece is positioned at OB with green adj orange and orange adj blue\nRALG, Y, LALG, Y', U, LALG, Y', RALG");
                    //RALG, Y, LALG, Y', U, LALG, Y', RALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) // RG
            {
                if (OG_O.transform.position.z > OG_G.transform.position.z)
                {
                    Debug.Log("The OG piece is positioned at RG with orange adj green and green adj red\nY', LALG, Y', RALG, Y, RALG, Y, LALG"); //checked
                    //Y', LALG, Y', RALG, Y, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OG piece is positioned at RG with green adj green and orange adj red\nY', LALG, Y', RALG, Y, Y, U, LALG, Y', RALG"); 
                    //Y', LALG, Y', RALG, Y, Y, U, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
        }
        else if (objectIndex[1] == 2) //its in the top
        {
            if (objectIndex[0] == 2) //YB
            {
                if (OG_O.transform.position.y > OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YB with orange facing up");
                    //Y', U', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();

                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YB with green facing up");
                    //LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();

                }
            }
            else if (objectIndex[2] == 2) //YO
            {
                if (OG_O.transform.position.y > OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YO with orange facing up");
                    //Y', U, U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();

                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YO with green facing up");
                    //U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 0) //YG
            {
                if (OG_O.transform.position.y > OG_G.transform.position.y)
                {
                    Debug.Log("The OG piece is positioned in the top at YG with orange facing up");
                    //Y', U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YG with green facing up");
                    //U', U', LALG, Y', RALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();

                }
            }
            else if (objectIndex[2] == 0) //YR
            {
                if (OG_O.transform.position.y < OG_G.transform.position.y) //verified
                {
                    Debug.Log("The OG piece is positioned in the top at YR with orange facing up");
                    //Y', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();

                }
                else
                {
                    Debug.Log("The OG piece is positioned in the top at YR with green facing up");
                    //U, LALG, Y', RALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();

                }
            }
        }
        objectIndex = searching(R, pieces);
        if (objectIndex[2] == 2) //red front
        {
            Debug.Log("Positioning for RG: red is in front");
        }
        else if (objectIndex[2] == 0) //back
        {
            Debug.Log("Positioning for RG: red is in back\nY, Y");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        else if (objectIndex[0] == 0)
        {
            Debug.Log("Positioning for RG: red is in left\nY'");
            pieces = rotateBigCube.fullRotation(0, -90, 0);
        }
        else if (objectIndex[0] == 2)
        {
            Debug.Log("Positioning for RG: red is in right\nY");
            pieces = rotateBigCube.fullRotation(0, 90, 0);
        }
        //PIECE: RG
        objectIndex = searching(RG, pieces);
        //on center layer
        if (objectIndex[1] == 1)
        {
            if (objectIndex[0] == 0 && objectIndex[2] == 2) //RB
            {
                if (RG_R.transform.position.z > RG_G.transform.position.z)
                {
                    Debug.Log("The RG piece is positioned at RB with red adj red and green adj blue\nLALG, Y', RALG, Y, U', LALG, Y', RALG");
                    //LALG, Y', RALG, Y, U', LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The RG piece is positioned at RB with green adj red and red adj blue\nLALG, Y', RALG, Y, U', RALG, Y, LALG");
                    //LALG, Y', RALG, Y, U', RALG, Y, LALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();

                }
            }
            else if (objectIndex[0] == 0 && objectIndex[2] == 0) //OB
            {
                if (RG_R.transform.position.z > RG_G.transform.position.z)
                {
                    Debug.Log("The RG piece is positioned at OB with green adj orange and red adj blue\nY', LALG, Y', RALG, Y', U', LALG, Y', RALG");
                    //Y', LALG, Y', RALG, Y', U', LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The RG piece is positioned at OB with green adj blue and red adj orange\nY', LALG, Y', RALG, Y, Y, U, U, RALG, Y, LALG");
                    //Y', LALG, Y', RALG, Y, Y, U, U, RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();

                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 0) //OG
            {
                if (RG_R.transform.position.z > RG_G.transform.position.z)
                {
                    Debug.Log("The RG piece is positioned at OG with green adj orange and red adj green\nY, RALG, Y, LALG, Y', U, LALG, Y', RALG");
                    //Y, RALG, Y, LALG, Y', U, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The RG piece is positioned at OG with green adj green and red adj orange\nY, RALG, Y, LALG, Y', Y', RALG, Y, LALG");
                    //Y, RALG, Y, LALG, Y', Y', RALG, Y, LALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
            else if (objectIndex[0] == 2 && objectIndex[2] == 2) // RG
            {
                if (RG_R.transform.position.z < RG_G.transform.position.z) //checked
                {
                    Debug.Log("The RG piece is correct"); //checked
                }
                else
                {
                    Debug.Log("The RG piece is in the correct spot but positioned incorrectly\nRALG, Y, LALG, Y', U', U', RALG, Y, LALG"); //checked
                    //RALG, Y, LALG, Y', U', U', RALG, Y, LALG
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
            }
        }
        else if (objectIndex[1] == 2) //its in the top
        {
            if (objectIndex[0] == 0) //YB
            {
                if (RG_G.transform.position.y > RG_R.transform.position.y)
                {
                    Debug.Log("The RG piece is in the top YB place with green facing up\nLALG, Y', RALG");
                    //LALG, Y', RALG
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
                else
                {
                    Debug.Log("The RG piece is in the top YB place with red facing up\nY, U, LALG, Y', RALG");
                    //Y, U, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[2] == 0) //YO
            {
                if (RG_G.transform.position.y > RG_R.transform.position.y)
                {
                    Debug.Log("The RG piece is in the top YO place with green facing up\nU', RALG, Y, LALG");
                    //U', RALG, Y, LALG
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The RG piece is in the top YO place with red facing up\nY, LALG, Y', RALG");
                    //Y, LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[0] == 2) //YG
            {
                if (RG_G.transform.position.y > RG_R.transform.position.y) //checked
                {
                    Debug.Log("The RG piece is in the top YG place with green facing up\nU, U, RALG, Y, LALG");
                    //U, U, RALG, Y, LALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The RG piece is in the top YG place with red facing up\nY, U', LALG, Y', RALG");
                    //Y, U', LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
            else if (objectIndex[2] == 2) //YR
            {
                if (RG_G.transform.position.y < RG_R.transform.position.y)
                {
                    Debug.Log("The RG piece is in the top YR place with green facing up\nU, RALG, Y, LALG");
                    //U, RALG, Y, LALG
                    pieces = rotateBigCube.U(0, 90, 0);
                    pieces = rotateBigCube.RALG();
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.LALG();
                }
                else
                {
                    Debug.Log("The RG piece is in the top YR place with red facing up\nY, U', U', LALG, Y', RALG");
                    //Y, U', U', LALG, Y', RALG
                    pieces = rotateBigCube.fullRotation(0, 90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.U(0, -90, 0);
                    pieces = rotateBigCube.LALG();
                    pieces = rotateBigCube.fullRotation(0, -90, 0);
                    pieces = rotateBigCube.RALG();
                }
            }
        }*/
        return pieces;
    }
}