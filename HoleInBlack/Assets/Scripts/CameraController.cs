using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    void Update()
    {

        if(targetToFollow!=null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(targetToFollow.position.x, -5f,5f),
                10.0f,
                Mathf.Clamp(targetToFollow.position.z, 6f, 6f)
                );
        }
        else{
        }
    } 
}
