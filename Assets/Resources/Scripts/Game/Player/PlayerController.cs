using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent m_navMeshAgent;
    private PlayerAnim m_PlayerAnim;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_PlayerAnim = GetComponent<PlayerAnim>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Test Orders
        if (Input.GetMouseButtonDown(1))
        {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    m_navMeshAgent.SetDestination(hit.point);
                    m_navMeshAgent.stoppingDistance = 0.1f;
                    m_navMeshAgent.isStopped = false;
                }
        }
        m_PlayerAnim.Run(m_navMeshAgent.velocity.magnitude / m_navMeshAgent.speed);
    }
}
