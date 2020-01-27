using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaAvoid : MonoBehaviour
{
    public Transform player;

    private RaycastHit hitR;
    private RaycastHit hitL;

    private Vector3 rightSide;
    private Vector3 leftSide;
    private Vector3 objective;

    public float velocity = 5;
    public float detectionDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color rightColor = Color.green;
        Color leftColor = Color.green;

        objective = player.position;

        rightSide = transform.forward + (transform.right * 0.3f);
        leftSide = transform.forward - (transform.right * 0.3f);

        if (Physics.Raycast(transform.position, rightSide, out hitR, detectionDistance))
        {
            rightColor = Color.red;
            objective -= transform.right * (detectionDistance / hitR.distance);
        }

        if (Physics.Raycast(transform.position, leftSide, out hitL, detectionDistance))
        {
            leftColor = Color.red;
            objective += transform.right * (detectionDistance / hitL.distance);
        }

        Debug.DrawLine(transform.position, transform.position + rightSide * detectionDistance, rightColor);
        Debug.DrawLine(transform.position, transform.position + leftSide * detectionDistance, rightColor);

        transform.LookAt(objective);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
