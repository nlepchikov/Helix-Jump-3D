using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{

    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _length;

    private Ball _ball;
    private Beam _beam;

    private Vector3 _cameraPos;
    private Vector3 _minimumBallPos;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPos = _ball.transform.position;
        _minimumBallPos = _ball.transform.position;

        TrackBall();
    }

    private void Update()
    {
        //if (_ball.transform.position.y < _minimumBallPos.y)
        {
            TrackBall();
            _minimumBallPos = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPos = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPos -= direction * _length;
        transform.position = _cameraPos;
        transform.LookAt(_ball.transform);
    }
}
