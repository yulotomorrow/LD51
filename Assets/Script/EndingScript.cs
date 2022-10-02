using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(EndScript());
    }


    IEnumerator EndScript() 
    {
        yield return new WaitForSecondsRealtime(2.5f);
    }
}
