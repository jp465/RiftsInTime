using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GrayscaleEffect : MonoBehaviour
{

    public float intensity;
    private Material material;
    public CRTEffect CrtEffect;
    bool isEffectActive = false;
    public LevelManager LM;
    public PlayerController PC;

    private void Start()
    {
       // PC = GetType(PlayerController);
    }
    private void Update()
    {
        if (Input.GetKeyDown(LM.rift1)&&!isEffectActive)
        {
            isEffectActive = true;
            PC.timeSlowed = true;
            Debug.Log("press");
            StartCoroutine("FadeIn");
            
        }
    }
    void Awake()
    {
        material = new Material(Shader.Find("Hidden/GrayscaleShader"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, material);
    }

    public IEnumerator FadeIn()
    {
        CrtEffect.crtEffectActive = true;
        while (intensity <= 1)
        {
            
            intensity += .1f;
            yield return new WaitForSeconds(.1f);
        }
        CrtEffect.crtEffectActive = false;
        yield return new WaitForSeconds(5f);
        CrtEffect.crtEffectActive = true;
        StartCoroutine("FadeOut");
    }

    public IEnumerator FadeOut()
    {
        while (intensity >= 0)
        {
            intensity -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        CrtEffect.crtEffectActive = false;
        isEffectActive = false;
        PC.timeSlowed = false;
    }
}
