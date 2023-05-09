using UnityEngine;

namespace Delivery
{
    public class HomeBuyer : MonoBehaviour
    {
        [SerializeField] private float _income = 10;
        [SerializeField] private string _runeColor;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_runeColor))
            {
                Debug.Log(_runeColor);
                Destroy(other.gameObject, 2f);
                Invoke("ChangeBalance", 2f);
            }
        }

        private void ChangeBalance()
        {
            Balance.Instance._balanceValue += _income;
            Score.Instance._scoreValue += _income;
        }
    }
}
