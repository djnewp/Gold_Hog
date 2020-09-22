using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandPart : MonoBehaviour
{
    private const float HEIGHT = 3.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 pos1 = transform.position;
        Vector3 pos2 = new Vector3(pos1.x + Common.LAND_PART_WIDTH, transform.position.y, transform.position.z);
        Gizmos.DrawLine(pos1 + new Vector3(0, HEIGHT, 0), pos2 + new Vector3(0, HEIGHT, 0));
        Gizmos.DrawLine(pos1 + new Vector3(0, -HEIGHT, 0), pos2 + new Vector3(0, -HEIGHT, 0));

        Gizmos.DrawLine(pos1 + new Vector3(0, HEIGHT, 0), pos1 + new Vector3(0, -HEIGHT, 0));
        Gizmos.DrawLine(pos2 + new Vector3(0, HEIGHT, 0), pos2 + new Vector3(0, -HEIGHT, 0));
    }
}
