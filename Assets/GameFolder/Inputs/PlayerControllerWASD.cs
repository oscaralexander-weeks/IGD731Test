using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerWASD : MonoBehaviour
{
    public float speed;
    private Vector2 _move, _mouseLook;
    private Vector3 _rotationTarget;

    public bool canMove;

    private PrimaryFire _primaryFire;
    private SecondaryShoot _secondaryFire;

    void Start()
    {
        _primaryFire = GetComponent<PrimaryFire>();
        _secondaryFire = GetComponent<SecondaryShoot>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }

    public void OnShoot2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot2();
        }
    }

    public void Shoot()
    {
        if (_primaryFire != null)
        {
            _primaryFire.LeftClickShoot();
        }
    }

    public void Shoot2()
    {
        if(_secondaryFire != null)
        {
            _secondaryFire.Shoot();
        }
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

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
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

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }


    }
}
