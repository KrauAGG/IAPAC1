using System;
using UnityEngine;
using Unity.Muse.Behavior;
using Action = Unity.Muse.Behavior.Action;

[Serializable]
[NodeDescription(name: "Stop", story: "Stops the agent", category: "Action/Move", id: "37d14153df25444624d82be524a73527")]
public class Stop : Action
{
    public BlackboardVariable<GameObject> Agent;
    private UnityEngine.AI.NavMeshAgent m_NavMeshAgent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        m_NavMeshAgent = Agent.Value.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        if (m_NavMeshAgent != null)
        {
            m_NavMeshAgent.isStopped = true;
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

