using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform objective;

    private void LateUpdate()
    {
        transform.LookAt(objective);
    }

}
