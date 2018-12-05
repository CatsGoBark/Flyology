using UnityEngine;
using System.Collections;

/*
 * The script that controls the main player's movement.
 */
public class PlayerController : MonoBehaviour
{
	public float speed;             // How fast the player can move
    public float maxVelocity;       // Maximum velocity for the player
    public float rotateSpeed;       // How fast the player can turn

    public float fireRate;          // How fast the player can shoot (in seconds. Lower is faster)

    public float boostRate;         // How often the player can boost (in seconds)
    public float boostAmount;       // How strong the boost is

    public GameObject bullet;
    public Transform bulletSpawn;
    public GameController gameController;
    public GameObject camera;

    private Rigidbody2D rb;         // Reference to RigidBody component
    private float nextFire;
    private float nextBoost;

    // Use this for initialization
    void Start()
    {
        // Stores the RigidBody component so we can easily access it
        rb = GetComponent<Rigidbody2D>();

        // Instantiate variables
        nextFire = 0;
        nextBoost = 0;
    }

    // Update is called once per frame
    void Update ()
	{
	}

    // FixedUpdate is called in fixed intervals. Put physics/movement code here
	void FixedUpdate ()
	{
        // Controls for rotating player
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-rotateSpeed);
        }

        // Controls for accellerating 
        if (Input.GetKey(KeyCode.W) && (
            rb.velocity.sqrMagnitude < maxVelocity || rb.velocity.y < 20))
        {
            // Only accellerate if the player is below maxVelocity or is falling
            rb.AddRelativeForce(Vector2.up * speed);
        }

        //  Controls for shooting 
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shot = (GameObject)Instantiate(bullet, bulletSpawn.position, rb.transform.rotation);
            shot.GetComponent<Rigidbody2D>().velocity += GetComponent<Rigidbody2D>().velocity;
        }

        // Boost Button
        if (Input.GetKey(KeyCode.LeftShift) && Time.time > nextBoost)
        {
            rb.AddRelativeForce(Vector2.up * boostAmount);
            nextBoost = Time.time + boostRate;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            gameController.playerHealth -= 10;
            Destroy(other.gameObject);
            camera.GetComponent<CameraController>().ShakeCamera(5.0f, 0.03f);
        }
    }
}
