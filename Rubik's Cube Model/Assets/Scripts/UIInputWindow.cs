using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWindow : MonoBehaviour
{
    private string input;
    RotateBigCube rotateBigCube;    //PivotRotation pivotRotation;    CubeState cubeState;    ReadCube readCube;    // Start is called before the first frame update    void Start()
    {       // pivotRotation = FindObjectOfType<PivotRotation>();    }

    // Update is called once per frame
    void Update()
    {    }

    public void ReadStringInput(string s)
    {
        input = s;
        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();        //readCube.ReadState();        /*List<GameObject> side = new List<GameObject>()        {            cubeState.up,            cubeState.down,            cubeState.right,            cubeState.left,            cubeState.back,            cubeState.front        };*/                //interpreting input        //single layer turns        if (input == "U")        {
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
        else if (input == "F")        {            Debug.Log("Turn front clockwise");            rotateBigCube.F(-90, 0, 0);        }        else if (input == "F'")        {            Debug.Log("Turn front counterclockwise");            rotateBigCube.F(90, 0, 0);        }        else if (input == "L")        {            Debug.Log("Turn left clockwise");            rotateBigCube.L(0, 0, 90);        }        else if (input == "L'")        {            Debug.Log("Turn left counterclockwise");            rotateBigCube.L(0, 0, -90);        }        else if (input == "R")        {            Debug.Log("Turn right clockwise");            rotateBigCube.R(0, 0, -90);        }        else if (input == "R'")        {            Debug.Log("Turn right counterclockwise");            rotateBigCube.R(0, 0, 90);        }        //double layer turns        else if (input == "u")        {
            Debug.Log("Turn 2 up clockwise");
            rotateBigCube.uClock();
        }
        else if (input == "u'")        {
            Debug.Log("Turn 2 up counterclockwise");
            rotateBigCube.uCounter();
        }
        else if (input == "d")        {
            Debug.Log("Turn 2 down clockwise");
            rotateBigCube.dClock();
        }
        else if (input == "d'")        {
            Debug.Log("Turn 2 down counterclockwise");
            rotateBigCube.dCounter();
        }
        else if (input == "b")        {
            Debug.Log("Turn 2 back clockwise");
            rotateBigCube.bClock();
        }
        else if (input == "b'")        {
            Debug.Log("Turn 2 back counterclockwise");
            rotateBigCube.bCounter();
        }
        else if (input == "f")        {
            Debug.Log("Turn 2 front clockwise");
            rotateBigCube.fClock();
        }
        else if (input == "f'")        {
            Debug.Log("Turn 2 front counterclockwise");
            rotateBigCube.fCounter();
        }
        else if (input == "l")        {
            Debug.Log("Turn 2 left clockwise");
            rotateBigCube.lClock();
        }
        else if (input == "l'")        {
            Debug.Log("Turn 2 left counterclockwise");
            rotateBigCube.lCounter();
        }
        else if (input == "r")        {
            Debug.Log("Turn 2 right clockwise");
            rotateBigCube.rClock();
        }
        else if (input == "r'")        {
            Debug.Log("Turn 2 right counterclockwise");
            rotateBigCube.rCounter();
        }

        //middle layer turns
        else if (input == "S")        {
            Debug.Log("Turn middle clockwise");
            rotateBigCube.S(-90, 0, 0);
        }
        else if (input == "S'")        {
            Debug.Log("Turn middle counterclockwise");
            rotateBigCube.S(90, 0, 0);
        }
        else if (input == "E")        {            Debug.Log("Turn equator clockwise");            rotateBigCube.E(0, 90, 0);        }        else if (input == "E'")        {            Debug.Log("Turn equator counterclockwise");            rotateBigCube.E(0, -90, 0);        }        else if (input == "M")        {
            Debug.Log("Turn side clockwise");
            rotateBigCube.M(0, 0, 90);
        }
        else if (input == "M'")        {
            Debug.Log("Turn side counterclockwise");
            rotateBigCube.M(0, 0, -90);
        }

        //rotations
        else if (input == "X")        {            Debug.Log("Turn cube clockwise on x axis");            rotateBigCube.fullRotation(90, 0, 0);        }        else if (input == "X'")        {            Debug.Log("Turn cube counterclockwise on x axis");            rotateBigCube.fullRotation(-90, 0, 0);        }        else if (input == "Y")        {            Debug.Log("Turn cube clockwise on y axis");            rotateBigCube.fullRotation(0, 90, 0);        }        else if (input == "Y'")        {            Debug.Log("Turn cube counterclockwise on y axis");            rotateBigCube.fullRotation(0, -90, 0);        }        else if (input == "Z")        {            Debug.Log("Turn cube clockwise on z axis");            rotateBigCube.fullRotation(0, 0, 90);        }        else if (input == "Z'")        {            Debug.Log("Turn cube counterclockwise on z axis");            rotateBigCube.fullRotation(0, 0, -90);        }        else        {
            Debug.Log("Not a valid move");
        }
    }
}