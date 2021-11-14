using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public SpriteRenderer spriteRend {get; private set;}
    public Movement movement { get; private set; }
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        if(movement.direction == Vector2.up)
        {
            spriteRend.sprite = up;
        }
        else if (movement.direction == Vector2.down)
        {
            spriteRend.sprite = down;
        }
        else if (movement.direction == Vector2.left)
        {
            spriteRend.sprite = left;
        }
        else if (movement.direction == Vector2.right)
        {
            spriteRend.sprite = right;
        }
    }
}
