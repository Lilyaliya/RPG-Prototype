using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] KeyCode keyPause;
    bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    // when we go to the menu panel, the player need to get the cursor visible and enabled
    void ActivateCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    private void Update()
    {
        ActivateMenu();
    }
    public void Continue()
    {
        isPaused = false;
        ActivateMenu();
    }
    public void Options()
    {
        Debug.Log("Вызвались настройки");
    }
    public void MainMenu()
    {
        Debug.Log("Вышли в главное меню");
    }
    // what happens if I push a pauseKey 2 times? (disable! repeated checking pressed keyPause)
    void ActivateMenu()
    {
        if (Input.GetKeyDown(keyPause))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            ActivateCursor();
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            DisableCursor();

        }
    }

}
