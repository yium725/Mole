using Cinemachine;
using UnityEngine;

public class CameraControllerCinemachine : MonoBehaviour {

    public enum Axis {
        XZ,
        XY,
    }
    
    private CinemachineVirtualCamera m_Vcam;

    private void Start()
    {
        m_Vcam = GetComponent<CinemachineVirtualCamera>();
        
        m_Vcam.m_Lens.FieldOfView = 20;

        if (null != GameManager.Instance)
        {
            if (null != GameManager.Instance.Character)
            {
                m_Vcam.Follow = GameManager.Instance.Character.transform;
                m_Vcam.LookAt = GameManager.Instance.Character.transform;
            }
        }
    }

    private void Update() {

        float zoomSpeed = 20f;

        float scollValue = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (m_Vcam.m_Lens.FieldOfView <= 10.0f && scollValue < 0)
        {
            m_Vcam.m_Lens.FieldOfView = 10;
        }
        else if (m_Vcam.m_Lens.FieldOfView >= 40.0f && scollValue > 0)
        {
            m_Vcam.m_Lens.FieldOfView = 40;
        }
        else
        {
            m_Vcam.m_Lens.FieldOfView += scollValue;
        }
    }
}
