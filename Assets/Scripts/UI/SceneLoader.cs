using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Load();

            }
        }

        public void Load()
        {
            SceneManager.LoadSceneAsync(sceneName);
            Time.timeScale = 0f;

        }
    }
}