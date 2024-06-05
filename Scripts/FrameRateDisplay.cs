using TMPro;
using UnityEngine;

namespace GV.Extensions
{
    public class FrameRateDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameFrame_TMP;

        private readonly float _pollingTime = 0.5f;
        private float _time;
        private int _frameCount;

        private void Start()
        {
            // Crie uma logica para ativar e desativar a visualização em algum local do seu projeto
            // Exemplo; gameObject.SetActive(SaveGameController.Instance.GlobalSettings.ShowFps);
        }

        private void Update()
        {
            _time += Time.unscaledDeltaTime;
            _frameCount++;

            if (_time >= _pollingTime)
            {
                int frameRate = Mathf.RoundToInt(_frameCount / _time);
                gameFrame_TMP.text = frameRate.ToString() + " fps";

                _time -= _pollingTime;
                _frameCount = 0;
            }
        }
    }
}