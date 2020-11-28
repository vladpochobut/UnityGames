using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private Transform equipPosition;
    private GameObject currentWeapon;

    bool somesingInHands = false;
    bool canGrab;

    private void Update()
    {
        if (canGrab )
        {
            PickUpWeapon();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CanGrab")
        {
            if (somesingInHands == true)
            {
                Destroy(currentWeapon);
                somesingInHands = false;
            }
            other.GetComponent<BoxCollider>().enabled = false;
            currentWeapon = other.transform.gameObject;
            canGrab = true;
        }
        else
            canGrab = false;
    }

    private void PickUpWeapon()
    {
        canGrab = false;
        somesingInHands = true;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;  
    }

}
