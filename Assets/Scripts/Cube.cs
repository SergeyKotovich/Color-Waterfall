using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _colorChangeTime;
    [SerializeField] private MeshRenderer _meshRenderer;
    private Material _material;

    private void Awake()
    {
        _material = _meshRenderer.material;
    }

    public void ChangeColor(Color newColor)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeColorCoroutines(newColor));
        
    }

    private IEnumerator ChangeColorCoroutines(Color newColor)
    {
        
        var startColor = _material.color;
        var currentTime = 0f;
        while (currentTime<_colorChangeTime)
        {
            currentTime += Time.deltaTime;
            var currentColor = Color.Lerp(startColor, newColor, currentTime / _colorChangeTime);
            _material.color = currentColor;
            yield return null;
        }
        
    }
}
