using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private Text damageText;

    void Start()
    {
        damageText = GetComponent<Text>();
    }

    public void ShowDamage(float damageAmount)
    {
        damageText.text = "-" + damageAmount;
        Invoke("HideDamage", 1f);
    }

    private void HideDamage()
    {
        damageText.text = "";
    }
}