using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;
        if (bullet.position.y >= 8)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController ec = other.gameObject.GetComponent<EnemyController>();
            ec.health--;
            Destroy(gameObject);
        }
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
            Destroy(gameObject);
    }
}
