using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    public GameObject Cube;
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

}
