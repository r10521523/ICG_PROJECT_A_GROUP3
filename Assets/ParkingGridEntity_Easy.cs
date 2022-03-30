using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingGridEntity_Easy : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_Renderders = new SpriteRenderer[3];
    private int wheel_count = 0;
    private bool once = true;

    void Update()
    {
        if (wheel_count == 4 && EntranceEntity.leave)
        {
            if (once)
            {
                Debug.Log("Congratulation! You complete the game!");
                Debug.Log("Your final point now is " + PointEntity.point + "!!!");
                ParkingGameScene.Instance.Invoke("GameComplete", 2f);
                foreach (SpriteRenderer r in m_Renderders)
                {
                    r.color = Color.yellow;
                }
                once = false;
            }
            
        }
        else if (wheel_count >= 1)
        {
            foreach (SpriteRenderer r in m_Renderders)
            {
                r.color = Color.white;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (ParkingGameScene.isEasy)
        {
            if (coll.tag == "wheel")
            {
                wheel_count++;
            }
        }
        else
        {
            Debug.Log("Hey! You should park in the corresponding parking grid. Not this one.");
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (ParkingGameScene.isEasy)
        {
            if (coll.tag == "wheel")
            {
                wheel_count--;
            }
        }
    }
}
