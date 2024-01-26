using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class VictoryScene : MonoBehaviour
{
    CinemachineTrackedDolly dolly;
    [SerializeField] CinemachineVirtualCamera timelineCam;

    // Start is called before the first frame update
    void Start()
    {
        dolly = timelineCam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dolly.m_PathPosition == 5)
        {
            timelineCam.enabled = false;
        }
    }
}
