using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLJ : MonoBehaviour
{
    public Transform[] obstacles = new Transform[10];
    public Transform player;

    private Vector3 r;
    private Vector3 u;
    private Vector3 fs;
    private Vector3 objective;

    public float velocity = 5.0f;
    private float B = 1300.0f;
    private float m = 2.0f;
    private float distance = 0;
    private float U;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fs = Vector3.zero;

        foreach (Transform obstacle in obstacles)
        {
            r = obstacle.position - transform.position;
            u = r;
            u.Normalize();

            distance = r.magnitude / 1.0f;  //  Change value 1 for better adjustment.

            U = B / Mathf.Pow(distance, m);

            fs -= u * U;
        }

        fs.Normalize();

        float a = 1;    //  Creates a scalar in Right.

        r = player.position - transform.position;
        distance = r.magnitude;

        if (distance > 10)
        {
            a = 1;
        }

        if (distance < 1)
        {
            a = 10;
        }

        objective = (r + fs * 10 / a) + transform.position;
        objective.y = transform.position.y;

        Debug.Log(fs + "        " + r + "       " + objective);
        transform.LookAt(objective);

        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
