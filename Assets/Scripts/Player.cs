using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Mouse mouse;
    public Vector3 mouseWorldPos;

    private NavMeshAgent agent;
    private Rigidbody rb;
    private float moveSpeed = 40f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GetMoveInput();
    }

    public void GetMoveInput()
    {
        mouse = Mouse.current;
        if (mouse.leftButton.IsPressed())
        {
            RaycastHit hit;
            if (CameraManager.instance.GetMouseClickPos(out hit, mouse))
            {
                Move(hit.point);
            }
        }
    }

    private void Move(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}


