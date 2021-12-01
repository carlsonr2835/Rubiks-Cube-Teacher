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

    private float clockAngle = 90.0f;
    private float counterAngle = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        //List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();
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
        pieces[2][2][2] = WRB;
    }

    // Update is called once per frame
    void Update()
    {
        //Swipe();

    }
    /*List<List<List<GameObject>>> swap(List<int> indexOne, List<int> indexTwo, List<List<List<GameObject>>> pieces)    {        GameObject temp = pieces[indexOne[0]][indexOne[1]][indexOne[2]];        pieces[indexOne[0]][indexOne[1]][indexOne[2]] = pieces[indexTwo[0]][indexTwo[1]][indexTwo[2]];        pieces[indexTwo[0]][indexTwo[1]][indexTwo[2]] = temp;        return pieces;    }*/
    //full cube rotations
    public void XClock()
    {
        Cube.transform.Rotate(90, 0, 0, Space.World);
    }
    public void XCounter()
    {
        Cube.transform.Rotate(-90, 0, 0, Space.World);
    }
    public void YClock()
    {
        Cube.transform.Rotate(0, 90, 0, Space.World);
    }
    public void YCounter()
    {
        Cube.transform.Rotate(0, -90, 0, Space.World);
    }
    public void ZClock()
    {
        Cube.transform.Rotate(0, 0, 90, Space.World);
    }
    public void ZCounter()
    {
        Cube.transform.Rotate(0, 0, -90, Space.World);
    }
    //side rotations
    public void U(int x, int y, int z) //make a u method that takes in rotation so clock and counter is not necessary    {         pieces[0][2][0].transform.parent = Up.transform; //WOG        pieces[1][2][0].transform.parent = Up.transform;        pieces[2][2][0].transform.parent = Up.transform;        pieces[0][2][1].transform.parent = Up.transform;        pieces[2][2][1].transform.parent = Up.transform;        pieces[0][2][2].transform.parent = Up.transform;        pieces[1][2][2].transform.parent = Up.transform;        pieces[2][2][2].transform.parent = Up.transform;        Up.transform.Rotate(x, y, z, Space.World);        pieces[0][2][0].transform.parent = Cube.transform;        pieces[1][2][0].transform.parent = Cube.transform;        pieces[2][2][0].transform.parent = Cube.transform;        pieces[0][2][1].transform.parent = Cube.transform;        pieces[2][2][1].transform.parent = Cube.transform;        pieces[0][2][2].transform.parent = Cube.transform;        pieces[1][2][2].transform.parent = Cube.transform;        pieces[2][2][2].transform.parent = Cube.transform;        if (y < 0) //counter        {            GameObject temp = pieces[2][2][1];            pieces[2][2][1] = pieces[1][2][2];            pieces[1][2][2] = pieces[0][2][1];            pieces[0][2][1] = pieces[1][2][0];            pieces[1][2][0] = temp;            temp = pieces[2][2][0];            pieces[2][2][0] = pieces[2][2][2];            pieces[2][2][2] = pieces[0][2][2];            pieces[0][2][2] = pieces[0][2][0];            pieces[0][2][0] = temp;        }        else if (y > 0) //clock        {            GameObject temp = pieces[1][2][0];            pieces[1][2][0] = pieces[0][2][1];            pieces[0][2][1] = pieces[1][2][2];            pieces[1][2][2] = pieces[2][2][1];            pieces[2][2][1] = temp;            temp = pieces[0][2][0];            pieces[0][2][0] = pieces[0][2][2];            pieces[0][2][2] = pieces[2][2][2];            pieces[2][2][2] = pieces[2][2][0];            pieces[2][2][0] = temp;        }    }
    public void D(int x, int y, int z)    {        pieces[0][0][0].transform.parent = Down.transform; //WOG        pieces[1][0][0].transform.parent = Down.transform;        pieces[2][0][0].transform.parent = Down.transform;        pieces[0][0][1].transform.parent = Down.transform;        pieces[2][0][1].transform.parent = Down.transform;        pieces[0][0][2].transform.parent = Down.transform;        pieces[1][0][2].transform.parent = Down.transform;        pieces[2][0][2].transform.parent = Down.transform;        Down.transform.Rotate(x, y, z, Space.World);        pieces[0][0][0].transform.parent = Cube.transform;        pieces[1][0][0].transform.parent = Cube.transform;        pieces[2][0][0].transform.parent = Cube.transform;        pieces[0][0][1].transform.parent = Cube.transform;        pieces[2][0][1].transform.parent = Cube.transform;        pieces[0][0][2].transform.parent = Cube.transform;        pieces[1][0][2].transform.parent = Cube.transform;        pieces[2][0][2].transform.parent = Cube.transform;        pieces[0][0][0] = WRG;        pieces[1][0][0] = WG;        pieces[2][0][0] = WOG;        pieces[0][0][1] = WR;        pieces[2][0][1] = WO;        pieces[0][0][2] = WRB;        pieces[1][0][2] = WB;        pieces[2][0][2] = WOB;    }
    public void B(int x, int y, int z)    {        pieces[0][0][0].transform.parent = Back.transform; //WOG        pieces[1][0][0].transform.parent = Back.transform;        pieces[2][0][0].transform.parent = Back.transform;        pieces[0][1][0].transform.parent = Back.transform;        pieces[2][1][0].transform.parent = Back.transform;        pieces[0][2][0].transform.parent = Back.transform;        pieces[1][2][0].transform.parent = Back.transform;        pieces[2][2][0].transform.parent = Back.transform;        Back.transform.Rotate(x, y, z, Space.World);        pieces[0][0][0].transform.parent = Cube.transform;        pieces[1][0][0].transform.parent = Cube.transform;        pieces[2][0][0].transform.parent = Cube.transform;        pieces[0][1][0].transform.parent = Cube.transform;        pieces[2][1][0].transform.parent = Cube.transform;        pieces[0][2][0].transform.parent = Cube.transform;        pieces[1][2][0].transform.parent = Cube.transform;        pieces[2][2][0].transform.parent = Cube.transform;        if (x > 0) //incomplete        {            GameObject temp = pieces[2][2][0];            pieces[2][2][0] = pieces[1][1][0];            pieces[1][1][0] = pieces[0][2][0];            pieces[0][2][0] = pieces[1][2][0];            pieces[1][2][0] = temp;            temp = pieces[2][2][0];            pieces[2][2][0] = pieces[2][2][0];            pieces[2][2][0] = pieces[0][2][0];            pieces[0][2][0] = pieces[0][2][0];            pieces[0][2][0] = temp;        }        else if (x < 0)        {        }    }
    public void BCounter()    {        /*BD.transform.parent = B.transform;        LBD.transform.parent = B.transform;        RBD.transform.parent = B.transform;        LB.transform.parent = B.transform;        RB.transform.parent = B.transform;        UB.transform.parent = B.transform;        UBL.transform.parent = B.transform;        UBR.transform.parent = B.transform;        B.transform.Rotate(-90, 0, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LB.transform.parent = Cube.transform;        RB.transform.parent = Cube.transform;        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;*/    }
    public void FClock()    {    }
    public void FCounter()    {    }
    public void LClock()    {    }
    public void LCounter()    {    }
    public void RClock()    {    }
    public void RCounter()    {    }
    //double turns
    public void uClock()    {    }
    public void uCounter()    {    }
    public void dClock()    {    }
    public void dCounter()    {    }
    public void bClock()    {    }
    public void bCounter()    {    }
    public void fClock()    {    }
    public void fCounter()    {    }
    public void lClock()    {    }
    public void lCounter()    {    }
    public void rClock()    {    }
    public void rCounter()    {    }
    //mid layer turns
    public void MClock()    {    }
    public void MCounter()    {    }
    public void EClock()    {    }
    public void ECounter()    {    }
    public void SClock()    {    }
    public void SCounter()    {    }
}
