using UnityEngine;

public class Elevator : MonoBehaviour
{
    private SliderJoint2D _sliderJoint;

    [SerializeField]
    private float heightMax = 6.9f;
    [SerializeField]
    private float heightMin = 1.42f;

    [SerializeField]
    private float speed = -3f;

    void Start()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();

        JointMotor2D motor = _sliderJoint.motor;
        motor.motorSpeed = speed;
    }

    void Update()
    {
        if (transform.position.y >= heightMax || transform.position.y <= heightMin)
        {
            JointMotor2D motor = _sliderJoint.motor;
            motor.motorSpeed *= -1;
            _sliderJoint.motor = motor;
        }
    }
}
