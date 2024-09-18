using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ZombieCrossing.FogOfWar.Runtime
{
    public class FogOfWarRenderFeatureRenderGraph: ScriptableRendererFeature
    {
        [SerializeField] private RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingSkybox;
        private FogOfWarRenderPass fogOfWarRenderPass;
        
        public override void Create()
        {
            fogOfWarRenderPass = new FogOfWarRenderPass();
        }
        
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            fogOfWarRenderPass.renderPassEvent = renderPassEvent;
            fogOfWarRenderPass.ConfigureInput(ScriptableRenderPassInput.Normal);
            if (renderingData.cameraData.cameraType != CameraType.Game) return;
            renderer.EnqueuePass(fogOfWarRenderPass);
        }
    }
}