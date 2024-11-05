using UnityEngine;

public class Mover 
{
    private float _speed;
    private CharacterController _characterController;

    public Mover(float speed, CharacterController characterController)
    {
        _speed = speed;
        _characterController = characterController;
    }

    public void MoveTo(Vector3 direction)
    {
            Vector3 velocity = direction.normalized * _speed;

            _characterController.Move(velocity * Time.deltaTime);
    }
}