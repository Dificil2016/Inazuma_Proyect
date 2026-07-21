using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    public CharaInstance charaInstance;

    public PlayerController controller;

    Vector3 startPos;

    bool attacking;
    bool hasBall;
    Vector3 currentBallPos;

    private Vector3 desiredPosition;
    private List<Vector3> allCompanionPos;

    private CharaMoveState currentState;

    internal void Setup(CharaInstance instance, PlayerController playerController)
    {
        controller = playerController;
        charaInstance = instance;
        startPos = transform.position;
    }

    public virtual void CharaPlayUpdate()
    {
        attacking = (MatchGameManager.Instance.ControllerWithBall() == controller);
        hasBall = MatchGameManager.Instance.CharaHasBall(this);
        currentBallPos = MatchGameManager.Instance.ballController.transform.position;
        allCompanionPos = new List<Vector3>(controller.AllNearAlliesCharasPos(this));

        desiredPosition = CalculateDesiredPosition();

        MoveTowards(desiredPosition);
    }

    private Vector3 CalculateDesiredPosition()
    {
        switch (currentState)
        {
            case CharaMoveState.freeMove:
                return CalculateFreeMovement();

            case CharaMoveState.recivingOrder:
                return transform.position;

            case CharaMoveState.followOrder:
                return CalculateFollowingOrder();
        }

        return transform.position;
    }

    private Vector3 CalculateFollowingOrder()
    {
        throw new NotImplementedException();
    }

    private Vector3 CalculateFreeMovement()
    {
        Vector3 target = startPos;

        if (hasBall)
        { target += CalculateAttack(); }
        else
        { target += CalculateBallOffset(); }
        
        target += CalculateCompanionSeparation(target);

        return target;
    }

    private Vector3 CalculateBallOffset()
    {
        Vector3 ballPos = currentBallPos;

        Vector3 center = MatchGameManager.Instance.transform.position;

        Vector3 offset = ballPos - center;

        offset *= 0.35f;

        return offset;
    }
    private Vector3 CalculateAttack()
    {
        Vector3 offset = controller.fieldData.rivalGoalKeeper.transform.position;

        return offset;
    }
    private Vector3 CalculateCompanionSeparation(Vector3 currentTarget)
    {
        Vector3 offset = Vector3.zero;

        foreach (Vector3 pos in allCompanionPos)
        {
            Vector3 diff = currentTarget - pos;

            float distance = diff.magnitude;

            if (distance < 2f)
            {
                offset += diff.normalized * (2f - distance);
            }
        }

        return offset;
    }

    private void MoveTowards(Vector3 target)
    {
        float speed = charaInstance.GetStatsByLevel().speed;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}

enum CharaMoveState
{
    freeMove, recivingOrder, followOrder
}
