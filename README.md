Bibtc - Burnt-In Binary Time Code
=================================

**Bibtc** is a proof-of-concept project that uses barcode-like burnt-in
patterns to embed timecode into video frame images.

What's it for
-------------

It helps synchronize video frames and external per-frame metadata. You can use
video timecode to do the same thing, but it's prone to be lost in
editing/transcoding. Burnt-in data is more robust to those kinds of desync
issues.

How this project works
----------------------

- "Encoder" encodes the current time (`Time.time`) using the [Flicks] 64-bit
  timecode format and draws barcode patterns on the left edge of the screen.
- "Decoder" decodes the timecode from a video feed.

- I deployed Encoder to my iPhone X and recorded it using the built-in screen
  recorder.
- I copied back the recorded video into the project and tried decoding it. I
  verified it decodes perfectly synched timecode.

[Flicks]: https://github.com/facebookarchive/Flicks
