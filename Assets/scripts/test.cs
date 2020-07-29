using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(testco());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator testco()
    {

        Debug.Log("testco" + Time.time);
        yield return null;

        Debug.Log("testco" + Time.time);
        yield return new WaitForSeconds(1.0f);

        Debug.Log("testco" + Time.time);
        yield return new WaitForSeconds(5.0f);

        Debug.Log("testco" + Time.time);

    }
}
