using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fade_Controller
{
    [RequireComponent(typeof(Image))]
    public class FadeController : MonoBehaviour
    {
        [Range(0f, 2f)] [SerializeField] private float fadeDuration = 2f;
        [SerializeField] private Player.Player player;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private Image _thisImage;

        private const float FadeStep = 0.01f;

        private void Start()
        {
            _thisImage = GetComponent<Image>();
        }

        public void StartFading()
        {
            StartCoroutine(Fading());
        }
    
        private IEnumerator Fading()
        {
            while (_thisImage.color.a > 0)
            {
                _thisImage.color -= new Color(0, 0, 0, FadeStep);
                textMeshProUGUI.color -= new Color(0, 0, 0, FadeStep);
                yield return new WaitForSeconds(fadeDuration * FadeStep);
            }
        
            player.EnableMovement();
            Destroy(gameObject);
        }
    }
}
