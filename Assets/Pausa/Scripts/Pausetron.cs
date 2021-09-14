using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausetron : MonoBehaviour
{
    public static Pausetron current;

    public GameObject pauseMenu;

    public bool isPaused { get; protected set; }

    void Awake()
    {
        // Patrón Singleton
        current = this;
        this.Resume();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) // Tecla Escape
        {
            if (this.isPaused)
            {
                this.Resume();
            }
            else
            {
                this.Pause();
            }
        }
    }

    public void Pause()
    {
        this.isPaused = true;
        this.pauseMenu.SetActive(true);

        // Se detienen todas las operaciones basadas en tiempo
        // El Time.deltaTime se pone a 0
        // Update() NO se para
        // FixedUpdate() SÍ se para
        // Corutinas usando WaitForSeconds (WaitForSecondsRealtime)
        Time.timeScale = 0;
    }

    public void Resume()
    {
        this.isPaused = false;
        this.pauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Esto podría ir en otro script.
    /// </summary>
    public void Exit()
    {
        SceneManager.LoadScene("PMenu");
    }
}