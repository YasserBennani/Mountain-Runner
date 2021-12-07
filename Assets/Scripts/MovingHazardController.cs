using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovingHazardController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 originalPosition;
    public float hazardSpeed = 2f;

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
        originalPosition = transform.position;
    }
    public AnimationCurve curve;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(originalPosition.x,
        curve.Evaluate((Time.time % curve.length *hazardSpeed)) + originalPosition.y);
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        RunnerController controller = pl.GetComponent<RunnerController>();
        controller.isDead = true;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }
}
