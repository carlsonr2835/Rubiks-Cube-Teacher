using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleCube : MonoBehaviour
{
    RotateBigCube rotateBigCube;
    // Start is called before the first frame update
    void Start()
    {
        rotateBigCube = GameObject.Find("CubeHolder").GetComponent<RotateBigCube>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<List<List<GameObject>>> scramble (List<List<List<GameObject>>> pieces)    {        int randomMoves = Random.Range(5, 20);        for (int i = 0; i < randomMoves; i++)        {            int randomMove = Random.Range(1, 12); //36 is the full amount of moves, 12 are the standard moves            if (randomMove == 1)            {                Debug.Log("Turn up clockwise");                pieces = rotateBigCube.U(0, 90, 0);            }            else if (randomMove == 2)            {                Debug.Log("Turn up counterclockwise");                pieces = rotateBigCube.U(0, -90, 0);            }            else if (randomMove == 3)            {                Debug.Log("Turn down clockwise");                pieces = rotateBigCube.D(0, -90, 0);            }            else if (randomMove == 4)            {                Debug.Log("Turn down counterclockwise");                pieces = rotateBigCube.D(0, 90, 0);            }            else if (randomMove == 5)            {                Debug.Log("Turn back clockwise");                pieces = rotateBigCube.B(90, 0, 0);            }            else if (randomMove == 6)            {                Debug.Log("Turn back counterclockwise");                pieces = rotateBigCube.B(-90, 0, 0);            }            else if (randomMove == 7)            {                Debug.Log("Turn front clockwise");                pieces = rotateBigCube.F(-90, 0, 0);            }            else if (randomMove == 8)            {                Debug.Log("Turn front counterclockwise");                pieces = rotateBigCube.F(90, 0, 0);            }            else if (randomMove == 9)            {                Debug.Log("Turn left clockwise");                pieces = rotateBigCube.L(0, 0, 90);            }            else if (randomMove == 10)            {                Debug.Log("Turn left counterclockwise");                pieces = rotateBigCube.L(0, 0, -90);            }            else if (randomMove == 11)            {                Debug.Log("Turn right clockwise");                pieces = rotateBigCube.R(0, 0, -90);            }            else if (randomMove == 12)            {                Debug.Log("Turn right counterclockwise");                pieces = rotateBigCube.R(0, 0, 90);            }        }        return pieces;    }
}
