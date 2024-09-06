using UnityEngine;

[RequireComponent(typeof(ShotSystem))]
public class ShotEffectSpawner : MonoBehaviour
{
    [SerializeField] private EffectType effectType;
    [SerializeField] private Transform effectSpawnPosition;
    [SerializeField] private bool parentObject;

    //[SerializeField] private EffectType bulletEffectType;
    //[SerializeField] private Transform bulletSpawnPosition;

    private EffectSpawner effectSpawner;

    private void Awake()
    {
        GetComponent<ShotSystem>().Shooted += SpawnEffect;
    }

    private void SpawnEffect()
    {
       
        effectSpawner ??= ServiceLocator.GetService<EffectSpawner>();
        
        if (parentObject)
        {
            effectSpawner.SpawnEffect(effectSpawnPosition, effectType,true);
        } 
        else
        {
            effectSpawner.SpawnEffect(effectSpawnPosition, effectType);
        }
        // effectSpawner.SpawnEffect(bulletSpawnPosition, bulletEffectType);
    }
}