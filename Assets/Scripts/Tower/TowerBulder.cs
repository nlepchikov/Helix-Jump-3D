using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulder : MonoBehaviour
{
    [SerializeField] private int _levelcount = 5;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private float _additionalScale;

    private float _startAndFinishAdditionalScale = 1f;
    public float BeamScaleY => _levelcount / 2.5f + _startAndFinishAdditionalScale + _additionalScale / 2.5f;

    private void Awake()
    {
        Build();
    }
    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);
         
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale + 1;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelcount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1f;
    }

   

}
