using UnityEngine;

public class Case2_GameManager : MonoBehaviour
{
    public static Case2_GameManager s_current;

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

    private SanchoStats protagonistStats;

    void Start()
    {
        var sanchoStats = FindObjectOfType<SanchoStats>();

        this.OnProtagonistCheckpoint(sanchoStats);
        this.protagonistStats = sanchoStats;
    }

    public void OnProtagonistDeath(GameObject sanchoObject)
    {
        this.protagonistStats.gameObject.SetActive(false);

        Invoke("Respawn", 1f);
    }

    void Respawn()
    {
        this.protagonistStats.gameObject.SetActive(true);
        this.protagonistStats.transform.position = s_sanchoStoredData.checkPointposition;

        this.protagonistStats.RestoreHealthStat(s_sanchoStoredData.health);
    }

    public void OnProtagonistCheckpoint(SanchoStats sanchoStats)
    {
        s_sanchoStoredData = new SanchoData(sanchoStats.health, sanchoStats.bones, sanchoStats.transform.position);
    }
}