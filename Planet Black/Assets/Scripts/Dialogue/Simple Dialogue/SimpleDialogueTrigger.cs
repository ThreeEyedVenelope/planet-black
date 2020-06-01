using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script looks for the SimpleDialogueManager
/// </summary>
public class SimpleDialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private SimpleDialogue m_dialogue;

    public void TriggerSimpleDialogue()
    {
        FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
        {
            if (GetComponent<BoxCollider2D>().isTrigger)
            {
                if (GetComponent<PickupObject>() == null)
                {
                    TriggerSimpleDialogue();
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
    //    {
    //        if (GetComponent<BoxCollider2D>().isTrigger)
    //        {
    //            if (collision.GetComponent<PickupObject>() != null && collision.GetComponent<PlayerInteractionHandler>().PickupInput)
    //            {
    //                TriggerSimpleDialogue();
    //                Destroy(this.gameObject);
    //            }
    //        }
    //    }
    //}
}
