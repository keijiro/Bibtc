using UnityEngine;
using UnityEngine.Video;

namespace Bibtc {

public sealed class BibtcDecoder : MonoBehaviour
{
    [SerializeField] VideoPlayer _source = null;
    [SerializeField, HideInInspector] ComputeShader _shader = null;

    public ulong TimeFlicks { get; private set; }
    public double TimeSeconds { get; private set; }

    ComputeBuffer _buffer;

    void Start()
      => _buffer = new ComputeBuffer(2, sizeof(uint));

    void OnDestroy()
      => _buffer?.Dispose(); 

    void Update()
    {
        if (_source.texture == null) return;

        _shader.SetTexture(0, "Source", _source.texture);
        _shader.SetBuffer(0, "Output", _buffer);
        _shader.Dispatch(0, 1, 1, 1);

        var temp = new uint[2];
        _buffer.GetData(temp);

        TimeFlicks = (ulong)temp[0] | ((ulong)temp[1] << 32);
        TimeSeconds = TimeFlicks / 705600000.0;
    }
}

} // namespace Bibtc
