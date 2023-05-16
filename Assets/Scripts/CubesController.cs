using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesController : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _delayBetweenSpawn = 0.001f;
    [SerializeField] private Vector3 _startPointSpawn;
    [SerializeField] private float _distanceBetweenCubes = 1.2f;
    [SerializeField] private int _numberOfCubesHorizontally = 20;
    [SerializeField] private int _numberOfCubesVertically = 20;
    [SerializeField] private float _intervalBetweenColorChanges = 0.2f;
    private List<Cube> arrayCubes;

    private void Awake()
    {
        arrayCubes = new List<Cube>();
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        for (int i = 0; i < _numberOfCubesVertically; i++)
        {
            for (int j = 0; j < _numberOfCubesHorizontally; j++)
            {
                var position =_startPointSpawn  + new Vector3(j *_distanceBetweenCubes, -i * _distanceBetweenCubes);
                var instantiateCube = Instantiate(_prefab,position,Quaternion.identity);
                arrayCubes.Add(instantiateCube);
                yield return new WaitForSeconds(_delayBetweenSpawn);
            }
        }
        
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        var newColor = Random.ColorHSV();
        for (var i = 0; i < arrayCubes.Count; i++)
        {
            arrayCubes[i].ChangeColor(newColor);
            yield return new WaitForSeconds(_intervalBetweenColorChanges);
        }
    }
}
