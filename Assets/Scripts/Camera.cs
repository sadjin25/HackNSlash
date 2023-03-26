using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float yHeightOffset = 80f;
    public float zHeightOffset = -30f;
    public float xAngle = 65f;
    [SerializeField] private GameObject player;


    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeightOffset, player.transform.position.z + zHeightOffset);
        transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);
    }
}
