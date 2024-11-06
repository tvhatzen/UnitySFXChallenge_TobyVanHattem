//Attach this script to a GameObject with an Animator component attached.
//For this example, create parameters in the Animator and name them “Crouch” and “Jump”
//Apply these parameters to your transitions between states

//This script allows you to trigger an Animator parameter and reset the other that could possibly still be active. Press the up and down arrow keys to do this.

using UnityEngine;

public class Example : MonoBehaviour
{
    Animator DoorAnimController;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        DoorAnimController = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Reset the "Crouch" trigger
            DoorAnimController.ResetTrigger("Crouch");

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            DoorAnimController.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Reset the "Jump" trigger
            DoorAnimController.ResetTrigger("Jump");

            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            DoorAnimController.SetTrigger("Crouch");
        }
    }
}