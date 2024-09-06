using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCondition : StateCondition
{
    private readonly float _time;

    private float currentTime;

    public TemporaryCondition(float time)
    {
        _time = time;
    }

    public override bool IsConditionSuccessed()
    {
        return currentTime >= _time;
    }

    public override void OnStateEntered()
    {
        currentTime = 0;
    }

    public override void OnTick(float deltatime)
    {
        currentTime += deltatime;
    }
}
