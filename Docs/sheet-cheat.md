# Development Cheat Sheet.

## Converting PNG to DDS DXT5

```
mogrify -flip -format dds -define dd:mipmaps=1 -define dds:compression=dxt5 *.png
```
