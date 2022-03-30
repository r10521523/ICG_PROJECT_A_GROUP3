using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEntity : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_Renderders = new SpriteRenderer[3];
    private int wheel_count = 0;
    static public bool parking_success = false;
    void Update()
    {
        if (wheel_count == 4 && EntranceEntity.leave)
        {
            parking_success = true;
            foreach (SpriteRenderer r in m_Renderders)
            {
                r.color = Color.green;
            }
        }
        else if (wheel_count >= 1)
        {
            parking_success = false;
            foreach (SpriteRenderer r in m_Renderders)
            {
                r.color = Color.white;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "wheel")
        {
            wheel_count++;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "wheel")
        {
            wheel_count--;
        }
    }
}
