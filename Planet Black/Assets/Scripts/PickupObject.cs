using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField, Tooltip("Check the box if this should be the toolbox")]
    private bool m_isToolbox;

    public bool IsToolbox { get { return m_isToolbox; } }

    [SerializeField, Tooltip("Check the box if this should be Storage Room Keycard")]
    private bool m_isStorageRoomKeycard;

    public bool IsStorageRoomKeycard { get { return m_isToolbox; } }

    [SerializeField, Tooltip("Check the box if this should be Bridge Keycard")]
    private bool m_isBridgeKeycard;

    public bool IsBridgeKeycard { get { return m_isToolbox; } }

    /// <summary>
    /// Destroy the pickup object attached to this script
    /// </summary>
    public void RazeThisObject()
    {
        if (m_isToolbox)
        {
            //TODO Debug Log to Check pickup object trigger
            Debug.Log("This is a toolbox and should be picked up and destroyed");

            GetComponent<SimpleDialogueTrigger>().TriggerSimpleDialogue();

            Destroy(this.gameObject);
        }
        else if (m_isStorageRoomKeycard)
        {
            //TODO Debug Log to Check pickup object trigger
            Debug.Log("This is a Storage room Keycard and should be picked up and destroyed");

            GetComponent<SimpleDialogueTrigger>().TriggerSimpleDialogue();

            Destroy(this.gameObject);
        }
        else if (m_isBridgeKeycard)
        {
            //TODO Debug Log to Check pickup object trigger
            Debug.Log("This is the Keycard to the Bridge and should be picked up and destroyed");

            GetComponent<SimpleDialogueTrigger>().TriggerSimpleDialogue();

            Destroy(this.gameObject);
        }
    }
}
