using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonSpriteRenderer;

    [SerializeField] private Color hoverColor;

    private void OnMouseOver()
    {
        buttonSpriteRenderer.color = hoverColor;
    }

    private void OnMouseExit()
    {
        buttonSpriteRenderer.color = Color.white;
    }
}
