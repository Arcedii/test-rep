using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
     void FixedUpdate()
    {
        Quaternion rottationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation*= rottationY;
    }
}
