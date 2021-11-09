using UnityEngine;
using UnityEngine.UI;

public sealed class TimecodeLabel : MonoBehaviour
{
    [SerializeField] Bibtc.TimecodeEncoder _encoder = null;
    [SerializeField] Bibtc.TimecodeDecoder _decoder = null;

    void Update()
      => GetComponent<Text>().text = _encoder != null ?
        $"Encoded: {_encoder.TimeSeconds:0.00} ({_encoder.TimeFlicks:X16})" :
        $"Decoded: {_decoder.TimeSeconds:0.00} ({_decoder.TimeFlicks:X16})";
}
