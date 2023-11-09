using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeJumpBird : Bird
{
    const float targetHeight = 0;

    protected override void OnAwake()
    {
        controls.Disable();

        StartCoroutine(JumpLoop());
    }

    IEnumerator JumpLoop()
    {
        while (this.gameObject.activeInHierarchy)
        {
            if(rb.velocity.y < 0 && transform.position.y < targetHeight)
            {
                base.Jump(new UnityEngine.InputSystem.InputAction.CallbackContext());
            }

            yield return null;
        }
    }
}
