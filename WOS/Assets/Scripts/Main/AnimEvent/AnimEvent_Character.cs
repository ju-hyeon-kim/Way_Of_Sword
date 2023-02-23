using UnityEngine;
using UnityEngine.Events;

namespace wos
{
    public class AnimEvent_Character : MonoBehaviour
    {
        public UnityEvent Attack = default;
        public UnityEvent<bool> ComboCheck = default;

        public void OnAttack()
        {
            Attack?.Invoke();
        }

        public void ComboCheckStart()
        {
            ComboCheck?.Invoke(true);
        }

        public void ComboCheckEnd()
        {
            ComboCheck?.Invoke(false);
        }
    }
}

