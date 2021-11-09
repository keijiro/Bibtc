using UnityEngine;

namespace Bibtc {

public sealed class BibtcEncoder : MonoBehaviour
{
    [SerializeField, HideInInspector] Shader _shader = null;

    public ulong TimeFlicks { get; private set; }
    public double TimeSeconds { get; private set; }

    Material _material;

    void Start()
      => _material = new Material(_shader);

    void OnDestroy()
      => Destroy(_material);

    void Update()
    {
        TimeSeconds = Time.timeAsDouble;
        TimeFlicks = (ulong)(TimeSeconds * 705600000);
        _material.SetInteger("_Code1", (int)(TimeFlicks      ));
        _material.SetInteger("_Code2", (int)(TimeFlicks >> 32));
    }

    void OnRenderObject()
    {
        _material.SetPass(0);
        Graphics.DrawProceduralNow(MeshTopology.Triangles, 6, 1);
    }
}

} // namespace Bibtc
