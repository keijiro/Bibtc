using UnityEngine;
using UnityEngine.Video;

namespace Bibtc {

public sealed class BarcodeDecoder : MonoBehaviour
{
    [SerializeField] VideoPlayer _source = null;
    [SerializeField] ComputeShader _shader = null;

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

        Debug.Log($"{temp[0]:X}-{temp[1]:X}");
    }
}

} // namespace Bibtc
