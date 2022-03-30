using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer m_TargetRenderer;
    Color origin = new Color();
    void Start()
    {
        m_TargetRenderer = this.GetComponent<SpriteRenderer>();
        origin = m_TargetRenderer.color;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        m_TargetRenderer.color = Color.red;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        m_TargetRenderer.color = origin;
    }
    // Update is called once per frame
    
}
