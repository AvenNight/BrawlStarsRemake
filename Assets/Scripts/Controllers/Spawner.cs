using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private EnemyWithAI enemyPrefab;
    private Player curPlayer;

    private void Start()
    {
        curPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curPlayer.DeathNotify += () => StartCoroutine("RespawnPlayer");
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(3);
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            curPlayer = Instantiate(playerPrefab, playerPrefab.transform.position, Quaternion.identity);
            curPlayer.DeathNotify += () => StartCoroutine("RespawnPlayer");
        }
    }
}