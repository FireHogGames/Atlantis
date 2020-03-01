using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float speed; //This value is the general speed var. This will change to the values for movement.
    [SerializeField] private float sensitivity; //Values for rotation
    [SerializeField] private Camera cam; //Player Camera

    Vector3 movement; //This will contain the movement and gravity values for the character controller
    CharacterController cc; //This is the controller used to move the character
    float _xRot; //This is stored here for annoying unity reasons ¯\_(ツ)_/¯
    float gravity; //Used for gravity

    private bool isPaused; //Used to disable movement if the character is paused

    // Start is called before the first frame update.
    void Start()
    {
        //Get the character controller
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame.
    void Update()
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;

            if (cc.isGrounded)
            {
                gravity = Physics.gravity.y;
            }
            else
            {
                gravity += Physics.gravity.y * Time.deltaTime;
            }

            //Record the axis values and put them in a float
            float _xMov = Input.GetAxis("Horizontal") * speed;
            float _zMov = Input.GetAxis("Vertical") * speed;

            //Put the movement values into the movement vector
            movement = new Vector3(_xMov, gravity, _zMov);

            //Rotate the player
            float _yRot = Input.GetAxis("Mouse X") * sensitivity;
            transform.Rotate(0f, _yRot, 0f);

            //Rotate the player camera
            _xRot -= Input.GetAxis("Mouse Y") * sensitivity;
            _xRot = Mathf.Clamp(_xRot, -80f, 80f);
            cam.transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);

            //Move to the look direction
            movement = transform.rotation * movement;

            //Move the CharacterController
            cc.Move(movement * Time.deltaTime);
        }
    }

    public void SetPaused(bool value)
    {
        isPaused = value;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }
}
