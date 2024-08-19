using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private string stopperTag;

    private SliderJoint2D _sliderJoint;

    void Start()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();

        JointMotor2D motor = _sliderJoint.motor;
    }

    /// <summary>
    /// Switches direction of elevator
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(stopperTag))
        {
            JointMotor2D motor = _sliderJoint.motor;
            motor.motorSpeed *= -1;
            _sliderJoint.motor = motor;
        }
    }
}
