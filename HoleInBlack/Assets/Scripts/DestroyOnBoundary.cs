using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Enemy" && other.tag !="Player")
        Destroy(other.gameObject);
    }
}
