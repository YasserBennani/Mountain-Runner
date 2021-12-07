using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGenerator : MonoBehaviour
{
    // how many background objects to spawn at first
    private const int START_BGs_SPAWNED = 20;
    private const float PLAYER_DISTANCE_SPAWN_TRIGGER = 500f;
    // references to the Player GameObject
    private GameObject pl;
    private Rigidbody2D player;
    // references to background
    private Vector3 bgEndPos;
    public Transform BG;
    private GameObject bgObj;
    //
    private BoxCollider2D bg_collider;
    //
    private RunnerController controller;
    private void Awake()
    {
        bgEndPos = BG.Find("BGEndPos").position;
        pl = GameObject.FindGameObjectWithTag("Player");
        player = pl.GetComponent<Rigidbody2D>();
        bg_collider = GameObject.FindGameObjectWithTag("BG").GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, bgEndPos) < PLAYER_DISTANCE_SPAWN_TRIGGER)
        {
            // Generate BG
            spawn();
        }
    }

    private Transform spawnBG(Transform bg, Vector3 position)
    {
        return Instantiate(bg, (position + new Vector3(0, 0, 0)), Quaternion.identity);
    }
    private void spawn()
    {
        Transform bg = BG;
        Transform LastBgTransform = spawnBG(bg, bgEndPos);
        bgEndPos = LastBgTransform.Find("BGEndPos").position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        controller = pl.GetComponent<RunnerController>();
        controller.isDead = true;
        Debug.Log("Collision happened");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}