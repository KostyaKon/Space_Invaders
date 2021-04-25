using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private float moveH, fire;

    public float speed, maxBound, minBound;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float timeCharge;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal");
        if (moveH < 0)
            MoveLeft();
        else if (moveH > 0)
            MoveRight();
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > fire)
        {
            fire = Time.time + timeCharge;
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        }
    }

    public void MoveLeft()
    {
        if (playerTransform.position.x > minBound)
            playerTransform.position += Vector3.left * speed;
    }

    public void MoveRight()
    {
        if (playerTransform.position.x < maxBound)
            playerTransform.position += Vector3.right * speed;
    }
}
