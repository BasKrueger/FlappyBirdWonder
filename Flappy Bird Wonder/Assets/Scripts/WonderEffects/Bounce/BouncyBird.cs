using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBird : Bird
{
    [SerializeField]
    private float speed;

    private bool bouncy = false;

    public void MakeBouncy(bool state)
    {
        bouncy = state;
        if(state)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }

    protected override void OnUpdate()
    {
        if (!bouncy) return;

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void SwitchDirection()
    {
        speed *= -1;
    }

    //needs to be done in lateupdate to override the bird animation rotation
    private void LateUpdate()
    {
        if (!bouncy) return;

        if (speed < 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        else
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }

    protected override void Collide(Collision2D collision)
    {
        if (bouncy)
        {
            if(collision.transform.tag == "SpecialPipe")
            {
                SwitchDirection();
                return;
            }
        }

        base.Collide(collision);
    }
}
