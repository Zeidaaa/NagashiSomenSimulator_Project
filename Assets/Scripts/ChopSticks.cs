using UnityEditor.PackageManager;
using UnityEngine;

public class ChopSticks : MonoBehaviour
{
    private Vector3 m_mousePos;
    private Vector3 m_initPos;
    private Vector3 m_shiftPos;

    private GameObject m_leftStick;
    private GameObject m_rightStick;
    private GameObject m_grabbedObj;

    private float m_newPosY;
    private float m_stickTilt;
    private float m_lerpSpeed;
    private float m_upDownSpeed;


    private bool m_isLeftTilt;
    private bool m_isRightTilt;

    void Start()
    {
        m_initPos = transform.position;
        m_newPosY = m_initPos.y;

        m_shiftPos = new Vector3(-1.0f, -1.0f, 0.0f);

        m_leftStick = transform.GetChild(0).gameObject;
        m_rightStick = transform.GetChild(1).gameObject;

        m_stickTilt = 12.0f * (Mathf.PI / 180);
        m_lerpSpeed = 0.02f;
        m_upDownSpeed = 1.0f;

        m_isLeftTilt = false;
        m_isRightTilt = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_newPosY += m_upDownSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_newPosY -= m_upDownSpeed * Time.deltaTime;
        }

        // ç∂ÇÃî¢íÕÇ›
        if (Input.GetMouseButton(0))
        {
            var newLeftRot = new Quaternion(m_stickTilt, 0.0f, 0.0f, 1.0f);
            var newRightRot = new Quaternion(-m_stickTilt, 0.0f, 0.0f, 1.0f);
            m_leftStick.transform.rotation = Quaternion.Slerp(m_leftStick.transform.rotation, newLeftRot, m_lerpSpeed);
            m_rightStick.transform.rotation = Quaternion.Slerp(m_rightStick.transform.rotation, newRightRot, m_lerpSpeed);
        }
        
        // âEÇÃî¢íÕÇ›
        if (Input.GetMouseButton(1))
        {
            var newLeftRot = new Quaternion(-m_stickTilt, 0.0f, 0.0f, 1.0f);
            var newRightRot = new Quaternion(m_stickTilt, 0.0f, 0.0f, 1.0f);
            m_leftStick.transform.rotation = Quaternion.Slerp(m_leftStick.transform.rotation, newLeftRot, m_lerpSpeed);
            m_rightStick.transform.rotation = Quaternion.Slerp(m_rightStick.transform.rotation, newRightRot, m_lerpSpeed);
        }
        
        // î¢ÇÃà⁄ìÆ
        m_mousePos = Input.mousePosition;
        var mousePosToWorld = Camera.main.ScreenToWorldPoint(new Vector3(m_mousePos.x, m_mousePos.y, 7.0f));
        transform.position = new Vector3(mousePosToWorld.x, m_newPosY, mousePosToWorld.z);
        


        if (m_isLeftTilt && m_isRightTilt)
        {
            if (m_grabbedObj != null)
            {
                //m_grabbedObj.transform.position = transform.position + m_shiftPos; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_grabbedObj = other.gameObject;
    }
}
