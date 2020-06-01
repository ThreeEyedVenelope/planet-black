using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAnimatorEvents : MonoBehaviour
{
    [SerializeField]
    private GameObject m_hubbleGameObject = null;

    private GameObject m_hubbleShadowGameObject = null;

    [SerializeField]
    private GameObject m_hubbleCryoChamber = null;

    private int m_defaultPlayerSortingOrder = 0;

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void DestroyHubbleCryoChamberObject()
    {
        Destroy(m_hubbleCryoChamber);
    }

    /// <summary>
    /// Hide player upon level start
    /// </summary>
    public void FindAndMovePlayerToBackSortingLayer()
    {
        if (m_hubbleGameObject != null)
        {
            // Get the shadow object that's a child of Hubble
            m_hubbleShadowGameObject = m_hubbleGameObject.transform.Find("Shadow").gameObject;

            // Get the sorting layer from Hubble
            m_defaultPlayerSortingOrder = m_hubbleGameObject.GetComponent<SpriteRenderer>().sortingOrder;

            // -10 was used in an attempt to ensure that the player is sent behind any set pieces
            m_hubbleGameObject.GetComponent<SpriteRenderer>().sortingOrder = m_hubbleShadowGameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        }
    }

    /// <summary>
    /// Reset the player's sorting level to it's  original value.
    /// </summary>
    public void ResetPlayerSortingLayer()
    {
        if (m_hubbleGameObject != null)
        {
            m_hubbleGameObject.GetComponent<SpriteRenderer>().sortingOrder = m_hubbleShadowGameObject.GetComponent<SpriteRenderer>().sortingOrder = m_defaultPlayerSortingOrder;
        }
    }

    /// <summary>
    /// Used to stop player movement during the intro sequence, but I left it generic enough to be used for other reasons
    /// </summary>
    public void StartAndStopPlayerMovement()
    {
        m_hubbleGameObject.GetComponent<PlayerMovementController>().CanMove = !m_hubbleGameObject.GetComponent<PlayerMovementController>().CanMove;
    }
}
