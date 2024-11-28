using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SOs/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public float playerSpeed;
    public float sensitivity;
    public float balanceSpeed;
}
