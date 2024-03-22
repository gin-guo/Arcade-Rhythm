*Finding beatmap*
1. Download .osz archive from osu!
2. Change extension from .osz to .zip
3. Unzip and locate .osu file
4. Open with text editor to view; change extension to .txt and save
5. Import .txt into text asset in Unity

*Understanding beatmap*
Format of hit object: x,y,time,type,hitSound,objectParams,hitSample
hitSound and hitSample are irrelevant for us
We want to use:
Circles -> no objectParams
Spinners -> objectParams = endTime
