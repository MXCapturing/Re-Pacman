using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRend { get; private set; }
    public Sprite[] sprites;
    public float animationTime = 0.25f;
    public int animFrame { get; private set; }
    public bool loop = true;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    void Advance()
    {
        Debug.Log("Anim");
        if (!spriteRend.enabled)
        {
            return;
        }

        animFrame++;

        if(animFrame >=  sprites.Length && loop)
        {
            animFrame = 0;
        }
        if(animFrame >= 0 && animFrame < sprites.Length)
        {
            spriteRend.sprite = sprites[animFrame];
        }
    }

    public void Restart()
    {
        animFrame = -1;
        Advance();
    }
}
