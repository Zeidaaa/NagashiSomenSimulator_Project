using UnityEngine;

public class RightControl : MonoBehaviour
{
    private GameObject m_grabbedObj;

    private void OnCollisionEnter(Collision collision)
    {
        m_grabbedObj = collision.gameObject;
    }

    public GameObject GetGrabbedObj()
    {
        return m_grabbedObj;
    }
}
