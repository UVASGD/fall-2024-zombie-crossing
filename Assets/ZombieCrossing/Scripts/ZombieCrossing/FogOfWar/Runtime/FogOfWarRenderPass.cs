// TODO: This does not work and the developer will fix it sometime soon.

using FOW;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace ZombieCrossing.FogOfWar.Runtime
{
    public class FogOfWarRenderPass : ScriptableRenderPass
    {
        private RenderTextureDescriptor renderTextureDescriptor = new(Screen.width, Screen.height, RenderTextureFormat.Default, 0);
        private const string FogOfWarRenderPassName = nameof(FogOfWarRenderPass);
        private const string FogOfWarRenderTextureName = nameof(FogOfWarRenderPass) + "Texture";
        private static readonly Vector4 ScaleBias = new(1, 1, 0, 0);
        
        private static readonly int CamToWorldMatrix = Shader.PropertyToID("_camToWorldMatrix");
        private static readonly int CameraSize = Shader.PropertyToID("_cameraSize");
        private static readonly int CameraPosition = Shader.PropertyToID("_cameraPosition");
        private static readonly int CameraRotation = Shader.PropertyToID("_cameraRotation");

        private class RenderPassData
        {
            public RenderTargetIdentifier source; 
            public RenderTargetIdentifier destination;
            public Material material;
        }
        
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer contextContainer)
        {
            if (FogOfWarWorld.instance == null || !FogOfWarWorld.instance.enabled) return;
            
            var resourceData = contextContainer.Get<UniversalResourceData>();
            if (resourceData.isActiveTargetBackBuffer) return;
            
            var cameraData = contextContainer.Get<UniversalCameraData>();
            if (cameraData.camera.GetUniversalAdditionalCameraData().renderType == CameraRenderType.Overlay) return;
            
            renderTextureDescriptor.width = cameraData.cameraTargetDescriptor.width;
            renderTextureDescriptor.height = cameraData.cameraTargetDescriptor.height;
            renderTextureDescriptor.depthBufferBits = 0;
            
            var activeColorTexture = resourceData.activeColorTexture;
            var destinationTextureHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, 
                renderTextureDescriptor, FogOfWarRenderTextureName, false);
            cameraData.camera.depthTextureMode = DepthTextureMode.DepthNormals;
            
            if (!FogOfWarWorld.instance.is2D)
            {
                FogOfWarWorld.instance.FogOfWarMaterial.SetMatrix(CamToWorldMatrix, cameraData.camera.cameraToWorldMatrix);
            }
            else
            {
                FogOfWarWorld.instance.FogOfWarMaterial.SetFloat(CameraSize, cameraData.camera.orthographicSize);
                FogOfWarWorld.instance.FogOfWarMaterial.SetVector(CameraPosition, cameraData.camera.transform.position);
                FogOfWarWorld.instance.FogOfWarMaterial.SetFloat(CameraRotation, Mathf.DeltaAngle(0, cameraData.camera.transform.eulerAngles.z));
            }
            
            if (!activeColorTexture.IsValid() || !destinationTextureHandle.IsValid()) return;

            using var builder = renderGraph.AddRenderPass<RenderPassData>(FogOfWarRenderPassName, out var renderPassData);
            renderPassData.source = builder.ReadTexture(activeColorTexture);
            var outputTextureHandle = renderGraph.CreateTexture(new TextureDesc(Vector2.one, true, true)
                { clearBuffer = true, clearColor = Color.black, name = "Output" });
            renderPassData.destination = builder.UseColorBuffer(outputTextureHandle, 0);
            renderPassData.material = FogOfWarWorld.instance.FogOfWarMaterial;
            
            builder.SetRenderFunc<RenderPassData>(ExecuteRenderPass);
        }

        private static void ExecuteRenderPass(RenderPassData data, RenderGraphContext context)
        {
            Blitter.BlitTexture(context.cmd, data.source, data.destination, data.material, 0);
            Blitter.BlitTexture(context.cmd, data.destination, data.source, null, -1);
        }
    }
}