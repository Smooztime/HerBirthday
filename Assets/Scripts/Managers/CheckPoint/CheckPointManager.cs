using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instance { get; private set; }
    private Vector3 lastCheckpointPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cake;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    public void LoadCheckpoint()
    {
        player.transform.position = lastCheckpointPosition+new Vector3(0f,1f,0f);
        cake.SetParent(player.transform.GetChild(1));
        cake.position = player.transform.GetChild(1).position + new Vector3(0f, 0.2f, 0f);
        cake.rotation = Quaternion.Euler(0f,0f,0f);
        cake.GetComponent<Cake>().ResetRigidbody();
        Debug.Log("Load check point");

    }

}
