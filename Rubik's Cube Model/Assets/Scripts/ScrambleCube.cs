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
    List<List<List<GameObject>>> scramble (List<List<List<GameObject>>> pieces)
}