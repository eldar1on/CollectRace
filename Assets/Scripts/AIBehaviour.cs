using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    NavMeshAgent _agent;

    public GameObject _platform;
    public List<Obstacle> _obs;

    public Transform _Checker;
    public int dressEncounter;


    public enum AIState
    {
        SearchDress,
        GoingToCheck
    }
    public AIState _state;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();



        for (int i = 0; i < _platform.transform.childCount; i++)
        {
            _obs.Add(_platform.transform.GetChild(i).GetComponent<Obstacle>());
        }
    }

    void Start()
    {
        SelectNextMove();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle" && _state == AIState.SearchDress)
        {
            dressEncounter++;
            if(dressEncounter % 7 == 0)
            {
                CheckDress();
                return;
            }
            SelectNextMove();
        }
        else if (other.gameObject.tag == "CheckAI" && _state == AIState.GoingToCheck)
        {
            SelectNextMove();
        }
    }

    public void CheckDress()
    {
        _state = AIState.GoingToCheck;
        _agent.SetDestination(_Checker.position);
    }

    public void SelectNextMove()
    {
        _state = AIState.SearchDress;

        int rng = Random.Range(0, _obs.Count);
        Vector3 navigationVector = _obs[rng].transform.position;
        _agent.SetDestination(navigationVector);
    }
}
