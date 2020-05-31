using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for triggering dialogue at a location once
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue m_dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(m_dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
        {
            if (GetComponent<BoxCollider2D>().isTrigger)
            {
                TriggerDialogue();
                Destroy(this.gameObject);
            }
        }
    }
}
