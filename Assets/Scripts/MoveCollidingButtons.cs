using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollidingButtons : MonoBehaviour
{
    public DetectClick dc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("buttons collided");
        dc.MoveButton();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("buttons are colliding");
        dc.MoveButton();
    }
}
