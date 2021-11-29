using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    public GameObject Cube;

    public GameObject BD;
    public GameObject LBD;
    public GameObject RBD;
    public GameObject D;
    public GameObject LD;
    public GameObject RD;
    public GameObject FD;
    public GameObject FLD;
    public GameObject FRD;
    public GameObject B;
    public GameObject LB;
    public GameObject RB;
    public GameObject R;
    public GameObject L;
    public GameObject M;
    public GameObject FR;
    public GameObject FL;
    public GameObject F;
    public GameObject U;
    public GameObject UB;
    public GameObject UBL;
    public GameObject UBR;
    public GameObject UR;
    public GameObject UL;
    public GameObject UFR;
    public GameObject UFL;
    public GameObject UF;

    private float clockAngle = 90.0f;
    private float counterAngle = -90.0f;

    // Start is called before the first frame update
    void Start()
    {

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
    public void UClock()    {        UB.transform.parent = U.transform;        UBL.transform.parent = U.transform;        UBR.transform.parent = U.transform;        UR.transform.parent = U.transform;        UL.transform.parent = U.transform;        UFR.transform.parent = U.transform;        UFL.transform.parent = U.transform;        UF.transform.parent = U.transform;        U.transform.Rotate(0, 90, 0, Space.World);        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;        UR.transform.parent = Cube.transform;        UL.transform.parent = Cube.transform;        UFR.transform.parent = Cube.transform;        UFL.transform.parent = Cube.transform;        UF.transform.parent = Cube.transform;    }
    public void UCounter()    {        UB.transform.parent = U.transform;        UBL.transform.parent = U.transform;        UBR.transform.parent = U.transform;        UR.transform.parent = U.transform;        UL.transform.parent = U.transform;        UFR.transform.parent = U.transform;        UFL.transform.parent = U.transform;        UF.transform.parent = U.transform;        U.transform.Rotate(0, -90, 0, Space.World);        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;        UR.transform.parent = Cube.transform;        UL.transform.parent = Cube.transform;        UFR.transform.parent = Cube.transform;        UFL.transform.parent = Cube.transform;        UF.transform.parent = Cube.transform;    }
    public void DClock()    {        BD.transform.parent = D.transform;        LBD.transform.parent = D.transform;        RBD.transform.parent = D.transform;        LD.transform.parent = D.transform;        RD.transform.parent = D.transform;        FD.transform.parent = D.transform;        FLD.transform.parent = D.transform;        FRD.transform.parent = D.transform;        D.transform.Rotate(0, -90, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LD.transform.parent = Cube.transform;        RD.transform.parent = Cube.transform;        FD.transform.parent = Cube.transform;        FLD.transform.parent = Cube.transform;        FRD.transform.parent = Cube.transform;    }
    public void DCounter()    {        BD.transform.parent = D.transform;        LBD.transform.parent = D.transform;        RBD.transform.parent = D.transform;        LD.transform.parent = D.transform;        RD.transform.parent = D.transform;        FD.transform.parent = D.transform;        FLD.transform.parent = D.transform;        FRD.transform.parent = D.transform;        D.transform.Rotate(0, 90, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LD.transform.parent = Cube.transform;        RD.transform.parent = Cube.transform;        FD.transform.parent = Cube.transform;        FLD.transform.parent = Cube.transform;        FRD.transform.parent = Cube.transform;    }
    public void BClock()    {        BD.transform.parent = B.transform;        LBD.transform.parent = B.transform;        RBD.transform.parent = B.transform;        LB.transform.parent = B.transform;        RB.transform.parent = B.transform;        UB.transform.parent = B.transform;        UBL.transform.parent = B.transform;        UBR.transform.parent = B.transform;        B.transform.Rotate(90, 0, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LB.transform.parent = Cube.transform;        RB.transform.parent = Cube.transform;        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;    }
    public void BCounter()    {        BD.transform.parent = B.transform;        LBD.transform.parent = B.transform;        RBD.transform.parent = B.transform;        LB.transform.parent = B.transform;        RB.transform.parent = B.transform;        UB.transform.parent = B.transform;        UBL.transform.parent = B.transform;        UBR.transform.parent = B.transform;        B.transform.Rotate(-90, 0, 0, Space.World);        BD.transform.parent = Cube.transform;        LBD.transform.parent = Cube.transform;        RBD.transform.parent = Cube.transform;        LB.transform.parent = Cube.transform;        RB.transform.parent = Cube.transform;        UB.transform.parent = Cube.transform;        UBL.transform.parent = Cube.transform;        UBR.transform.parent = Cube.transform;    }
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
