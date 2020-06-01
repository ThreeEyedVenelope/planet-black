using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLeakyPipe_Interaction : MonoBehaviour
{
    public void FixLeakyPipe()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
