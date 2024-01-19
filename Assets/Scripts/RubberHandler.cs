using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class RubberHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _stripPositions;
    [SerializeField] private LineRenderer[] _lineRenderers;
    [SerializeField] private MouseHandler _mouseHandler;
    [SerializeField] private Transform _idleTransform;
    [SerializeField] private ProjectileSpawner _projectileSpawner;

    public event UnityAction OnRubberRelease;

    private bool _isCanDrop = true;

    private void Start()
    {
        ResetStrips();
    }

    public void Pull()
    {
        if (_isCanDrop)
        {
            SetStrips(1, _mouseHandler.DragAndDrop());
            SetProjectilePosition(_mouseHandler.DragAndDrop());
        }
    }

    public void Release()
    {
        ResetStrips();
        OnRubberRelease?.Invoke();
    }

    private void SetProjectilePosition(Vector3 position)
    {
        var projectile = FindObjectOfType<CurrentProjectile>();
        projectile.transform.position = position;
        projectile.transform.right = _idleTransform.position - projectile.transform.position;
    }

    private void SetStrips(int index, Vector3 position)
    {
        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            _lineRenderers[i].SetPosition(index, position);
        }
    }

    private void SetStrips(int index, Transform[] positions)
    {
        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            _lineRenderers[i].SetPosition(index, positions[i].position);
        }
    }

    private void ResetStrips()
    {
        SetStrips(0, _stripPositions);
        SetStrips(1, _stripPositions);
    }

    private void ChangeState()
    {
        _isCanDrop = false;
    }

    private void OnEnable()
    {
        _projectileSpawner.OnProjectilesOut += ChangeState;
    }

    private void OnDisable()
    {
        _projectileSpawner.OnProjectilesOut -= ChangeState;
    }
}
