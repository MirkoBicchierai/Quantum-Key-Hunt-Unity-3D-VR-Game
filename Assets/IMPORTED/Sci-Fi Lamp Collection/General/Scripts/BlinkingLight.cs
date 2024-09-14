using System.Collections;
using UnityEngine;

namespace com.ggames4u.scifi_lamp_collection {
    public class BlinkingLight : MonoBehaviour {
        #region Variables
        [SerializeField] private GameObject pointLight_01;
        [SerializeField] private GameObject pointLight_02;
        [SerializeField] private MeshRenderer meshRenderer;

        [ColorUsageAttribute(false, true)]
        [SerializeField] private Color emissionColorOn;

        [ColorUsageAttribute(false, true)]
        [SerializeField] private Color emissionColorOff;

        [Range(0.1f, 10.0f)]
        [SerializeField] private float delay = 1.0f;

        [Tooltip("The lights stay on for this time.")]
        [Range(0.1f, 5f)]
        [SerializeField] private float onTime = 0.15f;

        [SerializeField] bool autoStart = true;
        [SerializeField] bool alwaysOn = false;

        private enum RENDER_PIPELINES {
            BuiltinRP,
            URP,
            HDRP
        }

        [Tooltip("Select the correct render pipeline, so the script can set the deired shader property.")]
        [SerializeField] private RENDER_PIPELINES renderPipeline;
        private string[] emissionColorProperties = { "_EmissionColor", "Color_488DF21D", "_EmissiveColor" };

        private IEnumerator blinkingEnum;
        #endregion

        #region Builtin Methods
        /// <summary>
        /// Set light to off.
        /// </summary>
        private void Start() {

            if (meshRenderer) {
                meshRenderer.material.SetColor(emissionColorProperties[(int)renderPipeline], emissionColorOff);
            }

            if (pointLight_01) {
                pointLight_01.SetActive(false);
            }

            if (pointLight_02) {
                pointLight_02.SetActive(false);
            }

            if (autoStart && !alwaysOn) {
                StartBlinking();

            } else {
                if (meshRenderer) {
                    meshRenderer.material.SetColor(emissionColorProperties[(int)renderPipeline], emissionColorOn);
                }

                if (pointLight_01) {
                    pointLight_01.SetActive(true);
                }

                if (pointLight_02) {
                    pointLight_02.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Reset emission color and lights.
        /// </summary>
        private void OnApplicationQuit() {
            if (meshRenderer) {
                meshRenderer.material.SetColor(emissionColorProperties[(int)renderPipeline], emissionColorOff);
            }

            if (pointLight_01) {
                pointLight_01.SetActive(false);
            }

            if (pointLight_02) {
                pointLight_02.SetActive(false);
            }
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Start blinkiing lights.
        /// </summary>
        public void StartBlinking() {
            blinkingEnum = Blink(delay);

            StartCoroutine(blinkingEnum);
        }

        /// <summary>
        /// Start blinkiing lights.
        /// </summary>
        public void StopBlinking() {
            StopCoroutine(blinkingEnum);
        }

        /// <summary>
        /// Switch light on and of with the given delay.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        private IEnumerator Blink(float delay) {
            yield return new WaitForSeconds(delay);

            if (meshRenderer) {
                meshRenderer.material.SetColor(emissionColorProperties[(int)renderPipeline], emissionColorOn);
            }

            if (pointLight_01) {
                pointLight_01.SetActive(true);
            }

            if (pointLight_02) {
                pointLight_02.SetActive(true);
            }

            yield return new WaitForSeconds(onTime);

            if (meshRenderer) {
                meshRenderer.material.SetColor(emissionColorProperties[(int)renderPipeline], emissionColorOff);
            }

            if (pointLight_01) {
                pointLight_01.SetActive(false);
            }

            if (pointLight_02) {
                pointLight_02.SetActive(false);
            }

            blinkingEnum = Blink(delay);
                
            StartCoroutine(blinkingEnum);
        }
        #endregion
    }
}
