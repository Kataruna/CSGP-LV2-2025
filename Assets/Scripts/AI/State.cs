using System;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Struct class for each state of an enemy AI
/// </summary>
public class State
{
    /// <summary>
    /// Event for other function 
    /// to trigger when State is changed
    /// </summary>
    public event Action OnStateChanged;

    /// <summary>
    /// Name of every state
    /// </summary>
    public enum STATE
    {
        IDLE,
        ROAMING,
        BATTLE
    }

    /// <summary>
    /// Order of execution
    /// </summary>
    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public STATE Name;

    protected EVENT Stage;
    protected Enemy EnemyClass;
    protected NavMeshAgent Agent;

    protected State NextState;

    /// <summary>
    /// Class constructor to properly initialize state class
    /// </summary>
    /// <param name="enemy">Enemy itself</param>
    /// <param name="agent">Pathfinding AI</param>
    public State(Enemy enemy, NavMeshAgent agent)
    {
        EnemyClass = enemy;
        Agent = agent;

        Stage = EVENT.ENTER;
    }

    /// <summary>
    /// What to do on Enter this stage
    /// </summary>
    public virtual void Enter()
    {
        Stage = EVENT.UPDATE;
    }

    /// <summary>
    /// What to do while in this stage. Including condition to change stage.
    /// *You need to Implement 'Stage = EVENT.EXIT' on Stage Change*
    /// </summary>
    public virtual void Update()
    {
        Stage = EVENT.UPDATE;
    }

    /// <summary>
    /// What to do on Exit this stage (Wrap up)
    /// </summary>
    public virtual void Exit()
    {
        Stage = EVENT.UPDATE;
    }

    /// <summary>
    /// Process the logic in Every state
    /// *Due to State doesn't have auto process. It has to be executed
    /// by another class with MonoBehaviour*
    /// </summary>
    /// <returns>State to execute</returns>
    public State Process()
    {
        if(Stage == EVENT.ENTER)
        {
            Enter();
        }

        if(Stage == EVENT.UPDATE)
        {
            Update();
        }

        if(Stage == EVENT.EXIT)
        {
            Exit();
            OnStateChanged?.Invoke();

            return NextState;
        }

        return this;
    }
}
