using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private double distanceRan=0f;
    //public float shieldLeft=10f;
    //public float potionLeft = 5f;

    private float ogDistance;
    private float currDistance;


    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI potionText;


    private Transform runnerTransform;
    private RunnerController runnerController;


    void Awake()
    {
        runnerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        runnerController = GameObject.FindGameObjectWithTag("Player").GetComponent<RunnerController>();
        ogDistance = runnerTransform.position.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceRan = System.Math.Round((double)(runnerTransform.position.x - ogDistance), 1);
        distanceText.text = "Distance: " + distanceRan + " m";


        if (runnerController.isBoosted)
        {
            potionText.text = "Boost: ON";
        }
        else
        {
            potionText.text = "Boost: OFF";
        }



        if (runnerController.isShielded)
        {
            shieldText.text = "Shield: ON";
        }
        else
        {
            shieldText.text = "Shield: OFF";
        }
    }
}





// NOTE TO SELF: Was inside update function to implement timers for powerups
// but Time.deltaTime was not reliable in calculating countdown.

//if (potionLeft > 0)
//{
//    potionLeft = (float)System.Math.Round((double)(potionLeft - Time.deltaTime), 1);

//}
//else
//{
//    potionLeft = 0;
//}
////potionLeft -= Time.deltaTime;
//potionText.text = "Boost Left: " + potionLeft + " s";

//if (shieldLeft > 0)
//{
//    shieldLeft = (float)System.Math.Round((double)(shieldLeft - Time.deltaTime), 1);
//}
//else
//{
//    shieldLeft = 0;
//}
////shieldLeft -= Time.deltaTime;
//shieldText.text = "Shield Left: " + shieldLeft + " s";