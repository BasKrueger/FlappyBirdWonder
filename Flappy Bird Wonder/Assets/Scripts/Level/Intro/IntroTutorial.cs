using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntroTutorial : MonoBehaviour
{
    private Controls controls;

    private Level level;
    private Bird bird;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        bird = FindObjectOfType<Bird>();

        controls = new Controls();
        controls.Enable();
    }

    private void Start()
    {
        level.speedModifier = 0;
        bird.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (controls.Bird.Jump.WasPerformedThisFrame())
        {
            level.speedModifier = 1;
            bird.GetComponent<SpriteRenderer>().enabled = true;
            bird.UnLock();
            bird.Jump(new UnityEngine.InputSystem.InputAction.CallbackContext());
            Destroy(this.gameObject);
        }
    }
}
