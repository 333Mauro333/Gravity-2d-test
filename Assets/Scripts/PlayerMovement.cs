using UnityEngine;


namespace Gravity2DTest
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Speed configuration")]
        [SerializeField] float horizontalSpeed = 0.0f;
        [SerializeField] float verticalSpeed = 0.0f;



        void Update()
        {
            Movement();
        }



        void Movement()
        {
            float xS = Input.GetAxis(AxisNames.GetHorizontalAxisName());
            float vS = Input.GetAxis(AxisNames.GetVerticalAxisName());


            transform.position += new Vector3(xS * horizontalSpeed, vS * verticalSpeed) * Time.deltaTime;
        }

        void HorizontalMove()
        {

        }
    }
}
