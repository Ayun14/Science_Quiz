using UnityEngine;

public class SurikenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject surikenPrefab;

    public void O_SuikenSpawn()
    {
        Debug.Log("厘局拱 积己");
        transform.position = new Vector3(-1.5f, -6.3f, 0);
        Instantiate(surikenPrefab, transform.position, Quaternion.identity);
    }

    public void X_SuikenSpawn()
    {
        Debug.Log("厘局拱 积己");
        transform.position = new Vector3(1.5f, -6.3f, 0);
        Instantiate(surikenPrefab, transform.position, Quaternion.identity);
    }
}
