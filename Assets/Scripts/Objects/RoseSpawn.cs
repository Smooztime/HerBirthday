using UnityEngine;

public class RoseSpawn : MonoBehaviour
{
    [SerializeField] GameObject rosePrefab;
    [SerializeField] Transform topLeft;
    [SerializeField] Transform bottomRight;
    [SerializeField] float spacing = 1.0f;

    void Start()
    {
        FillWithRoses();
    }

    void FillWithRoses()
    {
        if (rosePrefab == null || topLeft == null || bottomRight == null)
        {

            return;
        }


        Vector3 topLeftPos = topLeft.position;
        Vector3 bottomRightPos = bottomRight.position;


        float width = Mathf.Abs(bottomRightPos.x - topLeftPos.x);
        float height = Mathf.Abs(topLeftPos.z - bottomRightPos.z);


        for (float x = 0; x <= width; x += spacing)
        {
            for (float z = 0; z <= height; z += spacing)
            {
                Vector3 basePosition = new Vector3(topLeftPos.x + x, topLeftPos.y, topLeftPos.z - z);
                Vector3 randomOffset = new Vector3(
                    Random.Range(-1, 1),
                    Random.Range(-1, 1)
                );
                Vector3 spawnPosition = basePosition + randomOffset;
                GameObject rose = Instantiate(rosePrefab, spawnPosition, Quaternion.identity);
                Destroy(rose, 10f);
            }
        }
    }
}


