using Player;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Money _prefabMoney;
    [SerializeField] private Transform _spawnCoinTransform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForse;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.GetComponent<Move>())
        {
            float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.down);
            if (dot > 0.7f)
            {
                Instantiate(_prefabMoney, _spawnCoinTransform.position, Quaternion.identity);
                _rb.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);
                gameObject.SetActive(false);
            }
        }
    }
}
