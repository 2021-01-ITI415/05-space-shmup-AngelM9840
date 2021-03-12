using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy {

    [Header("Set in Inspector: Enemy_5")]
    // Determines how much the sine wave will affect movement
    public float sinEccentricity = 0.6f;
    public float lifeTime = 10;

    [Header("Set Dynamically: Enemy_5")]
    // Enemy_5 uses a Sin wave to modify a 2-point linear interpolation
    public Vector3 p0;
    public Vector3 p1;
    public float birthTime;

    private void Start()
    {
        // Pick any point on the left side of the screen
        p0 = Vector3.zero;
        p0.x = -bndCheck.camWidth - bndCheck.radius;
        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        // Pick any point on the right side of the screen
        p1 = Vector3.zero;
        p1.x = bndCheck.camWidth + bndCheck.radius;
        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        // Possibly swap sides
        if (Random.value > 0.5f)
        {
            // Setting the .x of each point to its negative will move it to
            // the other side of the screen
            p0.x *= -1;
            p1.x *= -1;
        }

        // Set the birthTime to the current time
        birthTime = Time.time;
    }

    public override void Move()
    {
        {
            //This Enemy_2 has finished its life
            //Destroy(this.gameObject, );
            //return;
        }
    }
}