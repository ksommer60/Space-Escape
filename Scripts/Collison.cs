using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collison : MonoBehaviour
{
    [SerializeField] float playerDelay = 1f;
    //audio clips
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;
    //partical systems 
    [SerializeField] ParticleSystem winLevelParticles;
    [SerializeField] ParticleSystem explostionParticles;

    AudioSource rocketSoundEffects;

    bool isTransitioning = false;
    bool isCollisonOn = false;

    void Start()
    {
        rocketSoundEffects = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || isCollisonOn)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Finish":
                StartFinishLevelSequence();
                break;
            case "Obstacle":
                StartCrashSequence();
                break;
            default:
                break;
        }
    }

    void ReloadLevel()
    {
        //reloads to active scene 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        //loads the current scene + 1 to get next scene 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        //brings player back to first level after completing all levels
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    //method will delay relaod and stop movement once player crashes
    //method will play crash sound
    void StartCrashSequence()
    {
        isTransitioning = true;
        rocketSoundEffects.Stop();
        rocketSoundEffects.PlayOneShot(crashSound);
        explostionParticles.Play(); 

        GetComponent<Movement>().enabled = false; 
        Invoke("ReloadLevel", playerDelay);
    }

    //method will delay load of next level and stop movement one player lands on finish pad
    void StartFinishLevelSequence()
    {
        isTransitioning = true;
        rocketSoundEffects.Stop();
        rocketSoundEffects.PlayOneShot(successSound);
        winLevelParticles.Play(); 
    
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", playerDelay);
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isCollisonOn = !isCollisonOn; 
        }
     
    }

}
