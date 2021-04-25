using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool isPlayerLose;
    public static bool isPlayerWin;
    public static bool isPlayerDied;

    public static float playerScore;

    public byte livePlayer = 5;
    public GameObject Player;
    public Transform playerSpawn;

    public Text score;
    public Text live;

    public GameObject explosion;

    private GameObject player;
    private bool startPlayer;
    private bool isExplpsion;

    void Start()
    {
        isPlayerLose = false;
        isPlayerWin = false;
        isPlayerDied = false;
        isExplpsion = false;
        playerScore = 0;
        if (livePlayer > 0)
        {
            player = Instantiate(Player, playerSpawn.position, Quaternion.Euler(new Vector3(0, -180, 90)));
            startPlayer = true;
        }
        Time.timeScale = 1;
    }

    void Update()
    {
        if (isPlayerDied && !isExplpsion)
        {
            PlayerDead();
        }
        if(player == null && !isPlayerLose && startPlayer)
        {
            startPlayer = false;
            CollisionWithPlayer();
        }

        score.text = "Score: " + playerScore;
        live.text = "Live: " + livePlayer;
    }

    private void CollisionWithPlayer()
    {
        livePlayer--;
        if (livePlayer <= 0)
        {
            Invoke("StopTime", 1.1f);
        }
        else if(livePlayer > 0)
        {
            isPlayerDied = false;
            isExplpsion = false;
            StartCoroutine(InstPlayer());
        }
    }

    IEnumerator InstPlayer()
    {
        yield return new WaitForSeconds(1f);
        player = Instantiate(Player, playerSpawn.position, Quaternion.Euler(new Vector3(0, -180, 90)));
        startPlayer = true;
    }

    private void PlayerDead()
    {
        GameObject expl = Instantiate(explosion, player.transform.position, Quaternion.identity) as GameObject;
        isExplpsion = true;
        Destroy(player);
        Destroy(expl, 1f);
    }

    private void StopTime()
    {
        isPlayerLose = true;
        Time.timeScale = 0;
    }
}
