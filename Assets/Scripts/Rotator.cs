using UnityEngine;

public class Rotator
{
    private Transform _transform;
    private float _rotationSpeed;

    public Rotator(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void RotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);

        float step = _rotationSpeed * Time.deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
