using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script that controls world manipulation
 * 
 * World tiles are rendered in the world as follows:
 *  [ 0 ][ 1 ][ 2 ]
 * 
 * The player is always contained in the tile labeled [ 1 ].
 * The world is shuffled 
 */
public class WorldController : MonoBehaviour {

    public GameObject[] worldTiles;

    private ContactFilter2D filter;     // Filter for OverlapCollider

    // Use this for initialization
    void Start () {
        filter.NoFilter();
        setWorldTiles();
        Debug.Log("World Moved");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setWorldTiles()
    {
        worldTiles[0].transform.position = new Vector2(
            -worldTiles[1].GetComponent<BoxCollider2D>().bounds.size.x, 0);

        worldTiles[1].transform.position = new Vector2(
            0, 0);

        worldTiles[2].transform.position = new Vector2(
            worldTiles[1].GetComponent<BoxCollider2D>().bounds.size.x, 0);
    }

    public void shiftWorldRight()
    {
        // Move all objects contained in cell 0 to the right
        BoxCollider2D col = worldTiles[0].GetComponent<BoxCollider2D>();
        Collider2D[] objs = new Collider2D[128];
        Physics2D.OverlapBox(col.transform.position, col.bounds.extents * 2, 0, filter, objs);
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] == null)
                break;
            if (objs[i].tag == "Boundary" || objs[i].tag == "World")
                continue;
            objs[i].transform.position += new Vector3(col.bounds.size.x * 3, 0, 0);
        }

        // Move the tile itself
        worldTiles[0].transform.position += 
            new Vector3(col.bounds.size.x * 3, 0, 0);

        // Swap cell order
        GameObject tmp = worldTiles[0];
        Array.Copy(worldTiles, 1, worldTiles, 0,worldTiles.Length - 1);
        worldTiles[worldTiles.Length - 1] = tmp;
    }

    public void shiftWorldLeft()
    {
        // Move all objects contained in cell 2 to the left
        BoxCollider2D col = worldTiles[worldTiles.Length-1].GetComponent<BoxCollider2D>();
        Collider2D[] objs = new Collider2D[256];
        Physics2D.OverlapBox(col.transform.position, col.bounds.extents * 2, 0, filter, objs);
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] == null)
                break;
            if (objs[i].tag == "Boundary" || objs[i].tag == "World")
                continue;
            Debug.Log(objs[i].name);
            objs[i].transform.position -= new Vector3(col.bounds.size.x * 3, 0, 0);
        }

        worldTiles[2].transform.position -= new Vector3(col.bounds.size.x * 3, 0, 0);

        // Swap cell order 
        GameObject tmp = worldTiles[worldTiles.Length - 1];
        Array.Copy(worldTiles, 0, worldTiles, 1, worldTiles.Length - 1);
        worldTiles[0] = tmp;
    }
}
