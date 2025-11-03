using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (true)
        {
            Debug.Log(Time.frameCount);
            yield return 1;
        }
    }
}
