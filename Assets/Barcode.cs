using UnityEngine;

namespace Bibtc {

[ExecuteInEditMode]
public sealed class Barcode : MonoBehaviour
{
    [SerializeField] Shader _shader = null;

    Material _material;

    void OnDestroy()
    {
        if (_material != null)
            if (Application.isPlaying)
                Destroy(_material);
            else
                DestroyImmediate(_material);
    }

    void Update()
    {
        if (_material == null)
        {
            _material = new Material(_shader);
            _material.hideFlags = HideFlags.DontSave;
        }

        var tc = (ulong)(Time.timeAsDouble * 705600000);
        _material.SetInteger("_Code1", (int)(tc      ));
        _material.SetInteger("_Code2", (int)(tc >> 32));
    }

    void OnRenderObject()
    {
        if (_material == null) return;

        _material.SetPass(0);
        Graphics.DrawProceduralNow(MeshTopology.Triangles, 6, 1);
    }
}

} // namespace Bibtc
