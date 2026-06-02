using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: https://youtu.be/tfzwyNS1LUY

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        // Activate the pause menu
        pauseMenu.SetActive(true);

        // Freeze time to pause
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        // Disable the pause menu
        pauseMenu.SetActive(false);

        // Resume time to run normally
        Time.timeScale = 1.0f;
    }

    public void MainMenu(int sceneID)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneID);
    }

    /// <summary>
    /// 切换背景音乐（由暂停菜单的按钮调用）
    /// </summary>
    public void ToggleBGM()
    {
        BGMManager bgm = FindObjectOfType<BGMManager>();
        if (bgm != null)
            bgm.ToggleBGM();
    }
}