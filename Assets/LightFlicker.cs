using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {
    public static bool dark = false;
    float switchtime = 3.0f;
	
	
	// Update is called once per frame
	void Update () {
        if (switchtime < 0)
        {
            StartCoroutine("FlickerOff");
            StartCoroutine("FlickerOn");
            switchtime = 3.0f;
            Debug.Log(dark);
        }
        switchtime -= Time.deltaTime;
	}

    IEnumerator FlickerOff()
    {
        if (!dark)
        {
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            dark = true;
        }

    }
    IEnumerator FlickerOn()
    {
        if (dark)
        {
            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.2f);

            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            dark = false;
        }
    }
}
