using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OrbSpawner : MonoBehaviour
{
    public int maxOrbs = 5;
    public float orbCooldown = 4f;
    public GameObject orbPrefab;

    [FormerlySerializedAs("rotatingSpeed")][FormerlySerializedAs("rotatingSeeed")][FormerlySerializedAs("orbRotatingSeeed")] public float orbRotatingSpeed = 15f;
    [SerializeField] public float radius;
    private float _shootCooldownElapsed;
    private PlayerManager _playerManager;
    private List<GameObject> _orbs = new();

    // Start is called before the first frame update
    void Start()
    {
        _shootCooldownElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (_shootCooldownElapsed > orbCooldown && _orbs.Count < maxOrbs)
        {
            Shoot();
            _shootCooldownElapsed = 0f;
        }
        _shootCooldownElapsed += Time.deltaTime;
    }

    void Shoot()
    {

        var proyectil = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        var orbBehaviour = proyectil.GetComponent<OrbBehaviour>();

        orbBehaviour.OrbSpawner = transform;
        orbBehaviour.RotaionSpeed = orbRotatingSpeed;
        orbBehaviour.Radius = radius;
        _orbs.Add(proyectil);
        for (int index = 0; index < _orbs.Count; index++)
        {
            var orb = _orbs[index];
            orbBehaviour.AngleOffset = (360f / _orbs.Count) * index;
        }
    }
}