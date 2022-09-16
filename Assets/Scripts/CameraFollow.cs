using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField] float camY;

    private void Update()
    {
        Vector3 back = -player.transform.forward;
        back.y = camY;
        transform.position = player.transform.position - back * -10;
        transform.forward = player.transform.position - transform.position;
    }
}
