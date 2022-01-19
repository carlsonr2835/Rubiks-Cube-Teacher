using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWindow : MonoBehaviour
{
    private string input;
    RotateBigCube rotateBigCube;
    //PivotRotation pivotRotation;
    CubeState cubeState;
    ReadCube readCube;
    solveCube solveC;
    ScrambleCube scrambleCube;
    public List<List<List<GameObject>>> pieces = new List<List<List<GameObject>>>();

    // Start is called before the first frame update
    void Start()
    {
        // pivotRotation = FindObjectOfType<PivotRotation>();
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadStringInput(string s)
    {
        input = s;
        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();
        solveC = GameObject.Find("CubeHolder").GetComponent<solveCube>();
        scrambleCube = GameObject.Find("CubeHolder").GetComponent<ScrambleCube>();
        //readCube.ReadState();
        /*List<GameObject> side = new List<GameObject>()
        {
            cubeState.up,
            cubeState.down,
            cubeState.right,
            cubeState.left,
            cubeState.back,
            cubeState.front
        };*/

        //interpreting input
        //single layer turns
        if (input == "U")
        {
            Debug.Log("Turn up clockwise");
            pieces = rotateBigCube.U(0, 90, 0);
        }
        else if (input == "U'")
        {
            Debug.Log("Turn up counterclockwise");
            pieces = rotateBigCube.U(0, -90, 0);
        }
        else if (input == "D")
        {
            Debug.Log("Turn down clockwise");
            pieces = rotateBigCube.D(0, -90, 0);
        }
        else if (input == "D'")
        {
            Debug.Log("Turn down counterclockwise");
            pieces = rotateBigCube.D(0, 90, 0);
        }
        else if (input == "B")
        {
            Debug.Log("Turn back clockwise");
            pieces = rotateBigCube.B(90, 0, 0);
        }
        else if (input == "B'")
        {
            Debug.Log("Turn back counterclockwise");
            pieces = rotateBigCube.B(-90, 0, 0);
        }
        else if (input == "F")
        {
            Debug.Log("Turn front clockwise");
            pieces = rotateBigCube.F(-90, 0, 0);
        }
        else if (input == "F'")
        {
            Debug.Log("Turn front counterclockwise");
            pieces = rotateBigCube.F(90, 0, 0);
        }
        else if (input == "L")
        {
            Debug.Log("Turn left clockwise");
            pieces = rotateBigCube.L(0, 0, 90);
        }
        else if (input == "L'")
        {
            Debug.Log("Turn left counterclockwise");
            pieces = rotateBigCube.L(0, 0, -90);
        }
        else if (input == "R")
        {
            Debug.Log("Turn right clockwise");
            pieces = rotateBigCube.R(0, 0, -90);
        }
        else if (input == "R'")
        {
            Debug.Log("Turn right counterclockwise");
            pieces = rotateBigCube.R(0, 0, 90);
        }
        //double layer turns
        else if (input == "u")
        {
            Debug.Log("Turn 2 up clockwise");
            pieces = rotateBigCube.u(true);
        }
        else if (input == "u'")
        {
            Debug.Log("Turn 2 up counterclockwise");
            pieces = rotateBigCube.u(false);
        }
        else if (input == "d")
        {
            Debug.Log("Turn 2 down clockwise");
            pieces = rotateBigCube.d(true);
        }
        else if (input == "d'")
        {
            Debug.Log("Turn 2 down counterclockwise");
            pieces = rotateBigCube.d(false);
        }
        else if (input == "b")
        {
            Debug.Log("Turn 2 back clockwise");
            pieces = rotateBigCube.b(true);
        }
        else if (input == "b'")
        {
            Debug.Log("Turn 2 back counterclockwise");
            pieces = rotateBigCube.b(false);
        }
        else if (input == "f")
        {
            Debug.Log("Turn 2 front clockwise");
            pieces = rotateBigCube.f(true);
        }
        else if (input == "f'")
        {
            Debug.Log("Turn 2 front counterclockwise");
            pieces = rotateBigCube.f(false);
        }
        else if (input == "l")
        {
            Debug.Log("Turn 2 left clockwise");
            pieces = rotateBigCube.l(true);
        }
        else if (input == "l'")
        {
            Debug.Log("Turn 2 left counterclockwise");
            pieces = rotateBigCube.l(false);
        }
        else if (input == "r")
        {
            Debug.Log("Turn 2 right clockwise");
            pieces = rotateBigCube.r(true);
        }
        else if (input == "r'")
        {
            Debug.Log("Turn 2 right counterclockwise");
            pieces = rotateBigCube.r(false);
        }
        //middle layer turns 
        else if (input == "S")
        {
            Debug.Log("Turn mid s clockwise");
            pieces = rotateBigCube.S(-90, 0, 0);
        }
        else if (input == "S'")
        {
            Debug.Log("Turn mid s counterclockwise");
            pieces = rotateBigCube.S(90, 0, 0);
        }
        else if (input == "E")
        {
            Debug.Log("Turn equator clockwise");
            pieces = rotateBigCube.E(0, 90, 0);
        }
        else if (input == "E'")
        {
            Debug.Log("Turn equator counterclockwise");
            pieces = rotateBigCube.E(0, -90, 0);
        }
        else if (input == "M")
        {
            Debug.Log("Turn meridian clockwise");
            pieces = rotateBigCube.M(0, 0, -90);
        }
        else if (input == "M'")
        {
            Debug.Log("Turn meridian counterclockwise");
            pieces = rotateBigCube.M(0, 0, 90);
        }
        //rotations 
        else if (input == "X")
        {
            Debug.Log("Turn cube clockwise on x axis");
            rotateBigCube.fullRotation(90, 0, 0);
        }
        else if (input == "X'")
        {
            Debug.Log("Turn cube counterclockwise on x axis");
            rotateBigCube.fullRotation(-90, 0, 0);
        }
        else if (input == "Y")
        {
            Debug.Log("Turn cube clockwise on y axis");
            rotateBigCube.fullRotation(0, 90, 0);
        }
        else if (input == "Y'")
        {
            Debug.Log("Turn cube counterclockwise on y axis");
            rotateBigCube.fullRotation(0, -90, 0);
        }
        else if (input == "Z")
        {
            Debug.Log("Turn cube clockwise on z axis");
            rotateBigCube.fullRotation(0, 0, 90);
        }
        else if (input == "Z'")
        {
            Debug.Log("Turn cube counterclockwise on z axis");
            rotateBigCube.fullRotation(0, 0, -90);
        }
        else if (input == "solve" || input == "Solve" || input == "SOLVE")
        {
            pieces = solveC.whiteCross(pieces);
            pieces = solveC.whiteCorners(pieces);
            //pieces = solveC.secondLayer(pieces);
        }
        else if (input == "Scramble" || input == "scramble" || input == "SCRAMBLE")
        {
            pieces = scrambleCube.scramble(pieces);
        }
        else
        {
            Debug.Log("Not a valid move");
        }
    }
}