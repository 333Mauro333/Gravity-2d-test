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

            //Debug.Log(Camera.main.WorldToViewportPoint(transform.position));
            Debug.Log(Camera.main.WorldToViewportPoint(sR.bounds.max));
        }


        void SetBorderLimits()
        {
            CheckTopLimit();
            CheckBotLimit();
            CheckLeftLimit();
            CheckRightLimit();

            Debug.Log("Tamaño de la camara en pixeles: " + Camera.main.pixelRect.size);
            Debug.Log("Tamaño de la camara en viewport: " + Camera.main.ScreenToViewportPoint(Camera.main.pixelRect.size));
        }

        bool ExceededTopLimit()
        {
            return Camera.main.WorldToViewportPoint(sR.bounds.max).y > 1.0f;
        }
        bool ExceededBotLimit()
        {
            return Camera.main.WorldToViewportPoint(sR.bounds.min).y < 0.0f;
        }
        bool ExceededLeftLimit()
        {
            return Camera.main.WorldToViewportPoint(sR.bounds.min).x < 0.0f;
        }
        bool ExceededRightLimit()
        {
            return Camera.main.WorldToViewportPoint(sR.bounds.max).x > 1.0f;
        }


        #region CHECK INDIVIDUAL LIMITS

        void CheckTopLimit()
        {
            if (ExceededTopLimit())
            {
                float topCamera = Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.size).y;
                float spriteHeight = sR.bounds.size.y;

                transform.position = new Vector3(transform.position.x, topCamera - spriteHeight / 2.0f, transform.position.z);
            }
        }
        void CheckBotLimit()
        {
            if (ExceededBotLimit())
            {
                float botCamera = -Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.size).y;
                float spriteHeight = sR.bounds.size.y;

                transform.position = new Vector3(transform.position.x, botCamera + spriteHeight / 2.0f, transform.position.z);
            }
        }
        void CheckLeftLimit()
        {
            if (ExceededLeftLimit())
            {
                float leftCamera = -Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.size).x;
                float spriteWidth = sR.bounds.size.x;

                transform.position = new Vector3(leftCamera + spriteWidth / 2.0f, transform.position.y, transform.position.z);
            }
        }
        void CheckRightLimit()
        {
            if (ExceededRightLimit())
            {
                float rightCamera = Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.size).x;
                float spriteWidth = sR.bounds.size.x;

                transform.position = new Vector3(rightCamera - spriteWidth / 2.0f, transform.position.y, transform.position.z);
            }
        }

        #endregion
    }
}
