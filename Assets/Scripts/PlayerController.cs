using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves around with player input.")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("Max distance the ship can move left or right from center with player input.")]
    [SerializeField] float xRange = 6f;
    [Tooltip("Max distance the ship can move up or down from center with player input.")]
    [SerializeField] float yRange = 6f;

    [Header("Laser Gun Array")]
    [Tooltip("Laser gun particle objects")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen Position Settings")]
    [Tooltip("Rotation for pitch based on ship's vertical screen position.")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Rotation for yaw based on ship's horizontal screen position.")]
    [SerializeField] float positionYawFactor = 2f;
    [Tooltip("Rotation for pitch based on ship's vertical player input.")]
    [SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Rotation for pitch based on ship's horizontal player input.")]
    [SerializeField] float controlRollFactor = -10f;


    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {

        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos,
        clampedYPos,
        transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
