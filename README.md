# Licorne

![Licorn colorful logo](logo.png)

Licorne is a Little Color Reorganizer for the .Net Ecosystem.

## Sample

### code

```C#
var rgb = new Rgb (13, 37, 42);
var hsl = new Hsl (rgb);
Console.WriteLine(hsl);
```

### output

    hsl(190.3,52.73%,10.78%)

## Getting Started

Download it on nuget:

You can install Licorne as [a nuget package](https://nuget.org/packages/Licorne) or from the console: 

    Install-Package Licorne

## Why _Licorne_?

### Suit my need

Their are a lot of [implemen](https://github.com/Litipk/ColorSharp)[tation](https://github.com/THEjoezack/ColorMine) of HSL out there, but I was looking for something small, easy, and widely tested. I needed quickly a version working with Universal Apps (school project stuff). Finally, I like to build stuff. Licorne was originally a part of [Harmony](https://github.com/aloisdg/Harmony/), but I extract it in a library to use it in different place.

### Yes but why this name?

_Licorne_ is the French translation for _unicorn_. Like them, HSL is colorful, great and absent of .NET.  Also, I like the name "Alvy" as an alternative in reference to the creator of cylindrical-coordinate model : [Alvy Ray Smith](https://en.wikipedia.org/wiki/Alvy_Ray_Smith).

## About HSL

<!-- Add more stuff about HSL -->
HSL stands for hue, saturation, and lightness, and is also often called HLS.

### Pro

HSL is an widely, easy and readable alternative to plain RGB. You can find it and use it almost everywhere without huge dependencies.

### Cons

Like Unicorn, HSL is perfect and like unicorn they may not be suitable for the real world. Human's vision is not perfect. All hues are not born equals for us. Some great peoples try to fix this issue to get a better output. You can move outside sRGB with the CIE or use an adaptation of HSL to handle the human factor. This adaptation is named [HUSL](http://www.husl-colors.org/) and their is a [C# implementation](https://github.com/husl-colors/husl-csharp). If like myself, HSL works for you keep it, if you need or want more you may want to switch to HUSL.

## Acknowledgement

This project is inspired by the implementation of [Rich Newman](https://richnewman.wordpress.com/about/code-listings-and-diagrams/hslcolor-class/), [ColorMine](https://github.com/THEjoezack/ColorMine) and [Bob Powell](https://web.archive.org/web/20110425154034/http://bobpowell.net/RGBHSB.htm).

The logo is made after [Bohdan Burmich's work](https://thenounproject.com/term/unicorn/131626/) from the [Noun Project](https://thenounproject.com).

## License

Licorne is released under the MPL2 License. See the [bundled LICENSE](https://github.com/aloisdg/Licorne/blob/master/License) file for details.
