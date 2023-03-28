using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public float yHeightOffset = 80f;
    public float zHeightOffset = -30f;
    public float xAngle = 65f;
    [SerializeField] private GameObject player;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yHeightOffset, player.transform.position.z + zHeightOffset);
        transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);
    }

    public bool GetMouseClickPos(out RaycastHit hit, Mouse mouse)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mouse.position.ReadValue()), out hit))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
