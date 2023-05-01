using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject playerController;
    public AudioSource audioSource;
    public AudioClip[] stoneSteps, grassSteps, dirtSteps;
    public int stoneIndex, grassIndex, dirtIndex, woodChipIndex;
    private AudioClip[] chosenSounds;
    public bool isOnGround;
    public AudioClip finalChosen;

    // Start is called before the first frame update
    void Start()
    {
        finalChosen = stoneSteps[Random.Range(0, stoneSteps.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = playerController.GetComponent<Player>().onGround;

        if (playerController.GetComponent<FirstPersonAIO>().IsGrounded && isOnGround)
        {
            if(playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == stoneIndex)
            {
                chosenSounds = stoneSteps;
                ChooseRandom();
            }
            if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == grassIndex)
            {
                chosenSounds = grassSteps;
                ChooseRandom();
            }
            if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == dirtIndex)
            {
                chosenSounds = dirtSteps;
                ChooseRandom();
            }
            if (playerController.GetComponent<TerrainTextureDetector>().surfaceIndex == woodChipIndex)
            {
                chosenSounds = grassSteps;
                ChooseRandom();
            }
        }
    }

    void ChooseRandom()
    {
        //audioSource.clip = chosenSounds[Random.Range(0, chosenSounds.Length)];
        finalChosen = chosenSounds[Random.Range(0, chosenSounds.Length)];
        //audioSource.Play();
    }
}
