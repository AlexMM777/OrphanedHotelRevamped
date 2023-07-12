using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepObjectDetector : MonoBehaviour
{
    public GameObject playerBody;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (playerBody.GetComponent<FootSteps>().isOnGround)
        {
            if (other.gameObject.tag == "Stone")
            {
                playerBody.GetComponent<FootSteps>().isOnObj = true;
                Debug.Log("Stone");
                playerBody.GetComponent<FootSteps>().chosenSounds = playerBody.GetComponent<FootSteps>().stoneSteps;
                playerBody.GetComponent<FootSteps>().ChooseRandom();
            }

            if (other.gameObject.tag == "Wood")
            {
                playerBody.GetComponent<FootSteps>().isOnObj = true;
                Debug.Log("Wood");
                playerBody.GetComponent<FootSteps>().chosenSounds = playerBody.GetComponent<FootSteps>().woodSteps;
                playerBody.GetComponent<FootSteps>().ChooseRandom();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Stone")||(other.gameObject.tag == "Wood"))
        {
            playerBody.GetComponent<FootSteps>().isOnObj = false;
        }
    }
}
