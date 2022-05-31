using UnityEngine;


namespace Gravity2DTest
{
    public class MovementControls : MonoBehaviour
    {
        static string horizontalAxisName = "HorizontalAxis";
        static string verticalAxisName = "VerticalAxis";


        public static string GetHorizontalAxisName()
        {
            return horizontalAxisName;
        }
        public static string GetVerticalAxisName()
        {
            return verticalAxisName;
        }
    }
}
