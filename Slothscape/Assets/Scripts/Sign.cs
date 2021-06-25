using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  Check for player interaction with the sign 
//      and activate the dialogue box if
//          the player is in range.
public class Sign : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    [TextArea]
    public string dialogue;
    public bool playerInRange;

    void Start()
    {
        
    }

    void Update()
    {
        // If the space (changeable) key is pressed and
        //  the player is in range of the sign, activate
        //  the dialogue box.        
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                //  Turn off the dialogue box if it's already
                //   active.
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
    }

    // Checks if the player is in range of the sign
    //  and sets the bool accordingly
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Removes the dialogue box from view if 
    //  the player left the sign's range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
