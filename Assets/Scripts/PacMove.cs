using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right}

public class PacMove : MonoBehaviour
{
    public Direction dir;
    public float speed;
    public bool canMove;
    public bool allowMove;
    public string facing;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PacManMove();
    }

    private void FixedUpdate()
    {
        PacCheckDir();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.5f, layerMask);
        if(hit.collider != null)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    void PacManMove()
    {
        if (canMove && allowMove)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        #region Collision Check
        if (dir == Direction.Up)
        {
            var hitcollider = Physics2D.OverlapCircle(transform.position + new Vector3(0, 1, 0), 0.4f);
            Debug.Log(hitcollider);
            if(hitcollider == null)
            {
                facing = "up";
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        if (dir == Direction.Down)
        {
            var hitcollider = Physics2D.OverlapCircle(transform.position + new Vector3(0, -1, 0), 0.4f);
            Debug.Log(hitcollider);
            if (hitcollider == null)
            {
                facing = "down";
                transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        if (dir == Direction.Right)
        {
            var hitcollider = Physics2D.OverlapCircle(transform.position + new Vector3(1, 0, 0), 0.4f);
            Debug.Log(hitcollider);
            if (hitcollider == null)
            {
                facing = "right";
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (dir == Direction.Left)
        {
            var hitcollider = Physics2D.OverlapCircle(transform.position + new Vector3(-1, 0, 0), 0.4f);
            Debug.Log(hitcollider == null);
            if (hitcollider == null)
            {
                facing = "left";
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
        #endregion
    }

    void PacCheckDir()
    {
        if (allowMove)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                dir = Direction.Left;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                dir = Direction.Right;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                dir = Direction.Down;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                dir = Direction.Up;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (dir == Direction.Up)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + new Vector3(0, 1, 0), 0.4f);
        }
        if (dir == Direction.Down)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + new Vector3(0, -1, 0), 0.4f);
        }
        if (dir == Direction.Right)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + new Vector3(1, 0, 0), 0.4f);
        }
        if (dir == Direction.Left)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + new Vector3(-1, 0, 0), 0.4f);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * 0.5f));

    }
}
