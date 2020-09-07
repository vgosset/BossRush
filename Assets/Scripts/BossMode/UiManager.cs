using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BossMode {
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;
        [SerializeField] private Slider bossLifeSlider;

        private void Awake()
        {
            Instance = this;
        }
        public void UpdateBossLife(float amount, float totalLife)
        {
            bossLifeSlider.value = amount / totalLife;
        }
    }
}
