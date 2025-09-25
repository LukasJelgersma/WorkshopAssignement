using System;
using UnityEngine;
using UnityEngine.Events;

public class PickupScript : MonoBehaviour
{
    
    // Unity event
    public UnityEvent onPickup;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate like a pickup
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            onPickup.Invoke();
        }
    }
}
