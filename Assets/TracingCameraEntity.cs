using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCameraEntity : MonoBehaviour
{
    public CarEntity targetObject;
    public float MOVING_THRESHOLD = 5f;
    bool start = false;

    Camera m_Camera;
    float m_OrthographicSize;

    // Update is called once per frame
    void LateUpdate()
    {
        targetObject = ParkingGameScene.Follow;

        if (targetObject != null)
        {
            if (!start)
            {
                m_Camera = this.GetComponent<Camera>();
                m_OrthographicSize = m_Camera.orthographicSize;
                start = true;
            }
            
            Vector2 deltaPos = this.transform.position - targetObject.transform.position;

            if (deltaPos.magnitude > MOVING_THRESHOLD)
            {
                deltaPos.Normalize();
                Vector2 newPosition = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y)
                    + deltaPos * MOVING_THRESHOLD;

                this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
            }

            m_Camera.orthographicSize = m_OrthographicSize + targetObject.Velocity * 0.2f;
        }
    }
}
