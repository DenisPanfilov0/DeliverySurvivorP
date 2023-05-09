using UnityEngine;

namespace UI
{
    public class ChangeActive : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToChange;

        public void ChangeObjectActive()
        {
            foreach (var go in objectsToChange)
            {
                go.SetActive(!go.activeInHierarchy);
            }
        }
    }
}