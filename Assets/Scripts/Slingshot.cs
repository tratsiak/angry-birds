using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private RubberHandler _rubberHandler;
    [SerializeField] private float _force;

    private bool isMouseDown;

    private void Update()
    {
        if (isMouseDown)
        {
            _rubberHandler.Pull();
        }
    }

    private void Shoot()
    {
        var projectile = FindObjectOfType<CurrentProjectile>();
        var rigidbody = projectile.GetComponent<Rigidbody2D>();

        rigidbody.isKinematic = false;
        rigidbody.AddForce(projectile.transform.right * _force, ForceMode2D.Impulse);
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        _rubberHandler.Release();
    }

    private void OnEnable()
    {
        _rubberHandler.OnRubberRelease += Shoot;
    }

    private void OnDisable()
    {
        _rubberHandler.OnRubberRelease -= Shoot;
    }
}
