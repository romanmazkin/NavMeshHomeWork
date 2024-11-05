using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private const int RightMouseButton = 1;

    [SerializeField] private float _healthValue;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CharacterView _view;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Health _health;
    [SerializeField] private LayerMask _mask;

    private float _deadZone = 0.1f;
    private Vector3 _input;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _health.Value = _healthValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(RightMouseButton) == false)
            return;

        if (Physics.Raycast(GetRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _mask.value))
            _agent.SetDestination(hit.point);
    }

    private void FixedUpdate()
    {
        if (_health.Value == 0)
        {
            _view.DeathAnimation();
            Debug.Log("Dead");
        }

        if (_input.magnitude > _deadZone)
        {
            _view.StartRunning();
        }
        else
        {
            _view.StopRunning();
        }
    }

    private Ray GetRay(Vector3 position) => _camera.ScreenPointToRay(position);
}