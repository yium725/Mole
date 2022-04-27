using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator m_Animator;
    private int m_AnimSpeedParamID;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AnimSpeedParamID = Animator.StringToHash("Speed");
    }

    public void Run(float speed)
    {
        m_Animator.SetFloat(m_AnimSpeedParamID, speed);
    }

    public void Walk()
    {

    }

    public void Attack()
    {

    }
}
