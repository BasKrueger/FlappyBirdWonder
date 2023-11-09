using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    const float fallTimeTilt = 0.35f;

    public float jumpForce;

    [HideInInspector]
    public UnityEvent Died = new UnityEvent();

    private float activeFallTime = 0;
    private BirdSounds sounds;
    private Animator anim;
    
    protected Controls controls;
    protected Rigidbody2D rb;

    private void Awake()
    {
        controls = new Controls();
        controls.Bird.Jump.performed += Jump;
        controls.Enable();

        sounds = GetComponentInChildren<BirdSounds>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Lock();
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Bird.Jump.performed -= Jump;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2();
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        activeFallTime = 0;

        sounds.Play(BirdSound.Flap);
    }

    public void Lock()
    {
        rb.velocity = new Vector2();
        rb.isKinematic = true;
    }

    public void UnLock()
    {
        rb.isKinematic = false;
    }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }

    private void FixedUpdate()
    {
        activeFallTime += rb.velocity.y < 0 ? Time.fixedDeltaTime : 0;
        anim.SetBool("LookDown", activeFallTime > fallTimeTilt);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collide(collision);
    }

    protected virtual void Collide(Collision2D collision)
    {
        controls.Disable();

        anim.SetBool("Dead", true);

        this.gameObject.layer = LayerMask.NameToLayer("DeadBird");

        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<EdgeCollider2D>().enabled = false;
        
        rb.velocity = new Vector2();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) 
            sounds.Play(BirdSound.HitGround);
        else
            sounds.Play(BirdSound.HitPipe);

        Died?.Invoke();

        Destroy(this);
    }
}
