using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleAlma : MonoBehaviour
{
    public float mesafe;
    public GameObject El_Feneri;

    private void Update()
    {
        Vector3 ileri = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, ileri, out hit, mesafe))
        {
            if (hit.distance <= mesafe && hit.collider.gameObject.tag == "Fener")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    El_Feneri.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
