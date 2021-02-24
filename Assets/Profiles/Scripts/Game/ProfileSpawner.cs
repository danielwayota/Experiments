using UnityEngine;

public class ProfileSpawner : MonoBehaviour
{
    public Transform newGameSpawn;
    public GameObject playerPrefab;

    private void Start()
    {
        // Nuevo juego
        if (ProfileStorage.s_currentProfile == null || ProfileStorage.s_currentProfile.newGame)
        {
            Instantiate(this.playerPrefab, this.newGameSpawn.position, Quaternion.identity);
        }
        else
        {
            // Carga de partida
            float x = ProfileStorage.s_currentProfile.x;
            float y = ProfileStorage.s_currentProfile.y;

            Vector3 pos = new Vector3(x, y, 0);

            Instantiate(this.playerPrefab, pos, Quaternion.identity);
        }
    }
}
