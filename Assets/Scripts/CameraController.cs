using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script that makes the camera (or any object) follow the player
 */
public class CameraController : MonoBehaviour {

    public bool debugMode = false;      // Test-run/Call ShakeCamera() on start

    public float shakeAmount = 5;       // The amount to shake this frame.
    public float shakeDuration = 0.03f; // The duration this frame.

    //Readonly values...
    float shakePercentage;              // A percentage (0-1) representing the amount of shake to be applied when setting rotation.
    float startAmount;                  // The initial shake amount (to determine percentage), set when ShakeCamera is called.
    float startDuration;                // The initial shake duration, set when ShakeCamera is called.

    bool isRunning = false;             // Is the coroutine running right now?

    public GameObject player;           // Reference to the player game object
    private Vector3 offset;             // The offset distance between the player and camera

    // Use this for initialization
    void Start () {
        if (debugMode) ShakeCamera();

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    void ShakeCamera()
    {

        startAmount = shakeAmount;      // Set default (start) values
        startDuration = shakeDuration;  // Set default (start) values

        //if (!isRunning)
            StartCoroutine(Shake());    // Only call the coroutine if it isn't currently running.
    }

    public void ShakeCamera(float amount, float duration)
    {

        shakeAmount += amount;          // Add to the current amount.
        startAmount = shakeAmount;      // Reset the start amount, to determine percentage.
        shakeDuration += duration;      // Add to the current time.
        startDuration = shakeDuration;  // Reset the start time.

        if (!isRunning)
            StartCoroutine(Shake());    //Only call the coroutine if it isn't currently running.
    }


    IEnumerator Shake()
    {
        isRunning = true;

        while (shakeDuration > 0.01f)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount; //A Vector3 to add to the Local Rotation
            rotationAmount.x = 0;           // Don't rotate these because it's a 2D game
            rotationAmount.y = 0;

            //Used to set the amount of shake (% * startAmount).
            shakePercentage = shakeDuration / startDuration;
            //Set the amount of shake (% * startAmount).
            shakeAmount = startAmount * shakePercentage;
            //Lerp the time, so it is less and tapers off towards the end.
            shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);

            transform.localRotation = Quaternion.Euler(rotationAmount);

            yield return null;
        }
        transform.localRotation = Quaternion.identity;//Set the local rotation to 0 when done, just to get rid of any fudging stuff.
        isRunning = false;
    }
}
