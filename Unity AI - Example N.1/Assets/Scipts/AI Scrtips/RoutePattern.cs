using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutePattern : MonoBehaviour
{
    public float velocity = 10;

    private int numbOfSteps;
    private int index = 0;

    private List<Vector3> route = new List<Vector3>();

    private Vector3 objective;
    // Start is called before the first frame update
    void Start()
    {
        route.Add(new Vector3(-10 ,0.5f ,10));
        route.Add(new Vector3(0, 0.5f, 3));
        route.Add(new Vector3(45, 0.5f, -30));
        route.Add(new Vector3(-25, 0.5f, -17));

        index = 0;
        objective = route[index];
        numbOfSteps = route.Count;

    }

    // Update is called once per frame
    void Update()
    {
        //  We verify if the A.I. has reached the point.

        if ((transform.position - route[index]).magnitude <1)
        {
            index++;

            if (index >= numbOfSteps)
            {
                index = 0;
            }

            objective = route[index];
        }

        transform.LookAt(objective);

        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
