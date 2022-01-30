using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryScript : MonoBehaviour
{
		public GameObject screen1;
		public GameObject screen2;
		public GameObject screen3;
		public GameObject EndButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Call());
    }

    IEnumerator Call()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
