using UnityEngine;
using UnityEngine.SceneManagement;

public class Case1_GameManager : MonoBehaviour
{
    public static Case1_GameManager s_current;

    protected static SanchoData s_sanchoStoredData = null;

    void Awake()
    {
        s_current = this;
    }

    public void SaveProtagonistData()
    {
        var sanchoStats = FindObjectOfType<SanchoStats>();

        s_sanchoStoredData = new SanchoData(sanchoStats.health, sanchoStats.bones);
    }

    void Start()
    {
        var sanchoStats = FindObjectOfType<SanchoStats>();
        if (s_sanchoStoredData != null)
        {
            sanchoStats.RestoreStats(s_sanchoStoredData.health, s_sanchoStoredData.bones);
        }
    }

    public void OnProtagonistDeath(GameObject sanchoObject)
    {
        Destroy(sanchoObject);

        Invoke("Respawn", 1f);
    }

    protected void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
