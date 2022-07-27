using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private const float G = 9.8f;

    [SerializeField]
    private float _fallSpeed = 1f;

    [SerializeField]
    private float _jumpForce = 1f;

    private bool _simulate = false;
    private float _fallVelocity = 0f;
    private float _flyVelocity = 0f;

    private void FixedUpdate()
    {
        if (!_simulate)
            return;

        _fallVelocity += G * Time.fixedDeltaTime;

        if (_flyVelocity > 0)
            _flyVelocity -= G * Time.fixedDeltaTime;

        Vector3 fallTranslation = Vector3.down * _fallVelocity * _fallSpeed * Time.fixedDeltaTime;
        Vector3 flyTranslation = Vector3.up * _flyVelocity * _fallSpeed * Time.fixedDeltaTime;

        transform.Translate(fallTranslation + flyTranslation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _simulate = true;
            _fallVelocity = 0f;
            _flyVelocity = _jumpForce - _fallSpeed;
        }
    }
}
