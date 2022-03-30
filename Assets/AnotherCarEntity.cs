using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCarEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;
    float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 40f;
    public float turnAngularVelocity = 20f;
    float m_Velocity = 0;
    public float Velocity { get { return m_Velocity; } }
    public float accerlation = 3f;
    public float deceleration = 10f;
    public float maxVelocity = 60f;
    public float carLength = 1f;
    float m_DeltaMovement;

    //SpriteRenderer m_TargetRenderer;

    [SerializeField] SpriteRenderer[] m_Renderders = new SpriteRenderer[5];
    Color origin = new Color();
    void Start()
    {
        origin = m_Renderders[0].color;

    }

    void UpdateWheels()
    {
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFrontLeft.transform.localEulerAngles = localEulerAngles;
        wheelFrontRight.transform.localEulerAngles = localEulerAngles;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Velocity = Mathf.Min(maxVelocity, m_Velocity + Time.fixedDeltaTime * accerlation);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Velocity = Mathf.Max((float)(-maxVelocity * 0.5), m_Velocity - Time.fixedDeltaTime * deceleration);
        }
        if (Input.GetKey(KeyCode.K))
        {
            m_Velocity = Mathf.Max(0, m_Velocity - Time.fixedDeltaTime * deceleration);
        }
        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            m_FrontWheelAngle = Mathf.Clamp(m_FrontWheelAngle + Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheels();
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_FrontWheelAngle = Mathf.Clamp(m_FrontWheelAngle - Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheels();
        }
        this.transform.Rotate(0f, 0f, 1 / carLength * Mathf.Tan(Mathf.Deg2Rad * m_FrontWheelAngle) * m_DeltaMovement * Mathf.Rad2Deg);
        this.transform.Translate(Vector3.right * m_DeltaMovement);
    }
    void ResetColor()
    {
        ChangeColor(origin);
    }
    void ChangeColor(Color color)
    {
        foreach (SpriteRenderer r in m_Renderders)
        {
            r.color = color;
        }
    }
    private void Stop()
    {
        m_Velocity = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*m_TargetRenderer = this.GetComponent<SpriteRenderer>();
        origin = m_TargetRenderer.color;*/
        Stop();
        ChangeColor(Color.red);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Stop();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ResetColor();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
        if (checkPoint != null)
        {
            ChangeColor(Color.green);

            this.Invoke("ResetColor", 1f);
        }
    }
}