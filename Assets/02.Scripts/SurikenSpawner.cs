using UnityEngine;

public class SurikenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject surikenPrefab;

    public void O_SuikenSpawn()
    {
        transform.position = new Vector3(-1.5f, -6.3f, 0);
        Instantiate(surikenPrefab, transform.position, Quaternion.identity);
    }

    public void X_SuikenSpawn()
    {
        transform.position = new Vector3(1.5f, -6.3f, 0);
        Instantiate(surikenPrefab, transform.position, Quaternion.identity);
    }
}
