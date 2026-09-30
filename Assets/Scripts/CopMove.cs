using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    public float updateFreq = 0.5f;
    float freq = 0f;

    void Start()
    {
        Pursue();
    }


    void Update()
    {
        freq += Time.deltaTime;
        if (freq > updateFreq)
        {
            Pursue();
            freq -= updateFreq;
        }        
    }

    void Seek(Vector3 pos)
    {
        agent.destination = pos; 
    }

    void Pursue()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float lookAhead = targetDir.magnitude / agent.speed;
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }
}
