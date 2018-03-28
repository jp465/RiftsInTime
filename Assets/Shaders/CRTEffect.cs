using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CRTEffect : MonoBehaviour
{
    public Texture texture;
    //public Camera camera;
    public Material material;
    public bool crtEffectActive=false;

    private void Update()
    {
        
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (crtEffectActive)
        {
            Graphics.Blit(source, destination, material);
        }else
        {
            Graphics.Blit(source, destination);
        }
    }




}