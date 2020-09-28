using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShakeTransform st = transform.parent.GetComponent<ShakeTransform>();
        st.Begin();
    }
}
