using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : PacDot
{
    public float duration = 8f;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPellet(this);
    }
}
