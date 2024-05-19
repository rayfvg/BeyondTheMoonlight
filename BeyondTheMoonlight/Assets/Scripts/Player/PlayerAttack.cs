using UnityEngine;

public class PlayerAttack : MonoBehaviour

{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForse;
    [SerializeField] private Money _prefabMoney;
    [SerializeField] private PlayerHP _playerHP;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Walker>())
        {
            float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);
            if (dot > 0.7)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y - 2f, 0f);
                Instantiate(_prefabMoney, pos, Quaternion.identity);
                Destroy(collision.gameObject);
                _rb.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);
            } 
            else
            {
                _playerHP.TakeDamage(1);
            }
        }
    }
}
