using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private Vector3 m_Movement;
    [SerializeField] private float m_Speed;

    [SerializeField] private Detector m_Detector;
    private StateMachine m_StateMachine;

    // Start is called before the first frame update
    private void Start()
    {
        m_Detector.ParentTag = this.tag;
        m_RB = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCharacter(m_Movement);
    }

    // Update is called once per frame
    private void Update()
    {
        //m_Movement.x = Input.GetAxis("Horizontal");
        //m_Movement.z = Input.GetAxis("Vertical");
        m_Movement = ((Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"))).normalized;
        
        if(m_Detector.Target)
        {
            Debug.Log("See " + m_Detector.Target.name);
        }
    }

    private void MoveCharacter(Vector3 direction)
    {
        m_RB.MovePosition(transform.position + (direction * m_Speed * Time.deltaTime));
    }
}
