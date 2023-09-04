using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ArrowBehaviour : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private NavMeshAgent[] _arrows;
    private Transform _player;

    [SerializeField] private float _offset = 4f;
    [SerializeField] private float _stepDelay = 1f;
    [SerializeField] private float _arrowSpeed = 1f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        SetTarget(GameObject.Find("Sphere").transform);
    }
    public void SetTarget(Transform target)
    {
        _target = target;
        foreach (NavMeshAgent n in _arrows)
        {
            n.SetDestination(_target.position);            
        }
        PositionArrowsInSequence();
    }
    private void PositionArrowsInSequence()
    {
        StartCoroutine(PlaceArrows());
    }
    private IEnumerator PlaceArrows()
    {
        _arrows[0].gameObject.SetActive(true);
        _arrows[0].transform.position = _player.position + _player.forward * _offset;
        _arrows[0].speed = _arrowSpeed;
        yield return new WaitForSeconds(_stepDelay);
        _arrows[0].speed = 0f;
        
        for (int i = 1; i < _arrows.Length; i++)
        {
            _arrows[i].gameObject.SetActive(true);
            _arrows[i].transform.position = _arrows[i - 1].transform.position + _arrows[i - 1].transform.forward * _offset;
            _arrows[i].speed = _arrowSpeed;
            yield return new WaitForSeconds(_stepDelay);
            _arrows[i].speed = 0f;
        }
    }
    private void PositionArrowsAroundPlayer()
    {
        
    }

}
