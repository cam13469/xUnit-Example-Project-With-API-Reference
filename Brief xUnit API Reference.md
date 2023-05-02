# Brief xUnit API Reference

#### Unit Test Types

##### [Fact] Based Tests

[Fact] unit tests run a parameter-less pure method which should always be true no matter what data is present.

Example:

```c#
[Fact]
internal static void TestMethod_Scenario_Expectation()
{
    // Assertion goes here
}
```

##### [Theory] Based Tests

[Theory] unit tests are used to test groups or sets of related data rather than a simple "[Fact]". [Theory] can handle anything from basic data with simple types, up to complex objects and data structures. [Theory] based methods can be parameter-less however that is highly unlikely and defeats the point of using a [Theory] test; use [Fact] instead.

###### Using [InlineData]

The [InlineData] attribute allows simple immutable data to be passed to the method for declaration of the [InlineData] attribute that is made below [Theory].

Example:

```c#
[Theory]
[InlineData(5, 3.14, "Hi", true)]
[InlineData(-3, 2.71, "Bye", false)]
public static void TestMethod_Scenario_Expectation(int someInt,
                                                   double someDouble,
                                                   string someString,
                                                   bool someBool)
{
	// Test stuff
}
```

###### Using [ClassData]

The [ClassData] attribute allows complex data to be passed into the test method. The attribute requires the type of the data class that contains the data that will be provided for each test. See "Appendix A -> Naming/Syntax Conventions" to see how to define a data class.

Example:

```c#
[Theory]
[ClassData(typeof(someDataClass))]
public static void TestMethod_Scenario_Expectation(Type param1, Type param2, ...)
{
    // Test stuff
}
```

Here, "Type" refers to the type defined in that parameter position within the data class, NOT the built-in .NET type **Type**.

###### Using [MemberData]

The [MemberData] attribute also allows complex data to be passed into the test method. The difference is that it has more flexibility in the variations of test cases it can create. It is best used for testing a hierarchical structure of classes at a given level in the tree. This way you can group tests of child classes in more readable and extensible manner.

The [MemberData] attribute requires two parameters:

1. The **nameof** name of the method in the member data class containing the data required to execute the tests
2. The **MemberType** parameter set to the type of the member data class

Example:

```c#
[Theory]
[MemberData(nameof(someMemberDataClass.MethodData),
            MemberType=typeof(someMemberDataClass))]
public static void TestMethod_Scenario_Expectation(Type param1, Type param2, ...)
{
    // Test stuff
}
```

Here, "Type" refers to the type defined in that parameter position within the member data class, NOT the built-in .NET type **Type**.

#### Assertion Library

##### Equality

| Method                                                       | Overloads | Description                                                  |
| :----------------------------------------------------------- | :-------: | :----------------------------------------------------------- |
| Assert.Equal(double expected, double actual)                 |    +7     | Checks whether two simple objects are equal                  |
| Assert.Equal\<T\>(IEnumerable\<T\> expected, IEnumerable\<T\> actual) |    +11    | Checks whether objects of type T are equal                   |
| Assert.NotEqual\<T\>(IEnumerable\<T\> expected, IEnumerable\<T\> actual) |    +5     | Verifies that sequences are not equivalent using the default **comparer** |
| Assert.Equivalent(object? expected, object? actual, bool strict = false) |     0     | Checks whether **expected** is equal to **actual** by comparing property and field values of the objects irrespective of their type.<br />Checks properties and fields recursively if they are also complex properties.<br />If **strict** is set to **true** the number of properties and fields in each object must be identical. With **strict** set to **false** the **actual** object can have any number of extra properties or fields that are not contained in **expected**. |
| Assert.StrictEqual\<T\>(T expected, T actual)                |     0     | Verifies that both objects of the same type are equal to one another. Uses the object's default **comparer** |
| Assert.NotStrictEqual\<T\>(T expected, T actual)             |     0     | Verifies that both objects of the same type are not equal to one another. Uses the object's default **comparer** |

##### Strings

| Method                                                       | Overloads | Description                                                  |
| ------------------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.Contains(string expectedSubString, string? actualString) |    +1     | Verifies that a string contains the given substring          |
| Assert.DoesNotContain(string expectedSubString, string? actualString) |    +1     | Verifies that a string does not contain the given substring  |
| Assert.StartsWith(string? expectedStartString, string? actualString) |    +1     | Verifies that a given string starts with the provided starting string |
| Assert.EndsWith(string? expectedEndString, string? actualString) |    +1     | Verifies that a given string ends with the provided ending string |
| Assert.Matches(string expectedRegExPattern, string? actualString) |    +1     | Verifies that the given string matches the regular expression string provided |
| Assert.DoesNotMatch(string expectedRegExPattern, string? actualString) |    +1     | Verifies that the given string does not match the regular expression string provided |

##### Booleans

| Method                       | Overloads | Description                          |
| ---------------------------- | :-------: | ------------------------------------ |
| Assert.True(bool condition)  |    +3     | Verifies that **condition** is true  |
| Assert.False(bool condition) |    +3     | Verifies that **condition** is false |

##### Collections

| Method                                                       |                          Overloads                           | Description                                                  |
| ------------------------------------------------------------ | :----------------------------------------------------------: | ------------------------------------------------------------ |
| Assert.All\<T\>(IEnumerable\<T\> collections, Action\<T\> action) |                              +1                              | Verifies that all items in the **collection** pass when evaluated by **action** |
| Assert.Collection\<T\>(IEnumerable\<T\> collections, params Action\<T\>[] elementInspectors |                              0                               | Verifies that collection contains exactly the right amount of elements (given by **elementInspectors**.Length).<br />Verifies that each item in the **collection** passes when evaluated with each action in its corresponding index in the params **elementInspectors**. |
| Assert.Contains\<T\>(T expected, IEnumerable\<T\> collection) | +6 (Many overloads provide extra useful optional parameters such as filters) | Verifies that the **expected** object is contained within **collection** |
| Assert.DoesNotContain\<T\>(T expected, IEnumerable\<T\> collection) |                              +6                              | Verifies that the **expected** object is not contained within **collection** |
| Assert.Distinct\<T\>( IEnumerable\<T\> collection)           |                              +1                              | Verifies that **collection** contains no duplicate objects   |
| Assert.Empty(IEnumerable collection)                         |                              0                               | Verifies that a **collection** is empty                      |
| Assert.Single\<T\>(IEnumerable\<T\> collection)              |                              +3                              | Verifies that a **collection** contains only a single element of given type.<br />**Note:** the type parameter for the IEnumerable is optional if you want to check the entire collection for a single item of the given type **T**. |

##### Ranges

| Method                                                       | Overloads | Description                                                  |
| ------------------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.InRange\<T\>(T actual, T low, T high)<br />where T : IComparable |    +1     | Verifies that a value **actual** is in the given range from **low** to **high**, inclusive of both ends |
| Assert.NotInRange\<T\>(T actual, T low, T high)<br />where T : IComparable |    +1     | Verifies that a value **actual** is not in the given range from **low** to **high**, inclusive of both ends |

##### Types

| Method                                                      | Overloads | Description                                                  |
| ----------------------------------------------------------- | :-------: | ------------------------------------------------------------ |
| Assert.IsType(Type expectedType, object? @object)           |     0     | Checks that **@object** is strictly of type **expectedType** and not a derived type |
| Assert.IsType\<T\>(object? @object)                         |     0     | Checks that **@object** is strictly of type **T** and not a derived type |
| Assert.IsNotType(Type expectedType, object? @object)        |     0     | Checks that **@object** is not strictly of type **expectedType** |
| Assert.IsNotType\<T\>(object? @object)                      |     0     | Checks that **@object** is not strictly of type **T**        |
| Assert.IsAssignableFrom(Type expectedType, object? @object) |     0     | Checks that **@object** is of type **expectedType** or derived type |
| Assert.IsAssignableFrom\<T\>(object? @object)               |     0     | Checks that **@object** is of type **T** or derived type     |

##### Properties

| Method                                                       | Overloads | Description                                                  |
| ------------------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.PropertyChanged(INotifyPropertyChanged @object, string property, Action testCode) |    +1     | Verifies that the property of **@object** named **property** has changed after running **testCode** |

##### Events

| Method                                                       | Overloads | Description                                                  |
| ------------------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.Raises\<T\>(Action\<EventHandler\<T\>\> attach, Action\<EventHandler\<T\>\> detach, Action testCode) |     0     | Verifies that an event with the exact event args is raised upon running **testCode** |
| Assert.RaisesAny\<T\>(Action\<EventHandler\<T\>\> attach, Action\<EventHandler\<T\>\> detach, Action testCode) |     0     | Verifies that an event with the exact or derived event args is raised upon running **testCode** |

##### Exceptions

| Method                                                       | Overloads | Description                                                  |
| ------------------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.Throws\<T\>(Action testCode)<br />where T : Exception |    +1     | Verifies that the exact exception **T** is thrown when **testCode** is executed |
| Assert.ThrowsAny\<T\>(Action testCode)<br />where T : Exception |    +1     | Verifies that the exact exception or derived exception type **T** is thrown when **testCode** is executed |

##### Nullables

| Method                          | Overloads | Description                                        |
| ------------------------------- | :-------: | -------------------------------------------------- |
| Assert.Null(object? @object)    |     0     | Verifies that an **@object** reference is null     |
| Assert.NotNull(object? @object) |     0     | Verifies that an **@object** reference is not null |

##### Miscellaneous

| Method                                           | Overloads | Description                                                  |
| ------------------------------------------------ | :-------: | ------------------------------------------------------------ |
| Assert.Same(object? expected, object? actual)    |     0     | Verifies that objects **expected** and **actual** are the same instance |
| Assert.NotSame(object? expected, object? actual) |     0     | Verifies that objects **expected** and **actual** are not the same instance |