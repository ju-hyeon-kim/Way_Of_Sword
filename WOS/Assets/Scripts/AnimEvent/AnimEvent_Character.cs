using UnityEngine;
using UnityEngine.Events;

namespace wos
{
    public class AnimEvent_Character : MonoBehaviour
    {
        public UnityEvent Attack = default;
        public UnityEvent<bool> ComboCheck = default;
        public AudioClip[] AudioClips;
        public AudioSource PlayerAudio;

        public void OnAttack()
        {
            Attack?.Invoke();
        }

        public void ComboCheckStart()
        {
            PlayerAudio.clip = AudioClips[0];
            PlayerAudio.Play();
            ComboCheck?.Invoke(true);
        }

        public void ComboCheckEnd()
        {
            ComboCheck?.Invoke(false);
        }
    }
}

