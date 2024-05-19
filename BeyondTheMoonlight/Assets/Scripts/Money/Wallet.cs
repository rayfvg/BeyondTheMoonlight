using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    
    [SerializeField] private Money _money;
    [SerializeField] TMP_Text _textMoneyCount;
    public int OneMoney = 0;

    private void Update() => _textMoneyCount.text = OneMoney.ToString();
}
