using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBoundaryObjects : MonoBehaviour {

    public WorldController worldController;

    private ContactFilter2D filter;

    // Use this for initialization
    void Start ()
    {
        filter.NoFilter();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        // Right boundary
        if (other.transform.position.x > transform.position.x)
        {
            Debug.Log("Right boundary");
            worldController.shiftWorldRight();
        }
        // Left boundary
        else
        {
            Debug.Log("Left boundary");
            worldController.shiftWorldLeft();
        }
    }
}
