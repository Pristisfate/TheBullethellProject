using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -_speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed, 0, 0);
        }
    }
}
