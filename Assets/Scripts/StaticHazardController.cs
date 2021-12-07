using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticHazardController : MonoBehaviour
{
    private GameObject pl;
    private BoxCollider2D bg_collider;

    private void Awake()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        bg_collider = GameObject.FindGameObjectWithTag("BG").GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        RunnerController controller = pl.GetComponent<RunnerController>();
        controller.isDead = true;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }
}
