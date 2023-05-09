using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public AudioSource _audio;

        public void PlayButton()
        {
            _audio.Play();
        }
    }
}
