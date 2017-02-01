using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : Overlap_Generic {

    public static bool repaired = false;

	void Update()
    {
        if (overlap)
        {
            repaired = true;
        }
    }
}
