using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour {
    public GameObject target;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Quaternion rotation = target.transform.rotation;
            transform.position = target.transform.position - (rotation * offset);
            transform.LookAt(target.transform);
        }
    }
}
