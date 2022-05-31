using UnityEngine;


namespace Gravity2DTest
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class LimitToScreen : MonoBehaviour
    {
        SpriteRenderer sR;


        void Awake()
        {
            sR = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            SetBorderLimits();
        }


        void SetBorderLimits()
        {
            CheckTopLimit();
            CheckBotLimit();
            CheckLeftLimit();
            CheckRightLimit();
        }

        bool ExceededTopLimit()
        {
            return Camera.main.WorldToScreenPoint(sR.bounds.max).y > Camera.main.pixelHeight;
        }
        bool ExceededBotLimit()
        {
            return Camera.main.WorldToScreenPoint(sR.bounds.min).y < 0;
        }
        bool ExceededLeftLimit()
        {
            return Camera.main.WorldToScreenPoint(sR.bounds.min).x < 0;
        }
        bool ExceededRightLimit()
        {
            return Camera.main.WorldToScreenPoint(sR.bounds.max).x > Camera.main.pixelWidth;
        }


        #region CHECK INDIVIDUAL LIMITS

        void CheckTopLimit()
        {
            if (ExceededTopLimit())
            {
                Debug.Log("Se me fue para arriba.");
                //float topCamera = Camera.main.pixelHeight;

                //transform.position = new Vector3(transform.position.x, Camera.main.WorldToScreenPoint(sR.bounds.max).y - Camera.main.WorldToScreenPoint(sR.sprite.bounds.size).y / 2.0f);
            }
        }
        void CheckBotLimit()
        {
            if (ExceededBotLimit())
            {
                Debug.Log("Se pasó para abajo.");
            }
        }
        void CheckLeftLimit()
        {
            if (ExceededLeftLimit())
            {
                Debug.Log("Se fue para la izquierda.");
            }
        }
        void CheckRightLimit()
        {
            if (ExceededRightLimit())
            {
                Debug.Log("Se exhedió para la derecha.");
            }
        }

        #endregion
    }
}
