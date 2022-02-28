# Roman Numeral Parser

Library to parse and output roman numerals.

*Requirements*
* .NET 6

Wrapping this code into a console application should give you an output like this:
```
$ ix
9
ix

$ XIIII
14
XIV
> Note: It is missing the normalization from roman clock notation to standard forma

$ MCMXCIX
1999
MCMXCIX
```

Additional Notes

* [Roman numerals on Wikipedia](https://en.wikipedia.org/wiki/Roman_numerals)
* Created an immutable data type to represent a roman number for now, abstraction could come later when we have an specific scenario. We have an interface to make easier extending the implementation.
* Did write unit tests, but missing a bunch of corner cases.
* No relevant documentation except wikipedia and MS docs to troubleshoot some configuration issues in Rider & .NET 6.
* Did apply Postel's Law, see comments in the code.

We'd prefer your implementation to be written in  Go; if you use a different language, please advise why you chose it.
> Note: Using .NET as I didn't have time to setup another dev environment.