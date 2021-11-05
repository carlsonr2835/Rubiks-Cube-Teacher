using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWindow : MonoBehaviour
{
    private string input;
    RotateBigCube rotateBigCube;    // Start is called before the first frame update    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {    }

    public void ReadStringInput(string s)
    {
        input = s;
        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();        //RotateBigCube rotate = GetComponent<RotateBigCube>();        //interpreting input        //single layer turns        if (input == "U")        {
            Debug.Log("Turn up clockwise");
        }
        else if (input == "U'")        {
            Debug.Log("Turn up counterclockwise");
        }
        else if (input == "D")        {
            Debug.Log("Turn down clockwise");
        }
        else if (input == "D'")        {
            Debug.Log("Turn down counterclockwise");
        }
        else if (input == "B")        {
            Debug.Log("Turn back clockwise");
        }
        else if (input == "B'")        {
            Debug.Log("Turn back counterclockwise");
        }
        else if (input == "F")        {
            Debug.Log("Turn front clockwise");
        }
        else if (input == "F'")        {
            Debug.Log("Turn front counterclockwise");
        }
        else if (input == "L")        {
            Debug.Log("Turn left clockwise");
        }
        else if (input == "L'")        {
            Debug.Log("Turn left counterclockwise");
        }
        else if (input == "R")        {
            Debug.Log("Turn right clockwise");
        }
        else if (input == "R'")        {
            Debug.Log("Turn right counterclockwise");
        }

        //double layer turns
        else if (input == "u")        {
            Debug.Log("Turn 2 up clockwise");
        }
        else if (input == "u'")        {
            Debug.Log("Turn 2 up counterclockwise");
        }
        else if (input == "d")        {
            Debug.Log("Turn 2 down clockwise");
        }
        else if (input == "d'")        {
            Debug.Log("Turn 2 down counterclockwise");
        }
        else if (input == "b")        {
            Debug.Log("Turn 2 back clockwise");
        }
        else if (input == "b'")        {
            Debug.Log("Turn 2 back counterclockwise");
        }
        else if (input == "f")        {
            Debug.Log("Turn 2 front clockwise");
        }
        else if (input == "f'")        {
            Debug.Log("Turn 2 front counterclockwise");
        }
        else if (input == "l")        {
            Debug.Log("Turn 2 left clockwise");
        }
        else if (input == "l'")        {
            Debug.Log("Turn 2 left counterclockwise");
        }
        else if (input == "r")        {
            Debug.Log("Turn 2 right clockwise");
        }
        else if (input == "r'")        {
            Debug.Log("Turn 2 right counterclockwise");
        }

        //middle layer turns
        else if (input == "M")        {
            Debug.Log("Turn middle clockwise");
        }
        else if (input == "M'")        {
            Debug.Log("Turn middle counterclockwise");
        }
        else if (input == "E")        {
            Debug.Log("Turn equator clockwise");
        }
        else if (input == "E'")        {
            Debug.Log("Turn equator counterclockwise");
        }
        else if (input == "S")        {
            Debug.Log("Turn side clockwise");
        }
        else if (input == "S'")        {
            Debug.Log("Turn side counterclockwise");
        }

        //rotations
        else if (input == "X")        {
            Debug.Log("Turn cube clockwise on x axis");
            rotateBigCube.XClock();        }
        else if (input == "X'")        {
            Debug.Log("Turn cube counterclockwise on x axis");
            rotateBigCube.XCounter();
        }
        else if (input == "Y")        {
            Debug.Log("Turn cube clockwise on y axis");
            rotateBigCube.YClock();
        }
        else if (input == "Y'")        {
            Debug.Log("Turn cube counterclockwise on y axis");
            rotateBigCube.YCounter();
        }
        else if (input == "Z")        {
            Debug.Log("Turn cube clockwise on z axis");
            rotateBigCube.ZClock();
        }
        else if (input == "Z'")        {
            Debug.Log("Turn cube counterclockwise on z axis");
            rotateBigCube.ZCounter();
        }

        else        {
            Debug.Log("Not a valid move");
        }
    }
}