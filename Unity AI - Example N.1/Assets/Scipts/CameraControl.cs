using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject objective;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - objective.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = objective.transform.position + offset;
    }

}
