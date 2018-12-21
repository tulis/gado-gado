## Convert m3u8 to mp4
```
ffmpeg -i http://eqd591fqsh.eq.webcdn.stream.ne.jp/www50/eqd591fqsh/jmc_pub/jmc_pd/00001/ab05c12dce8a422080c6f2212351a9d5/ab05c12dce8a422080c6f2212351a9d5_9.m3u8 -c copy -bsf:a aac_adtstoasc output.mp4
```

## Rotate
```
ffmpeg -i output.mp4 -vf "transpose=2" -strict -2 akane-ono-businessmanchampionship2018.mp4
```

## Mute sound
```
ffmpeg -i output.mp4 -c copy -an output-no-sound.mp4
```

## Crop Preview (Instagram)
```
ffplay -i "Instagram 12_24_2017 11_34_54 PM.mp4" -vf "crop=555:in_h"
```
[StackExchange reference](https://video.stackexchange.com/questions/4563/how-can-i-crop-a-video-with-ffmpeg)
[ffmpeg crop reference](http://ffmpeg.org/ffmpeg-filters.html#crop)

## Crop Save (Instagram)
```

```
[StackExchange reference](https://video.stackexchange.com/questions/4563/how-can-i-crop-a-video-with-ffmpeg)
