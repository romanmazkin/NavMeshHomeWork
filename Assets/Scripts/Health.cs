using UnityEngine;

public class Health: MonoBehaviour
{
    public float Value { get; set; }

    public void TakeDamage(float damage)
    {
        if (Value < 0)
        {
            Value = 0;
        }
        else
        {
            Value -= damage;
        }
    }
}
