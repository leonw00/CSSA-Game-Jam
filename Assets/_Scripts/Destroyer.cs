using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public Text txt;
    private int score = 0;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score++;
            Destroy(collision.gameObject);
        }
    }

    public void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Score: " + score;
    }

    public void Update()
    {
        txt.text = "Score: " + score;
    }

}
