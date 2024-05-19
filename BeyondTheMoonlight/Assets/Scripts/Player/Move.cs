using UnityEngine;

namespace Player
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForse;
        [SerializeField] private bool _isGrounded = true;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Rigidbody2D _rb;

        private void Update()
        {
            _animator.SetBool("jump", _isGrounded);
            _animator.SetFloat("move", Mathf.Abs(_rb.velocity.x));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isGrounded)
                {
                    _rb.velocity += new Vector2(0f, _jumpForse);
                }
            }

            if (_rb.velocity.x >= 0)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }
        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
            if (dot > 0.5f)
            {
                _isGrounded = true;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _isGrounded = false;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Money>())
            {
                _wallet.OneMoney += 1;
                Destroy(collision.gameObject);
            }
        }
    } 
}