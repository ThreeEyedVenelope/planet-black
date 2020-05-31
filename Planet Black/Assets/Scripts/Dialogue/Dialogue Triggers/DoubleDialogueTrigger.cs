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

    [SerializeField, Tooltip("Will this dialogue trigger delete itself or it's parent object?")]
    private bool m_destroyParent = false;

    private bool m_completedFirstInteraction = false;

    public void TriggerDialogue()
    {
        if (m_completedFirstInteraction == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(m_firstInteractionDialogue);
        }
        else
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
                    if (m_destroyParent == true)
                    {
                        Destroy(this.transform.parent.gameObject);
                    }
                    else
                    {
                        Destroy(this.gameObject);
                    }
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
