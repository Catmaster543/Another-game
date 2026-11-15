using UnityEngine;

public class PlayerSpawnIHope : MonoBehaviour
{
    public Transform PlayerSpawn;

    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.transform.position = PlayerSpawn.position;
        player.transform.rotation = PlayerSpawn.rotation;
    }
}

//bru I have no clue what am doing
//Am just a bad AI = Taking stuff that i joink from ya and rebashing it xd
