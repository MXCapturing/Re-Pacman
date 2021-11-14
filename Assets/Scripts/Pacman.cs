using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{

    public Movement movement { get; private set; }

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            movement.SetDirection(Vector2.left);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            movement.SetDirection(Vector2.right);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            movement.SetDirection(Vector2.down);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            movement.SetDirection(Vector2.up);
        }

        float angle = Mathf.Atan2(movement.direction.y, movement.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.RestartState();
    }
}
