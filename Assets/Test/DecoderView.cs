using UnityEngine;
using UnityEngine.UI;

public sealed class DecoderView : MonoBehaviour
{
    [SerializeField] Bibtc.TimecodeDecoder _decoder = null;

    void Update()
    {
        var tex = _decoder.Texture;
        if (tex == null) return;
        GetComponent<RawImage>().texture = tex;
        GetComponent<AspectRatioFitter>().aspectRatio = (float)tex.width / tex.height;
    }
}
