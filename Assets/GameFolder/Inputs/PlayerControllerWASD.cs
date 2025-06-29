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
    private bool _canMove = true;

    public bool IsStealth;
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

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
        CheckStealth();

        //MovePlayer();
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

        if (_canMove)
        {
            Vector3 movement = new Vector3(_move.x, 0f, _move.y);

            transform.Translate(movement * speed * SpeedMultiplyer * Time.deltaTime, Space.World);
        }
    }

    private void CheckStealth()
    {
        if (IsStealth)
        {
            StartCoroutine(ResetStealth());
        }
    }

    private IEnumerator ResetStealth()
    {
        yield return new WaitForSeconds(4);

        IsStealth = false;
    }

    //public void MovePlayer()
    //{
    //    Vector3 movement = new Vector3(_move.x, 0f, _move.y);

    //    if(movement != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
    //    }

    //    transform.Translate(movement * speed * SpeedMultiplyer * Time.deltaTime, Space.World);
    //}
}
