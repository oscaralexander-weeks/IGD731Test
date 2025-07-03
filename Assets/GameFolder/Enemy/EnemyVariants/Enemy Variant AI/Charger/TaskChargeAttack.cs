using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
public class TaskChargeAttack : Node
{
    private float dashDuration = 0.3f;
    private float dashSpeed = 10f;
    private float cooldownTime = 1f;
    private float detectionRange = 5f;
    private float minimumDashRange = 1f;

    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isDashing = false;

    private Transform _transform;

    public TaskChargeAttack(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        //start dash cooldown
        if (!isDashing && cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
            
        Transform target = (Transform)t;

        //calculate distance between enemy and player to determine if in range to dash
        float distance = Vector3.Distance(_transform.position, target.position);

        if (isDashing)
        {
            Debug.Log("dash");
            dashTimer -= Time.deltaTime;
            MoveTowards(target.position, dashSpeed);

            if (dashTimer < 0.01f)
            {
                isDashing = false;
                cooldownTimer = cooldownTime;
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.RUNNING;
            return state;
        }

        //intiate dash sequence if in range and not on cooldown
        if (cooldownTimer < 0.01f && distance < detectionRange && distance > minimumDashRange)
        {
            isDashing = true;
            dashTimer = dashDuration;
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

    private void MoveTowards(Vector3 targetPosition, float speed)
    {
        Vector3 dir = (targetPosition - _transform.position).normalized;
        _transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}

