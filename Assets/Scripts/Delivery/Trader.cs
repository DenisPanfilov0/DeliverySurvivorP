using UnityEngine;

namespace Delivery
{
    public class Trader : MonoBehaviour
    {
        private ItemDataConfig _itemDataConfig;
        public GameObject [] _itemPrefab;
        private bool _canDeliver = false;
        public GameObject ItemPrefab { get; set; }
        private HeroController _heroController;
        private InputController _inputController;

        private void Start()
        {
            _heroController = FindObjectOfType<HeroController>();
            _inputController = FindObjectOfType<InputController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                _canDeliver = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                _canDeliver = false;
            }
        }

        private void Update()
        {
            if (!GameObject.FindWithTag("Item1") && !GameObject.FindWithTag("Item2") && !GameObject.FindWithTag("Item3"))
            {
                if ((_canDeliver && Input.GetKeyDown(KeyCode.E)) && InventoryManager.instance.inventoryItems.Count < 1)
                {
                    ItemPrefab = _itemPrefab[UnityEngine.Random.Range(0, _itemPrefab.Length)];
                    InventoryManager.instance.AddItem(ItemPrefab);
                    Debug.Log("Item added to inventory.");
                    _heroController.PaintTheHero(ItemPrefab.tag);
                    _heroController.ChangeSpeedHero(_heroController.ChangeSpeed);
                }
            }
        }
        
    }
}