using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
  [SerializeField] float controlSpeed = 20f;
  [SerializeField] float xRange = 8f;
  [SerializeField] float yRange = 8f;

  [SerializeField] float positionPitchFactor = -2f;
  [SerializeField] float positionYawFactor = 2.2f;
  [SerializeField] float controlPitchFactor = -10f;
  [SerializeField] float controlRollFactor = -15f;

  float xThrow;
  float yThrow;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    ProcessTranslation();
    ProcessRotation();
  }

  void ProcessRotation()
  {
    float pitchPosition = transform.localPosition.y * positionPitchFactor;
    float pitchControl = yThrow * controlPitchFactor;

    float pitch = pitchPosition + pitchControl;
    float yaw = transform.localPosition.x * positionYawFactor;
    float roll = xThrow * controlRollFactor;

    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
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

    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
  }
}
