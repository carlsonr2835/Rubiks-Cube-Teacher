using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;
    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<cubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            readCube.ReadState();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeState.up;
                    cubeState.down;
                    cubeState.left;
                    cubeState.front;
                    cubeState.back;
                };
                
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(SelectFace))
                    {
                        //make children of that side so it can rotate from middle
                        cubeState.PickUp(cubeSide);
                    }
                }
            }
        }
    }
}
