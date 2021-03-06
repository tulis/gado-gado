## Convert m3u8 to mp4
```
ffmpeg -i http://eqd591fqsh.eq.webcdn.stream.ne.jp/www50/eqd591fqsh/jmc_pub/jmc_pd/00001/ab05c12dce8a422080c6f2212351a9d5/ab05c12dce8a422080c6f2212351a9d5_9.m3u8 -c copy -bsf:a aac_adtstoasc output.mp4
```

## Convert m3u8 to mp4 for specified time range
```
ffmpeg -i http://eqd591fqsh.eq.webcdn.stream.ne.jp/www50/eqd591fqsh/jmc_pub/jmc_pd/00001/ab05c12dce8a422080c6f2212351a9d5/ab05c12dce8a422080c6f2212351a9d5_9.m3u8 -ss 00:00:15.00 -t 00:00:10.00 -c copy -bsf:a aac_adtstoasc output.mp4
```
* `-ss 00:00:15.00` indicates discard all input up until `15` seconds
* `-t 00:00:10.00` indicates capture duration for 10 seconds
* [How to download portion of video with youtube-dl command?](https://unix.stackexchange.com/questions/230481/how-to-download-portion-of-video-with-youtube-dl-command)
* For youtube, combine `youtube-dl` to get `.m3u8` and https://ytcutter.com/ to get duration

## Convert mpd (MPEG-Dash) to mp4
```
ffmpeg -i https://manifest.streaks.jp/v1/hulu/5ff99a100681456e8d59facc946658cf/964dcc819f774d0ca33d1b73b193ca81/dash/main/manifest.mpd -c copy output.mp4
```
* [How to download and encode a video from a MPD manifest?](https://video.stackexchange.com/questions/24435/how-to-download-and-encode-a-video-from-a-mpd-manifest)

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
