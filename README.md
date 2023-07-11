# CompressionMaster
True (and embarassing) story:

In 2016, I was thinking about binary, and had a "breakthrough".

I realized that if there were many 0's or 1's in a row, you could shrink the representation. For instance,

```
10000000000001
```

could become

```
10(12)1
```

I really enthusiastic about this, thinking I just discovered an infinite compression algorithm! Obviously, what I had discovered has been known about for decades, if not centuries: run-length encoding. And yes, run-length encoding really can be used on binary. 

This repository was my attempt at applying this priniple to binary (for the first time ever, I thought at the time). The project itself failed, and I soon found out that my original thought wasn't as original as I thought...

So this repository is a cautionary tale, that if it's too good to be true, it probably is.
# License
MIT
