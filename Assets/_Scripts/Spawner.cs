using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public double startCooldown = 2;
    public int leftBoundary = -7;
    public int rightBoundary = 8;
    private double cooldown;

    public GameObject obstacle;

    private void Start()
    {
        cooldown = startCooldown;
    }

    private void Update()
    {
        if(cooldown < 0)
        {
            Instantiate(obstacle, new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y, transform.position.z), Quaternion.identity);
            cooldown = startCooldown;
            startCooldown -= 0.02;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

}
