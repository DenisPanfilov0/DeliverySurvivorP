using UnityEngine;

namespace UI
{
    public class MenuSounds : MonoBehaviour
    {
        public AudioSource _audio;

        public void PlayButton()
        {
            _audio.Play();
        }
    }
}
