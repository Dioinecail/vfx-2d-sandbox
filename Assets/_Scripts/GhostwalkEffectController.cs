using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostwalkEffectController : MonoBehaviour
{
    // cached referenses
    public SpriteRenderer ghostRendererPrefab;
    public SpriteRenderer targetRenderer;

    // editable parameters
    public float ghostRendererDelay = 0.25f;



    private void Start()
    {
        StartCoroutine(SpawnGhostRenderers(ghostRendererDelay));    
    }

    private void SpawnGhostRenderer()
    {
        SpriteRenderer ghost = Instantiate(ghostRendererPrefab, targetRenderer.transform.position, Quaternion.identity);
        ghost.flipX = targetRenderer.flipX;
        ghost.sprite = targetRenderer.sprite;
    }

    private IEnumerator SpawnGhostRenderers(float delay)
    {
        yield return new WaitForSeconds(delay);

        SpawnGhostRenderer();

        yield return SpawnGhostRenderers(delay);
    }
}