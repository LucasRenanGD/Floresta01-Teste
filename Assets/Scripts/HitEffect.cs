using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HitEffect : MonoBehaviour
{
    Material hitMaterial;
    SpriteRenderer spriteRenderer;
    Material baseMaterial;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMaterial = spriteRenderer.material;
        hitMaterial = Resources.Load("Materials/HitShader", typeof(Material)) as Material;
        GetComponentInParent<Health>().OnHealthPercentageChanged += HealthChangeEvent;
    }

    private void HealthChangeEvent(float amount)
    {
        PlayHitEffect();
    }

    public void PlayHitEffect() => StartCoroutine(nameof(HitEffectCoroutine));

    IEnumerator HitEffectCoroutine()
    {
        spriteRenderer.material = hitMaterial;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.material = baseMaterial;
    }
}
