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

## 
