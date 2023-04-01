using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Mouse mouse;

    private NavMeshAgent agent;
    private Rigidbody rb;

    private EquipmentHandler equipmentHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        equipmentHandler = new EquipmentHandler();
    }

    void Update()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        mouse = Mouse.current;
        if (mouse.leftButton.IsPressed())
        {
            RaycastHit hit;
            if (CameraManager.instance.GetMouseClickPos(out hit, mouse))
            {
                SelectMouseAction(hit);
            }
        }
    }

    private void SelectMouseAction(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Ground"))
        {
            Move(hit.point);
        }

        else if (hit.collider.CompareTag("Enemy"))
        {
            Debug.Log("Attacking");
        }
    }

    private void Move(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}


