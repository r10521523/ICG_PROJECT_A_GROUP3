using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEntity : MonoBehaviour
{
    // Start is called before the first frame update
    static public int point = 100;
    public Text ScoreText;
    
    bool once = true;
    bool choose = true;
    

    // Update is called once per frame
   
    
    void Update()
    {
        if (choose)
        {
            if (ParkingGameScene.isEasy)
            {
                ScoreText.text = "Score: " + point;
            }
            if (ParkingGameScene.isNormal)
            {
                point = 120;
                choose = false;
                ScoreText.text = "Score: " + point;
            }
            if (ParkingGameScene.isHard)
            {
                point = 150;
                choose = false;
                ScoreText.text = "Score: " + point;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        point -= 10;
        ScoreText.text = "Score: " + point;
        if (point == 0)
        {
            ScoreText.text = "Score: " + point;
            Debug.Log("Try again!");
            ParkingGameScene.Instance.GameOver();
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
        if (checkPoint != null)
        {
            point += 10;
            ScoreText.text = "Score: " + point;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        BoxEntity boxEntity = other.gameObject.GetComponent<BoxEntity>();
        if (boxEntity != null && BoxEntity.parking_success)
        {
            if (once)
            {
                point += 50;
                ScoreText.text = "Score: " + point;
                once = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        BoxEntity boxEntity = other.gameObject.GetComponent<BoxEntity>();
        if (boxEntity != null)
        {
            once = true;
        }
    }
}
