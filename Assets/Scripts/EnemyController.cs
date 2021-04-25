using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletEnemy;
    public Transform bulletSpawn;
    public byte health = 1;
    public float score = 10;
    public bool isSuperEnemy;
    public Color color;
    public GameObject[] enemyParts;

    public bool isFront;
    private bool isStartFire = false;

    private int timeCharge;

    void Start()
    {
        if (isSuperEnemy)
        {
            ChangeColor(color);
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            GameController.playerScore += score;
            Destroy(gameObject);
        }
        if (isFront && !isStartFire)
        {
            StartCoroutine(FireEnemy());
            isStartFire = true;
        }
    }

    IEnumerator FireEnemy()
    {
        while (true)
        {
            timeCharge = Random.Range(3, 10);
            yield return new WaitForSeconds(timeCharge);
            Instantiate(bulletEnemy, bulletSpawn.position, Quaternion.identity);
        }
    }

    void ChangeColor(Color color)
    {
        Color newColor = color;
        foreach (var item in enemyParts)
        {
            item.GetComponent<MeshRenderer>().material.color = newColor;
        }
    }
}
