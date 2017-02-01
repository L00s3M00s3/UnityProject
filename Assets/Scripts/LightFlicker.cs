using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {
    public static bool dark = false;
    public static bool fade = false;
    float switchtime = 3.0f;
	
	
	// Update is called once per frame
	void Update () {
        if (!FuseBox.repaired)
        {
            if (switchtime < 0)
            {
                StartCoroutine("FlickerOff");
                StartCoroutine("FlickerOn");
                switchtime = 3.0f;

            }
            switchtime -= Time.deltaTime;
        }
        else
        {
            GetComponent<Light>().enabled = true;
            dark = false;
            fade = false;
        }
	}

    IEnumerator FlickerOff()
    {
        if (!dark)
        {
            fade = true;
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
            fade = false;
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
