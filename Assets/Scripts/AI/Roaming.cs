using UnityEngine;
using UnityEngine.AI;

public class Roaming : State
{
    public Roaming(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.ROAMING;
    }

    public override void Enter()
    {
        // How many location to patrol
        int locationQuantity = EnemyClass._observeLocation.Count;

        // We gonna go there
        Agent.SetDestination(SearchWaypoint(locationQuantity));

        base.Enter();
    }

    public override void Update()
    {
        // If remaining distance is less than 0.5m
        // Set NextState to Idle
        // And Change Stage to Exit
        if(Agent.remainingDistance < .5f)
        {
            NextState = new Idle(EnemyClass, Agent);
            Stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private Vector3 SearchWaypoint(int locationQuantity)
    {
        //Random Point of interests
        int index = Random.Range(0, locationQuantity);

        // Set estimate destination
        Vector3 destination = EnemyClass._observeLocation[index].position;

        // Find if NavMesh exist on that position or not
        // If not find the closest one
        // If there's no closest random another point
        NavMeshHit hit;
        if(NavMesh.SamplePosition(destination, out hit, 1.0f, NavMesh.AllAreas))
        {
            destination = hit.position;
        }
        else destination = SearchWaypoint(locationQuantity);

        return destination;
    }
}
