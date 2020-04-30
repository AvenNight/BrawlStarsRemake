using System.Collections;
using UnityEngine;

//public abstract class SpawFactory : MonoBehaviour
//{
//    public abstract Creature Spawn();
//}

//public class PlayerSpawFactory : SpawFactory
//{
//    [SerializeField] private Player player;

//    public override Creature Spawn()
//    {
//        throw new System.NotImplementedException();
//    }
//}

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyWithAI enemy;
    private CreatureFinder playerFinder;
    private bool playerCreating;

    private void Start()
    {
        //playerFinder = new CreatureFinder(this.gameObject, "Player");
        InvokeRepeating("Check", 0, 1);
    }

    private void Check()
    {
        playerFinder = new CreatureFinder(this.gameObject, "Player");
        if (playerFinder.Objects.Count == 0 && !playerCreating)
            StartCoroutine("RespawnPlayer");
    }

    private IEnumerator RespawnPlayer()
    {
        playerCreating = true;
        yield return new WaitForSeconds(3);
        //Instantiate(player, new Vector3(-9.9f, 0, 9.9f), Quaternion.identity);
        if (new CreatureFinder(this.gameObject, "Player").Objects.Count == 0)
            Instantiate(player, player.transform.position, Quaternion.identity);
        //player.transform.SetParent(mapObj.Parrent.transform, true);
        playerCreating = false;
    }
}
