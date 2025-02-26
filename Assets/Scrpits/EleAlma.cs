using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleAlma : MonoBehaviour
{
    public Transform holdPosition; // El pozisyonu (Nesnenin tutulduðu nokta)
    private GameObject heldObject;
    public float pickupRange = 2f;
    public Transform playerCamera;

    void Update()
    {
        holdPosition.position = 
            playerCamera.position + 
            playerCamera.forward * 0.5f + 
            playerCamera.right * 0.3f + 
            playerCamera.up * -0.2f;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
                Al();
            else
                Birak();
        }

        if (heldObject != null)
        {
            heldObject.transform.position = holdPosition.position;
            heldObject.transform.rotation = playerCamera.rotation;
        }
    }
    void Al()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Collectable"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition;
            }
        }
    }
    void Birak()
    {
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}