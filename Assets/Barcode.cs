using UnityEngine;

namespace Bibtc {

public sealed class Barcode : MonoBehaviour
{
    MaterialPropertyBlock _block;

    void Start()
      => _block = new MaterialPropertyBlock();

    void Update()
    {
        var tc = (ulong)(Time.timeAsDouble * 1000);
        var r = GetComponent<Renderer>();
        r.GetPropertyBlock(_block);
        _block.SetInt("_Code1", (int)tc);
        _block.SetInt("_Code2", (int)tc);
        r.SetPropertyBlock(_block);
    }
}

} // namespace Bibtc
