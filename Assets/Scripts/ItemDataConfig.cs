using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Item", menuName = "Item Data")]
public class ItemDataConfig : ScriptableObject
{
    [SerializeField] private int[] _itemID;
    [SerializeField] private SpriteRenderer[] _spriteRune;
    [SerializeField] private string[] _nameRune;

    public int[] ItemID => _itemID;
    public SpriteRenderer[] SpriteRune => _spriteRune;
    public string[] NameRune => _nameRune;
}