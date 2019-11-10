using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float moveSpeed; 


    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
    }
}
