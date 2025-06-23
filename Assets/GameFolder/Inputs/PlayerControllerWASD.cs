using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerWASD : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float SpeedMultiplyer = 1;
    private Vector2 _move, _mouseLook;
    private Vector3 _rotationTarget;
    public bool canMove;

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mouseLook);
        

        if (Physics.Raycast(ray, out hit))
        {
            _rotationTarget = hit.point;
        }

        MovePlayerWithAim();

        //MovePlayer();

    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0f, _move.y);

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * SpeedMultiplyer * Time.deltaTime, Space.World);
    }

    public void MovePlayerWithAim()
    {
        var lookPosition = _rotationTarget - transform.position;
        lookPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookPosition);

        Vector3 aimDirection = new Vector3(_rotationTarget.x, 0f, _rotationTarget.z);

        if(aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        if (canMove)
        {
            Vector3 movement = new Vector3(_move.x, 0f, _move.y);

            transform.Translate(movement * speed * SpeedMultiplyer * Time.deltaTime, Space.World);
        }


    }
}
