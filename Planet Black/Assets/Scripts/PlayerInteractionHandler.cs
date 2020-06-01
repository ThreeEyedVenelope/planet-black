using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

/// <summary>
/// Handles interaction between the player and interactables like keycards and doors
/// </summary>
public class PlayerInteractionHandler : MonoBehaviour
{
    private bool m_hasToolBox = false;
    private bool m_hasStorageRoomKeycard = false;
    private bool m_hasBridgeKeycard = false;

    private void OnTriggerEnter2D(Collider2D collision) // changing OnTriggerStay2D to OnTriggerEnter2D
    {

        // TODO: Debugging Pickup Interaction
        Debug.Log($"The player has entered a triggerVolume.");

        if (collision.tag == "Pickup")
        {
            // TODO: Add Pickup Interaction Input
            //Debug.Log($"The player is trying to interact. PickupInput == {PickupInput}");

            if (collision.GetComponent<PickupObject>().IsToolbox)
            {
                m_hasToolBox = true;
            }
            else if (collision.GetComponent<PickupObject>().IsStorageRoomKeycard)
            {
                m_hasStorageRoomKeycard = true;
            }
            else if (collision.GetComponent<PickupObject>().IsBridgeKeycard)
            {
                m_hasBridgeKeycard = true;
            }

            collision
        }
    }
}
