using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Muse.Behavior;

[Serializable]
[Condition(name: "farAway", story: "d(cop, robber) > 5", category: "distances", id: "bc032ce09737b7062dca7f01eaba3690")]
public class farAway : Condition
{
    public BlackboardVariable<GameObject> Agent;
    public BlackboardVariable<GameObject> Target;
    public override bool IsTrue()
    {
        return Vector3.Distance(
            Agent.Value.transform.position,
            Target.Value.transform.position) > 5f;
    }
}
