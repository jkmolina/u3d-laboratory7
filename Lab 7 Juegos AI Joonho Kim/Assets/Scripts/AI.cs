using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    public GameObject[] waypoints;
    private int currWO = 0;

    private float maxWaittime = 5.0f;
    private float currWaittime = 0.0f;
    void Start()
    {

      //  agent = GetComponent<NavMeshAgent>();
        if (agent && waypoints.Length > 0)
            agent.SetDestination(waypoints[currWO].transform.position);
        //waypoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {

        if (agent)
        {
            if (agent.remainingDistance < 0.5f)
            {
                currWaittime += Time.deltaTime;
                if (currWaittime >= maxWaittime)
                {
                    //esto aumenta el tiempo de espera 
                    currWaittime = 0.0f;
                    //currWO++;
                    //currWO %= waypoints.Length;

                    //esto es para que no que los waypoints sean random 
                    int temp = currWO;
                    do
                    {
                        currWO = Random.Range(0, waypoints.Length);

                    }
                    while (currWO == temp);


                    //para sumarle uno y darle el valor 
                    agent.SetDestination(waypoints[currWO].transform.position);
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carl"))
        {
            Debug.Log("you died");
            Destroy(other.gameObject);
        }

    }
}