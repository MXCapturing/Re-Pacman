using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    public Rigidbody2D _rb { get; private set; }

    public float speed = 8;
    public float speedMultiplier = 1;
    public Vector2 initDir;
    public LayerMask layerMask;

    public Vector2 direction { get; private set; }
    public Vector2 nextDir { get; private set; }
    public Vector3 startPos { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Start()
    {
        RestartState();
    }

    public void RestartState()
    {
        speedMultiplier = 1f;
        direction = initDir;
        nextDir = Vector2.zero;
        transform.position = startPos;
        _rb.isKinematic = false;
        enabled = true;
    }

    private void Update()
    {
        if(nextDir != Vector2.zero)
        {
            SetDirection(nextDir);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = _rb.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
        _rb.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (!Occupied(direction) || forced)
        {
            this.direction = direction;
            nextDir = Vector2.zero;
        }
        else
        {
            nextDir = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * .75f, 0f, direction, 1.5f, layerMask);
        return hit.collider != null;
    }
}
