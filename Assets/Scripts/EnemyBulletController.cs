using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public byte health = 1;

    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.down * speed;
        if (bullet.position.y <= -5)
            Destroy(gameObject);
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.isPlayerDied = true;
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            WallLive wl = other.gameObject.GetComponent<WallLive>();
            wl.health -= 1;
            Destroy(gameObject);
        }
    }
}
