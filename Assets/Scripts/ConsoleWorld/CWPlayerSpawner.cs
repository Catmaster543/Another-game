using UnityEngine;

public class CWPlayerSpawner : MonoBehaviour
{
    public Transform originPlayerSpawn;

    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.transform.position = originPlayerSpawn.position;
        player.transform.rotation = originPlayerSpawn.rotation;
    }
}