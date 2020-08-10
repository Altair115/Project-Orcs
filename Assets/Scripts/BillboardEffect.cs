using UnityEngine;
using System.Collections;

public class BillboardEffect : MonoBehaviour
{
    public Camera m_Camera;
    public bool autoInit = false;

    void Awake()
    {
        if (autoInit == true)
            m_Camera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
    }
}