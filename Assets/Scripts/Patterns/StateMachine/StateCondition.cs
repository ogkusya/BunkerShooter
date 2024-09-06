public abstract class StateCondition : ICondition
{
    public abstract bool IsConditionSuccessed(); //Condition

    public virtual void OnTick() //Called every frame
    {
    }
    public virtual void OnTick(float deltatime) //Called every frame
    {
    }

    public virtual void OnStateEntered() //Enter condition
    {
    }

    public virtual void OnStateExited() //Exit condition
    {
    }
}
