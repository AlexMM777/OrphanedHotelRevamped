using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject playerController;
    public AudioSource audioSource;
    public AudioClip[] stoneSteps, grassSteps, dirtSteps, woodSteps;
    public int stoneIndex, grassIndex, dirtIndex, woodChipIndex, woodIndex;
    public AudioClip[] chosenSounds;
    public bool isOnGround;
    public AudioClip finalChosen;
    public bool isOnObj;

    // Start is called before the first frame update
    void Start()
    {
        finalChosen = stoneSteps[Random.Range(0, stoneSteps.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = playerController.GetComponent<Player>().onGround;

        if(!isOnObj) {
            Debug.Log("Is on terrain");
            if (playerController.GetComponent<FirstPersonAIO>().IsGrounded && isOnGround)
            {
                if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == stoneIndex)
                {
                    //Debug.Log("Stone");
                    chosenSounds = stoneSteps;
                    ChooseRandom();
                }
                if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == grassIndex)
                {
                    //Debug.Log("Grass");
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == dirtIndex)
                {
                    //Debug.Log("Dirt");
                    chosenSounds = dirtSteps;
                    ChooseRandom();
                }
                if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == woodChipIndex)
                {
                    //Debug.Log("WoodChip");
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == woodIndex)
                {
                    //Debug.Log("Wood");
                    chosenSounds = woodSteps;
                    ChooseRandom();
                }
            }
        }
    }
    

    public void ChooseRandom()
    {
        //audioSource.clip = chosenSounds[Random.Range(0, chosenSounds.Length)];
        finalChosen = chosenSounds[Random.Range(0, chosenSounds.Length)];
        //audioSource.Play();
    }
}
