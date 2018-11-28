using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTileEdgeTrigger : MonoBehaviour {

    public WorldController worldController;

    private ContactFilter2D filter;
    private Collider2D col;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        filter.NoFilter();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Middle tile detection (Shift world)
        if (this.gameObject == worldController.worldTiles[1])
        {
            // Ignore everything that isn't the player
            if (other.tag != "Player")
                return;

            // Right boundary
            if (other.transform.position.x > transform.position.x)
                worldController.shiftWorldRight();
            // Left boundary
            else
                worldController.shiftWorldLeft();
        }

        // Left tile detection (Teleport objects to the right)
        else if (this.gameObject == worldController.worldTiles[0])
        {
            // Ignore right boundary triggers
            if (other.transform.position.x > transform.position.x)
                return;

            // Teleport object to the other side
            other.transform.SetPositionAndRotation(
                other.transform.position + new Vector3(col.bounds.extents.x * 6, 0, 0), 
                other.transform.rotation);
        }

        // Right tile detection (Teleport objects to the left)
        else if (this.gameObject == worldController.worldTiles[2])
        {
            // Ignore left boundary triggers
            if (other.transform.position.x < transform.position.x)
                return;

            // Teleport object to the other side
            other.transform.SetPositionAndRotation(
                other.transform.position - new Vector3(col.bounds.extents.x * 6, 0, 0),
                other.transform.rotation);
        }
    }
}
