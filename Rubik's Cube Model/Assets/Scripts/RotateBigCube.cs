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

    private float clockAngle = 90.0f;
    private float counterAngle = -90.0f;

    // Start is called before the first frame update
    void Start()
    {
        List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();
        for (int x = 0; x < 3; x++)        {            List<List<GameObject>> twoDim = new List<List<GameObject>>();            for (int y = 0; y < 3; y++)            {                List<GameObject> oneDim = new List<GameObject>();                for (int z = 0; z < 3; z++)                {                    oneDim.Add(null);                }                twoDim.Add(oneDim);            }            pieces.Add(twoDim);        }
    }

    // Update is called once per frame
    void Update()
    {
        //Swipe();

    }
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
    public void UClock()    {        /*UB.transform.parent = U.transform;        UBL.transform.parent = U.transform;        UBR.transform.parent = U.transform;        UR.transform.parent = U.transform;        UL.transform.parent = U.transform;        UFR.transform.parent = U.transform;        UFL.transform.parent = U.transform;        UF.transform.parent = U.transform;        U.transform.Rotate(0, 90, 0, Space.World);        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;        UR.transform.parent = Cube.transform;        UL.transform.parent = Cube.transform;        UFR.transform.parent = Cube.transform;        UFL.transform.parent = Cube.transform;        UF.transform.parent = Cube.transform;*/    }
    public void UCounter()    {        /*UB.transform.parent = U.transform;        UBL.transform.parent = U.transform;        UBR.transform.parent = U.transform;        UR.transform.parent = U.transform;        UL.transform.parent = U.transform;        UFR.transform.parent = U.transform;        UFL.transform.parent = U.transform;        UF.transform.parent = U.transform;        U.transform.Rotate(0, -90, 0, Space.World);        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;        UR.transform.parent = Cube.transform;        UL.transform.parent = Cube.transform;        UFR.transform.parent = Cube.transform;        UFL.transform.parent = Cube.transform;        UF.transform.parent = Cube.transform;*/    }
    public void DClock()    {        /*BD.transform.parent = D.transform;        LBD.transform.parent = D.transform;        RBD.transform.parent = D.transform;        LD.transform.parent = D.transform;        RD.transform.parent = D.transform;        FD.transform.parent = D.transform;        FLD.transform.parent = D.transform;        FRD.transform.parent = D.transform;        D.transform.Rotate(0, -90, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LD.transform.parent = Cube.transform;        RD.transform.parent = Cube.transform;        FD.transform.parent = Cube.transform;        FLD.transform.parent = Cube.transform;        FRD.transform.parent = Cube.transform;*/    }
    public void DCounter()    {        /*BD.transform.parent = D.transform;        LBD.transform.parent = D.transform;        RBD.transform.parent = D.transform;        LD.transform.parent = D.transform;        RD.transform.parent = D.transform;        FD.transform.parent = D.transform;        FLD.transform.parent = D.transform;        FRD.transform.parent = D.transform;        D.transform.Rotate(0, 90, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LD.transform.parent = Cube.transform;        RD.transform.parent = Cube.transform;        FD.transform.parent = Cube.transform;        FLD.transform.parent = Cube.transform;        FRD.transform.parent = Cube.transform;*/    }
    public void BClock()    {        /*BD.transform.parent = B.transform;        LBD.transform.parent = B.transform;        RBD.transform.parent = B.transform;        LB.transform.parent = B.transform;        RB.transform.parent = B.transform;        UB.transform.parent = B.transform;        UBL.transform.parent = B.transform;        UBR.transform.parent = B.transform;        B.transform.Rotate(90, 0, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LB.transform.parent = Cube.transform;        RB.transform.parent = Cube.transform;        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;*/    }
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
