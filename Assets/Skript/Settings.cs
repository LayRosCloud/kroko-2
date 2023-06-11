using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
     public static class GameSettings
    {
        public static void OnBeforeSceceLoadRuntimeMethod()
        {
            #if UNITY_IOS || UNITY_ANDROID
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            #endif
        }
    }
}
