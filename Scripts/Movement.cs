using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //caching
    Rigidbody rocketRigidBody;
    AudioSource rocketThurstSound; 

    //parameters 
    [SerializeField] float rocketUpwardThurst = 1000f;
    [SerializeField] float rocketRotationSpeed = 100f;
    [SerializeField] AudioClip mainThurstSound;

    //thurster particle system
    [SerializeField] ParticleSystem mainThurstParticles;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>(); 
        rocketThurstSound = GetComponent<AudioSource>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        RocketThurst();
        RocketRotation();
    }

    void RocketThurst()
    {
        //when user clicks space bar rocket thurts forward
        if (Input.GetKey(KeyCode.Space))
        {
            //adds force relative to the rigid body position 
            //Vector3 is all three values - direction and magnitude short hand for right 0,1,0
            //adding in Time.deltaTime to make the movement frame rate independent 
            rocketRigidBody.AddRelativeForce(Vector3.up * rocketUpwardThurst * Time.deltaTime);
            
            //nested if to play sound when rocket is thrusting 
            if (!rocketThurstSound.isPlaying)
            {
                rocketThurstSound.PlayOneShot(mainThurstSound); 
            }

            //nest if to play particles when rocket is thursting
            if (!mainThurstParticles.isPlaying)
            {
                mainThurstParticles.Play();
            }
            
        }
        else
        {
            //audio wont play when space isnt clicked
            rocketThurstSound.Stop();
            mainThurstParticles.Stop(); 
        }
    }

    void RocketRotation()
    {
        //when user clicks left arrowkey - rotate rocket to the left 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //freezing rotation so rocket can manaully rotate 
            rocketRigidBody.freezeRotation = true; 
            transform.Rotate(Vector3.forward * rocketRotationSpeed * Time.deltaTime);
            //unfreezing rotation
            rocketRigidBody.freezeRotation = false;
        }
        //when user clicks right arrow key - rotate to the right 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //freezing rotation so rocket can manaully rotate 
            rocketRigidBody.freezeRotation = true;
            transform.Rotate(-Vector3.forward * rocketRotationSpeed * Time.deltaTime);
            //unfreezing rotation
            rocketRigidBody.freezeRotation = false;
        }
    }
}
