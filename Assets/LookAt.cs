using System;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = transform.parent;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        directionToCamera.x = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = targetRotation;
        transform.position = _target.transform.position;
    }
}