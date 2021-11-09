using UnityEngine;
using UnityEngine.Video;

namespace Bibtc {

public sealed class BibtcDecoder : MonoBehaviour
{
    [SerializeField] VideoPlayer _source = null;
    [SerializeField, HideInInspector] ComputeShader _shader = null;

    ComputeBuffer _buffer;

    void Start()
    {
        _buffer = new ComputeBuffer(2, sizeof(uint));
    }

    void OnDestroy()
    {
        if (_buffer != null)
        {
            _buffer.Dispose();
            _buffer = null;
        }
    }

    void Update()
    {
        if (_source.texture == null) return;

        _shader.SetTexture(0, "Source", _source.texture);
        _shader.SetBuffer(0, "Output", _buffer);
        _shader.Dispatch(0, 1, 1, 1);

        var temp = new uint[2];
        _buffer.GetData(temp);

        var tc = ((ulong)temp[0] << 32) | (ulong)temp[1];
        var time = tc / 705600000.0;

        Debug.Log($"{tc:X} / {time}");
    }
}

} // namespace Bibtc
