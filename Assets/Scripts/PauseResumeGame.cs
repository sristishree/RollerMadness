using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
