using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script : MonoBehaviour
{ 
    public TMP_Text scoreText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(score);
       
       scoreText.text = score.ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if circle collides with square called goal +1 to score but only once
        if (collision.gameObject.name == "Goal")
        {
            score++;
        }
        
    }
    
    
    
}
