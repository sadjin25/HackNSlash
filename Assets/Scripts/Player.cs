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

    public EquipmentHandler equipmentHandler;
    public PlayerInvHolder invHolder;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        equipmentHandler = gameObject.AddComponent<EquipmentHandler>();
        invHolder = gameObject.GetComponent<PlayerInvHolder>();
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

        else if (hit.collider.CompareTag("Item"))
        {
            var lootable = hit.collider.GetComponent<ILootable>();
            if (lootable != null)
            {
                lootable.LootItem(this, invHolder);
            }
        }
    }

    private void Move(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

}


