using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private GameObject m_Target;

    public GameObject Target
    {
        get
        {
            return m_Target;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_Target = null;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            m_Target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == m_Target)
        {
            m_Target = null;
        }
    }
}
