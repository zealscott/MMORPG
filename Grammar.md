## Class

### get/set


```C#
class TimePeriod
{
     private double _seconds;

     public double Seconds
     {
         get { return _seconds; }
         set { _seconds = value; }
     }
}
```

这里的`get`功能可以在对象外访问`private`变量，就像`public`变量一样，访问：

```C#
double s = TimePeriod.Seconds
```

[参考这里](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get)

