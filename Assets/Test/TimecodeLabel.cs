using UnityEngine;
using UnityEngine.UI;

public sealed class TimecodeLabel : MonoBehaviour
{
    [SerializeField] Bibtc.BibtcEncoder _encoder = null;
    [SerializeField] Bibtc.BibtcDecoder _decoder = null;

    void Update()
      => GetComponent<Text>().text = _encoder != null ?
        $"{_encoder.TimeSeconds} {_encoder.TimeFlicks:X}" :
        $"{_decoder.TimeSeconds} {_decoder.TimeFlicks:X}";
}
