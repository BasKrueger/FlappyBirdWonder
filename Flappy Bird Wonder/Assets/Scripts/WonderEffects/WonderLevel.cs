using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonderLevel : Level
{
    protected override IEnumerator LoadWonderLevelDelayed()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
        SceneManager.LoadScene(0); //always loads into basic level
    }
}
