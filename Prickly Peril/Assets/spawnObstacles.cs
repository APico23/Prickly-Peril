using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    
    public GameObject rock;

    //Time it takes to spawn rock
    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;

    // the range of X
    //[Header("X Spawn Range")]
    /**public*/ float xMin;
    /**public*/ float xMax;
    

    // the range of y
    //[Header("Y Spawn Range")]
    /**public*/ float yMin;
    /**public*/ float yMax;
    public GameObject tracked;
   
    public void Update()
    {
        // timer to spawn the next rock Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            spawnRock();
            theCountdown = waitingForNextSpawn;
        }
        yMin = tracked.transform.position.y + 25;
        yMax = yMin;
        xMin = tracked.transform.position.x - 25;
        xMax = tracked.transform.position.x + 25;

    }


    void spawnRock()
    {
        // Defines the min and max ranges for x and y
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        // Creates the random object at the random 2D position.
        Instantiate(rock, pos, transform.rotation);

        // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
        //GameObject newRock = (GameObject)Instantiate(rock, pos)
        //rock.something = somethingelse;
    }
}

