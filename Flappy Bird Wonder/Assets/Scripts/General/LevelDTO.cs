using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDTO : MonoBehaviour
{
    private static LevelDTO instance;

    public static LevelDTO Instance
    {
        get
        {
            if (LevelDTO.instance == null)
            {
                GameObject go = new GameObject("LevelDTO");
                DontDestroyOnLoad(go);
                instance = go.AddComponent<LevelDTO>();
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public static int Score = 0;
    public static float ExitHeight = 0;
    public static ExitMethod ExitMethod = ExitMethod.None;

    public static void Reset()
    {
        Score = 0;
        ExitHeight = 0;
        ExitMethod = ExitMethod.None;
    }
}
