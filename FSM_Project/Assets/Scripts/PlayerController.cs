using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private Vector3 m_Movement;
    [SerializeField] private float m_Speed;

    // Start is called before the first frame update
    private void Start()
    {
        m_RB = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCharacter(m_Movement);
    }

    // Update is called once per frame
    private void Update()
    {
        m_Movement.x = Input.GetAxis("Horizontal");
        m_Movement.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //m_Movement = ((Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical"))).normalized;
        }       
    }

    private void MoveCharacter(Vector3 direction)
    {
        m_RB.MovePosition(transform.position + (direction * m_Speed * Time.deltaTime));
    }
}
