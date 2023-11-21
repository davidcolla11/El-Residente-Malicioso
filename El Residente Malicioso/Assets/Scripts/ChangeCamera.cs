using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Transform player;
    public CinemachineVirtualCamera activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        activeCam.Priority = 0;
    }
}
