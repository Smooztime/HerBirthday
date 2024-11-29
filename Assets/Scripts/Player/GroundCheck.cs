using System.Linq;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float alignSpeed;

    private PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        GroundCheckRay();
    }
    private void GroundCheckRay()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 5f, mask))
        {
            Debug.Log("hit");
            AlignWithGround(hit);
            player.SetRotateControl(false);
        }
        else
        {
            Debug.Log("Eh");
            float currentZAngle = transform.eulerAngles.z;
            float newZAngle = Mathf.LerpAngle(currentZAngle, 0f, alignSpeed * Time.deltaTime);
            player.SetRotateControl(true);
            transform.rotation = Quaternion.Euler(0f, player.PlayerRotate, newZAngle);
        }
    }

    private void AlignWithGround(RaycastHit hit)
    {
        float targetAngle = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
        float currentZAngle = transform.eulerAngles.z;
        float newZAngle = Mathf.LerpAngle(currentZAngle, -targetAngle, alignSpeed * Time.deltaTime);

        Vector3 targetLookAt = hit.transform.forward;
        Quaternion lookAt = Quaternion.LookRotation(targetLookAt);

        transform.rotation = lookAt * Quaternion.Euler(0f, 0f, newZAngle);

        if(mask == LayerMask.NameToLayer("Ground"))
        {
            
        }
    }
}
