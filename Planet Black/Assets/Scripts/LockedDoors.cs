using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to access the door animators a little easier
/// </summary>
public class LockedDoors : MonoBehaviour
{
    [SerializeField]
    private GameObject m_doorObject = null;

    private Animator m_doorAnim = null;

    private bool m_isStorageRoomDoor = false, m_isBridgeDoor = false;

    private bool m_isLocked = true;

    public void DoorFinishOpening()
    {
        m_doorAnim.SetBool("FullyOpened", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInteractionHandler>() != null)
            {
                if (m_isLocked)
                {
                    Debug.Log("They dont want to hit us.");

                    if (m_isStorageRoomDoor)
                    {
                        if (collision.GetComponent<PlayerInteractionHandler>().HasStorageRoomKeycard)
                        {
                            m_isLocked = false;
                            collision.GetComponent<PlayerInteractionHandler>().HasStorageRoomKeycard = false;
                        }
                    }
                    else if (m_isBridgeDoor)
                    {
                        if (collision.GetComponent<PlayerInteractionHandler>().HasBridgeKeycard)
                        {
                            m_isLocked = false;
                            collision.GetComponent<PlayerInteractionHandler>().HasBridgeKeycard = false;
                        }
                    }
                }
                else
                {
                    m_doorAnim = m_doorObject.GetComponent<Animator>();

                    m_doorAnim.SetBool("IsOpen", true);
                }
            }
        }
    }
}
