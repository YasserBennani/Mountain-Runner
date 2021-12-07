using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const int START_LEVELS_SPAWNED = 30;
    private const float PLAYER_DISTANCE_SPAWN_TRIGGER = 2000f;
    private Rigidbody2D player;
    private Vector3 lastEndPos;
    // Editable
    public List<Transform> LevelsList;


    private void Awake()
    {

        lastEndPos = LevelsList[0].Find("LevelEndPos").position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();


        for (int i = 0; i < START_LEVELS_SPAWNED; i++)
        {
            spawn();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, lastEndPos) < PLAYER_DISTANCE_SPAWN_TRIGGER)
        {
            // Generate level
            spawn();
        }
    }

    // function to generate levels
    private Transform spawnLevel(Transform level, Vector3 position, Vector3 gap)
    {
        return Instantiate(level, (position + gap), Quaternion.identity);
    }

    private Vector3 calculateGap()
    {
        return new Vector3(0, 0, 0);
    }

    private void spawn()
    {
        Transform randomLevel = LevelsList[Random.Range(0, LevelsList.Count)];
        Transform lastLvlTransform = spawnLevel(randomLevel, lastEndPos, new Vector3(10,0,0));
        lastEndPos = lastLvlTransform.Find("LevelEndPos").position;
    }

}
