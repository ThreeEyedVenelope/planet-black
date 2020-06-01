using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

/// <summary>
/// Handles interaction between the player and interactables like keycards and doors
/// </summary>
public class PlayerInteractionHandler : MonoBehaviour
{
    // TODO Serialized for debugging purposes
    [SerializeField]
    private bool m_hasToolBox = false;
    [SerializeField]
    private bool m_hasStorageRoomKeycard = false;
    [SerializeField]
    private bool m_hasBridgeKeycard = false;

    public bool HasToolbox { get { return m_hasToolBox; } set { m_hasToolBox = value; } }
    public bool HasStorageRoomKeycard { get { return m_hasStorageRoomKeycard; } set { m_hasStorageRoomKeycard = value; } }
    public bool HasBridgeKeycard { get { return m_hasBridgeKeycard; } set { m_hasBridgeKeycard = value; } }


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
                HasToolbox = true;
            }
            else if (collision.GetComponent<PickupObject>().IsStorageRoomKeycard)
            {
                HasStorageRoomKeycard = true;
            }
            else if (collision.GetComponent<PickupObject>().IsBridgeKeycard)
            {
                HasBridgeKeycard = true;
            }

            collision.GetComponent<PickupObject>().RazeThisObject();
        }
    }
}
