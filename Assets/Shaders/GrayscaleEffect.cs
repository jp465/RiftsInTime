using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GrayscaleEffect : MonoBehaviour
{

    public float intensity;
    private Material material;
    public CRTEffect CrtEffect;
    bool isEffectActive = false;
    bool isRewindEffectActive = false;
    LevelManager LM;

    InputManager IM;

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/GrayscaleShader"));
        IM = FindObjectOfType<InputManager>();
        LM = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(IM.rift1)&&!isEffectActive&&LM.powerLevel>=1)
        {
            isEffectActive = true;
            LM.timeSlowed = true;
            LM.CheckSlowTime();
            Debug.Log("press rift 1");
            LM.CoolDownGauntlet();
            StartCoroutine("SlowFadeIn");
            
        }

        if (Input.GetKeyDown(IM.rift2) && !isRewindEffectActive && LM.powerLevel >= 2)
        {
            isRewindEffectActive = true;
            LM.timeRewind = true;
            Debug.Log("press rift 2");
            LM.CoolDownGauntlet();
            StartCoroutine("RewindFadeIn");

        }
        /*
        if (LM.timeRewind == false && isRewindEffectActive)
        {
            Debug.Log("Rewind Test2");
            CrtEffect.crtEffectActive = true;
            StartCoroutine("RewindFadeOut");
        }
        */

        if (Input.GetKeyDown(IM.rift3) && !isEffectActive && LM.powerLevel == 3)
        {
            isEffectActive = true;
            LM.timeStopped = true;
            Debug.Log("press rift 3");
            LM.CoolDownGauntlet();
            StartCoroutine("StoppedFadeIn");

        }
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

    public IEnumerator SlowFadeIn()
    {
        CrtEffect.crtEffectActive = true;
        while (intensity <= 1)
        {
            
            intensity += .1f;
            yield return new WaitForSeconds(.025f);
        }
        CrtEffect.crtEffectActive = false;
        yield return new WaitForSeconds(1.25f);
        CrtEffect.crtEffectActive = true;
        StartCoroutine("SlowFadeOut");
    }

    public IEnumerator SlowFadeOut()
    {
        while (intensity >= 0)
        {
            intensity -= .1f;
            yield return new WaitForSeconds(.025f);
        }
        CrtEffect.crtEffectActive = false;
        isEffectActive = false;
        LM.timeSlowed = false;
        LM.CheckSlowTime();
    }

    public IEnumerator RewindFadeIn()
    {
        CrtEffect.crtEffectActive = true;
        while (intensity <= 1)
        {

            intensity += .1f;
            yield return new WaitForSeconds(.1f);
        }
        CrtEffect.crtEffectActive = false;
        yield return new WaitForSeconds(3.5f);
        CrtEffect.crtEffectActive = true;
        StartCoroutine("RewindFadeOut");

    }

    public IEnumerator RewindFadeOut()
    {
        while (intensity >= 0)
        {
            Debug.Log("fadeouttest");
            intensity -= .1f;
            yield return new WaitForSeconds(.1f);
        }

        CrtEffect.crtEffectActive = false;
        isRewindEffectActive = false;
        LM.timeRewind = false;
    }

    public IEnumerator StoppedFadeIn()
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
        StartCoroutine("StoppedFadeOut");
    }

    public IEnumerator StoppedFadeOut()
    {
        while (intensity >= 0)
        {
            intensity -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        CrtEffect.crtEffectActive = false;
        isEffectActive = false;
        LM.timeStopped = false;
        
    }
}
