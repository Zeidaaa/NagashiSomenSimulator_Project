using UnityEngine;

public class LeftControl : MonoBehaviour
{
    private GameObject m_grabbedObj;

    private void Start()
    {
        m_grabbedObj = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_grabbedObj = collision.gameObject;
    }

    public GameObject GetGrabbedObj()
    {
        return m_grabbedObj;
    }
}
