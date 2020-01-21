using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scipts.AI_Scrtips.AIStructs;

public class MovePattern : MonoBehaviour
{
    //  public GameObject vectorDirection;

    private int numbOfSteps;
    private int index = 0;

    private float time = 0.0f;

    private List<SMovement.StMovement> pattern = new List<SMovement.StMovement>();

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //  We create a pattern.

        pattern.Add(new SMovement.StMovement(30, 2, 5, 3));
        pattern.Add(new SMovement.StMovement(-30, 2, 5, 2));
        pattern.Add(new SMovement.StMovement(0, 3, 5, 0));
        pattern.Add(new SMovement.StMovement(0, 2, 2, 0));
        pattern.Add(new SMovement.StMovement(15, 5, 0, 5));

        numbOfSteps = pattern.Count;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //  vectorDirection.transform.rotation = Quaternion.LookRotation(direction);

        time += Time.deltaTime;

        if (time > pattern[index].time)
        {
            //  Resets time and A.I moves, proceeds to the next step.
            time = 0;
            index++;

            if (index >= numbOfSteps)
            {
                index = 0;
            }
        }

        //  Rotation Vector calculation.
        direction = Quaternion.AngleAxis(pattern[index].rotation, Vector3.up) * transform.forward;

        //  Debug.DrawLine(vectorDirection.transform.position, direction, Color.black, 5.0f);

        Quaternion objRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, objRotation, pattern[index].rotVelocity * Time.deltaTime);

        transform.Translate(transform.forward * pattern[index].velocity * Time.deltaTime);

    }
}
