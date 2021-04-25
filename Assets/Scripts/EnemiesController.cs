using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private Transform enemies;
    private bool lastEnemi;

    public float enemySpeed, enimiesSpeed = 0.3f;

    void Start()
    {
        enemies = GetComponent<Transform>();
        lastEnemi = false;
        InvokeRepeating("MoveEnemies", 0.1f, enimiesSpeed);
    }

    void MoveEnemies()
    {
        enemies.position += Vector3.right * enemySpeed;
        foreach (Transform enemyL in enemies)
        {
            foreach (Transform enemy in enemyL)
            {
                if (enemy.position.x < -6 || enemy.position.x > 6)
                {
                    enemySpeed = -enemySpeed;
                    enemies.position += Vector3.down * 0.5f;
                    return;
                }
                if (enemy.position.y <= -2)
                {
                    GameController.isPlayerLose = true;
                    Time.timeScale = 0;
                }
            }
        }
        if (enemies.childCount == 1 && !lastEnemi)
        {
            if (enemies.GetChild(0).childCount == 1)
            {
                lastEnemi = true;
                enimiesSpeed -= 0.15f;
                enemySpeed *= 2f;
                CancelInvoke();
                InvokeRepeating("MoveEnemies", 0.1f, enimiesSpeed);
            }
        }
        if (enemies.childCount == 0)
        {
            GameController.isPlayerWin = true;
        }
    }
}
