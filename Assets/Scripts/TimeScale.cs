using UnityEngine;
using UnityEngine.Rendering;

public class TimeScale : MonoBehaviour
{
    [SerializeField] private DebugUI.Button _button;

    public void ChangeTimeScaleFalse()
    {
        Time.timeScale = 0f;
    }
    public void ChangeTimeScaleTrue()
    {
        Time.timeScale = 1f;
    }
}