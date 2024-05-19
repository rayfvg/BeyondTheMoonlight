using TMPro;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] TMP_Text _hpText;
    [SerializeField] private Blink _blink;
    private bool _immortality = false;
    public int PlayerHealth = 10;

    private void Update() => _hpText.text = PlayerHealth.ToString();
    public void TakeDamage(int value)
    {
        if (_immortality == false)
        {
            PlayerHealth -= value;
            _blink.StartBlick();
            Invoke("_immortalityOff", 2f);
        }

        if (PlayerHealth <= 0)
            Debug.Log("GameOver");
    }
    public void _immortalityOff() => _immortality = false;
}
