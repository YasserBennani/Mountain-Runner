using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPotionController : MonoBehaviour
{ 
    //public GameObject player;
    private RunnerController runnerController;
    private UIController uiController;

    private float defaultPlayerSpeed;
    private float defaultPlayerJump;
    public float jumpPotionDuration;


    void Awake()
    {
        runnerController = GameObject.FindGameObjectWithTag("Player").GetComponent<RunnerController>();
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

        defaultPlayerSpeed = runnerController.runSpeed;
        defaultPlayerJump = runnerController.jumpForce;

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
        Debug.Log("Hit Potion!");
        //uiController.potionLeft += runnerController.jumpPotionDuration;
        runnerController.isBoosted = true;
        runnerController.jumpForce *= 1.15f;
        runnerController.runSpeed *= 1.15f;
        yield return new WaitForSeconds(runnerController.jumpPotionDuration);
        runnerController.isBoosted = false;
        runnerController.jumpForce = defaultPlayerJump;
        runnerController.runSpeed = defaultPlayerSpeed;
    }
}
