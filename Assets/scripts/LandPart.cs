using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandPart : MonoBehaviour
{
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, new Vector3(14.4f, transform.position.y, transform.position.z));
    }
}
