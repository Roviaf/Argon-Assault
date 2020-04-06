using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [Header("Screen-throw based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] GameObject[] guns;

    ScoreBoard scoreBoard;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            timingPoints();
            ProcessFiring();
        }

    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            //activateGuns();
            SetactivateGuns(true);
        }
        else
        {
            SetactivateGuns(false);
            //desactivateGuns();
        }
    }
    private void SetactivateGuns(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var gunnss = gun.GetComponent<ParticleSystem>().emission;
            gunnss.enabled = isActive;
            
        }
    }
    /*
    private void activateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
    private void desactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
    */


    public void timingPoints()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); 
        scoreBoard.BeingAlive();
    }
    public void ApplyDamage(string damage)
    {
        isControlEnabled = false;
        
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; // localposition from object times a value
        float pitchDueToControlThrow = yThrow * controlPitchFactor; 
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; // getting the localposition X and increasing by Offset
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // Making sure that it does not go outside the "box"

        float rawYPos = transform.localPosition.y + yOffset; // getting the localposition Y and increasing by Offset
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); 

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //Moving the object's position
    }

}