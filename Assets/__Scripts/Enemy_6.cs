using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy_1 extends the Enemy class
public class Enemy_6 : Enemy {

    [Header("Set in Inspector: Enemy_1")]
    // # seconds for a full sine wave
    public float waveFrequency = 2;
    // sine wave width in meters
    public float waveWidth = 4;
    public float waveRotY = 45;

    private float x0; // The initial x value of pos
    private float birthTime;

    public GameObject[] prefabEnemies; // Array of Enemy prefabs

	// Use this for initialization
	void Start()
    {
        // Set x0 to the initial x position of Enemy_1
        x0 = pos.x;

        birthTime = Time.time;
    }

    // Override the Move function on Enemy
    public override void Move()
    {
        Vector3 tempPos = pos;

        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        //rotate a bit about y
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        // base.Move() still handles the movement down in y
        base.Move();

        // print (bndCheck.isOnScreen);
    }

    // Update is called once per frame
    private void Destruction(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
            case "ProjectileHero":
                if(health <= 0) 
                {
                    // Pick a random Enemy prefab to instantiate
                    int ndx = Random.Range(0, prefabEnemies.Length);
                    GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

                    Vector3 pos = Vector3.zero;
                    float xMin = -bndCheck.camWidth;
                    float xMax = bndCheck.camWidth;
                    pos.x = Random.Range(xMin, xMax);
                    pos.y = bndCheck.camHeight;
                    go.transform.position = pos;
                }
            break;

            default:
                break;
        }
    }
}
