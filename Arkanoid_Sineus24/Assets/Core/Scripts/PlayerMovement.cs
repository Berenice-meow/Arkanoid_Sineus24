using UnityEngine;

namespace Arkanoid_Sineus24
{
    public class PlayerMovement : MonoBehaviour
    {
        private Transform playerTransform;

        private float speed = 10f;
        private float boundaryX = 8f;

        protected void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            var conditionRightBoundary = inputHorizontal > 0 && transform.position.x < boundaryX;
            var conditionLeftBoundary = inputHorizontal < 0 && transform.position.x > -boundaryX;

            if (conditionRightBoundary || conditionLeftBoundary)
            {
                transform.Translate(Vector3.right * inputHorizontal * speed * Time.deltaTime);
            }
        }
    }
}
