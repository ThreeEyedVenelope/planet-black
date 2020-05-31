using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for triggering dialogue at a location two separate times
/// </summary>
public class DoubleDialogueTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("The first dialogue to be triggered.")]
    private Dialogue m_firstInteractionDialogue;

    [SerializeField, Tooltip("The second dialogue to be triggered.")]
    private Dialogue m_secondInteractionDialogue;

    private bool m_completedFirstInteraction = false;

    public void TriggerDialogue()
    {
        if (m_completedFirstInteraction == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(m_firstInteractionDialogue);
        }
        else if (m_completedFirstInteraction == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(m_secondInteractionDialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
        {
            if (GetComponent<BoxCollider2D>().isTrigger)
            {
                TriggerDialogue();

                // Destroy this GameObject once the second interaction is initiated
                if (m_completedFirstInteraction == true)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
        {
            if (GetComponent<BoxCollider2D>().isTrigger)
            {
                m_completedFirstInteraction = true;
            }
        }
    }
}
