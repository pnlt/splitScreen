using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform mark;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, mark.position, 0.75f * Time.deltaTime);
    }
}

