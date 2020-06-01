using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Double_SimpleDialogueTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("The first dialogue to be triggered.")]
    private SimpleDialogue m_firstInteractionDialogue;

    [SerializeField, Tooltip("The second dialogue to be triggered.")]
    private SimpleDialogue m_secondInteractionDialogue;

    [Header("Additional Setting & Lock Conditions")]

    [SerializeField, Tooltip("Will this dialogue trigger delete itself or it's parent object?")]
    private bool m_destroyParent = false;

    [SerializeField, Tooltip("Does this interactable require an item to initiate the second interaction?")]
    private bool m_requireUnlockCondition = false;

    [Header("--ONLY PICK ONE--")]

    [SerializeField, Tooltip("Does the player need the toolbox to initiate the second interaction?")]
    private bool m_requireToolbox = false;

    [SerializeField, Tooltip("Does the player need the green keycard to initiate the second interaction?")]
    private bool m_requireGreenKeycard = false;

    [SerializeField, Tooltip("Does the player need the orange keycard to initiate the second interaction?")]
    private bool m_requireOrangeKeycard = false;

    public bool RequireUnlockCondition { get { return m_requireUnlockCondition; } set { m_requireUnlockCondition = value; } }

    private bool m_completedFirstInteraction = false, m_unlockConditionsMet = false;

    /// <summary>
    /// Meant for initial interactions and ones that don't require special conditions to initiate the second interaction
    /// </summary>
    public void TriggerSimpleDialogue()
    {
        if (m_completedFirstInteraction == false)
        {
            FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_firstInteractionDialogue);
        }
        else if (!m_requireUnlockCondition)
        {
            FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_secondInteractionDialogue);
        }
    }

    public void TriggerSimpleDialogue(PickupObject pickup)
    {
        if (m_requireUnlockCondition == true)
        {
            if (m_requireToolbox)
            {

            }
            else if (m_requireGreenKeycard)
            {

            }
            else if (m_requireOrangeKeycard)
            {

            }
        }

        if (GetComponent<PickupObject>() != null)
        {
            PickupObject pickedUpObject = GetComponent<PickupObject>();

            if (pickedUpObject.IsToolbox == true)
            {
                FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_secondInteractionDialogue);
            }
            else if (pickedUpObject.IsStorageRoomKeycard == true)
            {
                FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_secondInteractionDialogue);
            }
            else if (pickedUpObject.IsBridgeKeycard == true)
            {
                FindObjectOfType<SimpleDialogueManager>().StartSimpleDialogue(m_secondInteractionDialogue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<BoxCollider2D>() != null)
        {
            if (GetComponent<BoxCollider2D>().isTrigger)
            {
                if (!m_requireUnlockCondition)
                {
                    TriggerSimpleDialogue();

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
                else
                {
                    if (m_requireToolbox)
                    {

                    }
                    else if (m_requireGreenKeycard)
                    {

                    }
                    else if (m_requireOrangeKeycard)
                    {

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
