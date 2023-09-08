using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ArrowBehaviour : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private NavMeshAgent[] _arrows;
    [SerializeField] private Transform _player;

    [SerializeField] private float _offset = 4f;
    [SerializeField] private float _stepDelay = 1f;
    [SerializeField] private float _bunchDelay = 15f;
    [SerializeField] private float _arrowSpeed = 1f;
    private bool reachedTarget;
    private void Start()
    {
        
    }    
    public void PlaceObjectNearPlayer(Transform obj)
    {
        obj.position = _player.position + _player.forward * _offset * 0.3f + Vector3.up;
    }
    public void SetTarget(Transform target)
    {
        _target = target;
        PositionArrowsInSequence();
    }
    private void PositionArrowsInSequence()
    {
        StopAllCoroutines();
        StartCoroutine(PlaceArrows());
        StartCoroutine(UpdateArrowsInSequence());
    }

    private IEnumerator PlaceArrows()
    {
        foreach (NavMeshAgent n in _arrows)
        {
            n.gameObject.SetActive(false);
        }
        _arrows[0].gameObject.SetActive(true);
        _arrows[0].transform.position = _player.position + _player.forward * _offset;
        _arrows[0].speed = _arrowSpeed;
        _arrows[0].SetDestination(_target.position);
        yield return new WaitForSeconds(_stepDelay);
        _arrows[0].speed = 0f;
        
        for (int i = 1; i < _arrows.Length; i++)
        {
            _arrows[i].gameObject.SetActive(true);
            _arrows[i].transform.position = _arrows[i - 1].transform.position + _arrows[i - 1].transform.forward * _offset;
            _arrows[i].speed = _arrowSpeed;
            _arrows[i].SetDestination(_target.position);
            yield return new WaitForSeconds(_stepDelay);
            _arrows[i].speed = 0f;
        }
    }
    IEnumerator UpdateArrowsInSequence()
    {
        yield return new WaitForSeconds(_bunchDelay);
        while (!reachedTarget)
        {
            StartCoroutine(PlaceArrows());
            yield return new WaitForSeconds(_bunchDelay);
        }
    }
    private void PositionArrowsAroundPlayer()
    {
        
    }

}
