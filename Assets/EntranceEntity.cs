using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceEntity : MonoBehaviour
{
    static public bool leave = false;
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "wheel")
        {
            leave = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "wheel")
        {
            leave = false;
        }
    }
}
