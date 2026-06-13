using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
