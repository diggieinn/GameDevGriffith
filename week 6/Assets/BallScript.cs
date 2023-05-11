using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider sliderSize;
    public Slider slizerPosition;
    public int score = 0;
    public TMP_Text text;

    public float sliderValue;
    public float sliderValueFloat;

    public GameObject boxChecker1;
    public GameObject boxChecker2;
    public GameObject boxChecker3;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
        
        sliderValueFloat = sliderSize.value;
        transform.localScale = new Vector3(sliderValueFloat, sliderValueFloat, sliderValueFloat);
        

     text.text = "Score: " + score;
    }

   public void positionSlider()
    {
        sliderValue = slizerPosition.value;
        //change only x position according to slider
        transform.position = new Vector3(sliderValue, 3.6f, 0);
    }
    
    public void turnGravityOnClickOfButton()
    {
       float gravity = GetComponent<Rigidbody2D>().gravityScale = 1;
       GetComponent<Rigidbody2D>().gravityScale = 1;
       Debug.Log("Gravity is " + gravity);
    }
    //if ball collides with Goal then score increases
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            score++;
            Debug.Log("Score is " + score);
        }
    }
  
    


 
}
