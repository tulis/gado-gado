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

## Mute sound for specific section
```
ffmpeg -i _WP_20190607_15_08_39_Pro.mp4 -af "volume=enable='between(t,2667,2675)':volume=0" -c:v copy output.mp4
```

## Mute sound for multiple sections
```
ffmpeg -i input.mp4 -af "volume=enable='between(t,5,10)':volume=0, volume=enable='between(t,33,36)':volume=0" -c:v copy output.mp4
```
[StackExchange reference](https://superuser.com/questions/1201406/how-to-use-ffmpeg-to-mute-specific-sections-of-a-video/1201452)

## Crop Preview (Instagram)
```
ffplay -i "Instagram 12_24_2017 11_34_54 PM.mp4" -vf "crop=555:in_h"
```
* [StackExchange reference](https://video.stackexchange.com/questions/4563/how-can-i-crop-a-video-with-ffmpeg)
* [ffmpeg crop reference](http://ffmpeg.org/ffmpeg-filters.html#crop)

## Crop Save (Instagram)
```

```
[StackExchange reference](https://video.stackexchange.com/questions/4563/how-can-i-crop-a-video-with-ffmpeg)

## Convert *.mkv to *.mp4
```
ffmpeg -i LostInTranslation.mkv -codec copy LostInTranslation.mp4
```
* [StackExchange reference](https://web.archive.org/web/20181231062438/https://askubuntu.com/questions/396883/how-to-simply-convert-video-files-i-e-mkv-to-mp4)
