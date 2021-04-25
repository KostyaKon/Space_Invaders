using UnityEngine;

public class WallLive : MonoBehaviour
{
    public float health = 3;
 
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
