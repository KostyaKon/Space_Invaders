using UnityEngine;

public class LineController : MonoBehaviour
{
    public EnemyController[] enemies;
    private byte count = 0, maxCount;

    private void Start()
    {
        maxCount = (byte)enemies.Length;
    }

    void Update()
    {
        if (enemies[count] != null)
            enemies[count].isFront = true;
        else if(enemies[count] == null)
        {
            count++;
            if(count >= maxCount)
            {
                Destroy(gameObject);
            }
        }
    }
}
