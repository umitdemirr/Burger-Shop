using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fener : MonoBehaviour
{
    public Light isik;
    public bool acik;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            acik = !acik;
        }

        if (acik)
        {
            isik.enabled = true;
        }
        else { isik.enabled = false; }
    }
}
