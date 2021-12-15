using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWindow : MonoBehaviour
{
    private string input;
    RotateBigCube rotateBigCube;    //PivotRotation pivotRotation;    CubeState cubeState;    ReadCube readCube;    solveCube solveC;    // Start is called before the first frame update    void Start()
    {       // pivotRotation = FindObjectOfType<PivotRotation>();    }

    // Update is called once per frame
    void Update()
    {    }

    public void ReadStringInput(string s)
    {
        input = s;
        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();        solveC = GameObject.Find("CubeHolder").GetComponent<solveCube>();        //readCube.ReadState();        /*List<GameObject> side = new List<GameObject>()        {            cubeState.up,            cubeState.down,            cubeState.right,            cubeState.left,            cubeState.back,            cubeState.front        };*/        //interpreting input        //single layer turns        if (input == "U")        {
            Debug.Log("Turn up clockwise");
            rotateBigCube.U(0, 90, 0);
        }
        else if (input == "U'")        {
            Debug.Log("Turn up counterclockwise");
            rotateBigCube.U(0, -90, 0);
        }
        else if (input == "D")        {
            Debug.Log("Turn down clockwise");
            rotateBigCube.D(0, -90, 0);
        }
        else if (input == "D'")        {
            Debug.Log("Turn down counterclockwise");
            rotateBigCube.D(0, 90, 0);
        }
        else if (input == "B")        {
            Debug.Log("Turn back clockwise");
            rotateBigCube.B(90, 0, 0);
        }
        else if (input == "B'")        {
            Debug.Log("Turn back counterclockwise");
            rotateBigCube.B(-90, 0, 0);
        }
        else if (input == "F")        {            Debug.Log("Turn front clockwise");            rotateBigCube.F(-90, 0, 0);        }        else if (input == "F'")        {            Debug.Log("Turn front counterclockwise");            rotateBigCube.F(90, 0, 0);        }        else if (input == "L")        {            Debug.Log("Turn left clockwise");            rotateBigCube.L(0, 0, 90);        }        else if (input == "L'")        {            Debug.Log("Turn left counterclockwise");            rotateBigCube.L(0, 0, -90);        }        else if (input == "R")        {            Debug.Log("Turn right clockwise");            rotateBigCube.R(0, 0, -90);        }        else if (input == "R'")        {            Debug.Log("Turn right counterclockwise");            rotateBigCube.R(0, 0, 90);        }        //double layer turns        else if (input == "u")        {            Debug.Log("Turn 2 up clockwise");            rotateBigCube.u(true);        }        else if (input == "u'")        {            Debug.Log("Turn 2 up counterclockwise");            rotateBigCube.u(false);        }        else if (input == "d")        {            Debug.Log("Turn 2 down clockwise");            rotateBigCube.d(true);        }        else if (input == "d'")        {            Debug.Log("Turn 2 down counterclockwise");            rotateBigCube.d(false);        }        else if (input == "b")        {            Debug.Log("Turn 2 back clockwise");            rotateBigCube.b(true);        }        else if (input == "b'")        {            Debug.Log("Turn 2 back counterclockwise");            rotateBigCube.b(false);        }        else if (input == "f")        {            Debug.Log("Turn 2 front clockwise");            rotateBigCube.f(true);        }        else if (input == "f'")        {            Debug.Log("Turn 2 front counterclockwise");            rotateBigCube.f(false);        }        else if (input == "l")        {            Debug.Log("Turn 2 left clockwise");            rotateBigCube.l(true);        }        else if (input == "l'")        {            Debug.Log("Turn 2 left counterclockwise");            rotateBigCube.l(false);        }        else if (input == "r")        {            Debug.Log("Turn 2 right clockwise");            rotateBigCube.r(true);        }        else if (input == "r'")        {            Debug.Log("Turn 2 right counterclockwise");            rotateBigCube.r(false);        }        //middle layer turns         else if (input == "S")        {            Debug.Log("Turn mid s clockwise");            rotateBigCube.S(-90, 0, 0);        }        else if (input == "S'")        {            Debug.Log("Turn mid s counterclockwise");            rotateBigCube.S(90, 0, 0);        }        else if (input == "E")        {            Debug.Log("Turn equator clockwise");            rotateBigCube.E(0, 90, 0);        }        else if (input == "E'")        {            Debug.Log("Turn equator counterclockwise");            rotateBigCube.E(0, -90, 0);        }        else if (input == "M")        {            Debug.Log("Turn meridian clockwise");            rotateBigCube.M(0, 0, -90);        }        else if (input == "M'")        {            Debug.Log("Turn meridian counterclockwise");            rotateBigCube.M(0, 0, 90);        }        //rotations         else if (input == "X")        {            Debug.Log("Turn cube clockwise on x axis");            rotateBigCube.fullRotation(90, 0, 0);        }        else if (input == "X'")        {            Debug.Log("Turn cube counterclockwise on x axis");            rotateBigCube.fullRotation(-90, 0, 0);        }        else if (input == "Y")        {            Debug.Log("Turn cube clockwise on y axis");            rotateBigCube.fullRotation(0, 90, 0);        }        else if (input == "Y'")        {            Debug.Log("Turn cube counterclockwise on y axis");            rotateBigCube.fullRotation(0, -90, 0);        }        else if (input == "Z")        {            Debug.Log("Turn cube clockwise on z axis");            rotateBigCube.fullRotation(0, 0, 90);        }        else if (input == "Z'")        {            Debug.Log("Turn cube counterclockwise on z axis");            rotateBigCube.fullRotation(0, 0, -90);        }        else if (input == "solve" || input == "Solve" || input == "SOLVE")        {            solveC.whiteCross();        }        else        {
            Debug.Log("Not a valid move");
        }
    }
}