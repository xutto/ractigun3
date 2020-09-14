using System.Collections.Generic;
using UnityEngine;

namespace game.player
{
    public class PlayerControl : MonoBehaviour
    {
        public float speed;
        private new Rigidbody2D rigidbody;
        private UnityEngine.Vector2 moveVelocity;

        private Animator animator;

        private Camera mainCamera;

        public int number;

        public PlayerControl(float speed, Rigidbody2D rigidbody, Vector2 moveVelocity)
        {
            this.speed = speed;
            this.rigidbody = rigidbody;
            this.moveVelocity = moveVelocity;
        }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            //movement with camera limits
            Movement(moveHorizontal, moveVertical);

            //horizontal movement by animation
            animHorizontal(moveHorizontal);
        }

        private void Movement(float moveHorizontal, float moveVertical)
        {
            Dictionary<string, float> cameraLimits = GetCameraLimits();

            if (moveHorizontal > 0 && transform.position.x < cameraLimits["limitCameraX"])
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right * moveHorizontal);
            }

            if (moveHorizontal < 0 && transform.position.x > cameraLimits["limitCameraX"] * -1)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right * moveHorizontal);
            }

            if (moveVertical > 0 && transform.position.y < cameraLimits["limitCameraY"])
            {
                transform.Translate(speed * Time.deltaTime * Vector2.up * moveVertical);
            }

            if (moveVertical < 0 && transform.position.y > cameraLimits["limitCameraY"] * -1)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.up * moveVertical);
            }

        }

        private Dictionary<string, float> GetCameraLimits()
        {

            Dictionary<string, float> mapLimits = new Dictionary<string, float>();

            float aspect = mainCamera.aspect;
            float verticalSize = mainCamera.orthographicSize * 2;
            float horizontalSize = aspect * verticalSize;

            float limitCameraX = mainCamera.transform.position.x + horizontalSize / 2;
            float limitCameraY = mainCamera.transform.position.y + verticalSize / 2;

            mapLimits.Add("limitCameraX", limitCameraX);
            mapLimits.Add("limitCameraY", limitCameraY);

            return mapLimits;
        }


        private void FixedUpdate()
        {

        }

        private void animHorizontal(float moveHorizontal)
        {
            if (moveHorizontal > 0)
            {
                animator.SetBool("isTurnRigth", true);
                animator.SetBool("isTurnLeft", false);
            }

            if (moveHorizontal < 0)
            {
                animator.SetBool("isTurnLeft", true);
                animator.SetBool("isTurnRigth", false);
            }

            if (moveHorizontal == 0)
            {
                animator.SetBool("isTurnLeft", false);
                animator.SetBool("isTurnRigth", false);
            }
        }
    }
}