using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Exam_Project.Assets.Scripts{
    public class RayBehaviour : MonoBehaviour{
        public XRInteractorLineVisual rayInteractor;
        public LineRenderer lineRenderer;

        public void On(){
            rayInteractor.enabled = true;
            lineRenderer.enabled = true;
            
        }
        public void Off(){
            rayInteractor.enabled = false;
            lineRenderer.enabled = false;
        }

    }
}