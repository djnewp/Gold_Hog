using UnityEditor;
using UnityEngine;

public class SP : MonoBehaviour
{
#if unity_editor
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, "SP");
    }
#endif
}
