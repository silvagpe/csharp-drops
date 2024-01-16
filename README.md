# C#  drops

A sudy guide for C# developers


## Basic concepts of C#

### 1 - Difference between 'const' and 'readonly'

Both are modifiers that can to apply a member of class (fields, properties, methods). They are used to create a variables whose values cannot be modified during runtinme.

#### **'const'**: 

 Value assignment:

* The value of a 'const' variable must be assigned at the time of declaration, and it cannot be changed afterward.
*It is implicity 'static', meaning it's associated with the type rather than an instance of the type   

Compile-time constant:

* The value of a 'const' is evaluated at the compile time.
* It is suitable for values that are known at compile time and will never change.

Usage:

* Commonly used for mathematical constants, configuration values, or any value that is know at compile time.

Accessibility:

* A 'const' field is implicity 'public', 'static' and 'literal'

```csharp
public class MyClass
{
    public const int MaxValue = 100;
}

```

#### **'readonly'**: 

Value Assignment:

* The value of a readonly variable can be assigned at the time of declaration or in the constructor.
* It can have different values for different instances of the class.

Runtime Constant:

* The value of a readonly variable is evaluated at runtime.
* It is suitable when the value needs to be assigned during runtime but should not change afterward.

Usage:

* Commonly used when the value needs to be determined at runtime or when the value might change between instances.

Accessibility:

* A readonly field can have any accessibility level (public, private, protected, etc.).

#### Summary:

* Use const for values that are known at compile time and will never change.

* Use readonly for values that need to be assigned at runtime or when the value might change between instances.

* const is implicitly static and evaluated at compile time, while readonly can have different values for different instances and is evaluated at runtime.

```csharp
public class MyClass
{
    public readonly int MaxValue;

    public MyClass(int maxValue)
    {
        MaxValue = maxValue;
    }
}
```
