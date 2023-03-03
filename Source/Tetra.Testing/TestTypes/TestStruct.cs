using System.Diagnostics.CodeAnalysis;

namespace Tetra.Testing;

[ExcludeFromCodeCoverage]
public readonly struct TestStruct : IEquatable<TestStruct>
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly int    Value1;
   public readonly double Value2;

   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public TestStruct(int value1,
                     double value2)
   {
      Value1 = value1;
      Value2 = value2;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestStruct Create(int value1,
                                   double value2)
      => new(value1,
             value2);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => obj is TestStruct other
      && Equals(other);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => HashCode
        .Combine(Value1,
                 Value2);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => $"struct({Value1}, {Value2})";

   /* ------------------------------------------------------------ */
   // IEquatable<TestStruct> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(TestStruct other)
      => Value1.Equals(other.Value1)
      && Value2.Equals(other.Value2);

   /* ------------------------------------------------------------ */
   // IEquatable<TestStruct> Operators
   /* ------------------------------------------------------------ */

   public static bool operator ==(TestStruct left,
                                  TestStruct right)
      => Equals(left,
                right);

   /* ------------------------------------------------------------ */

   public static bool operator !=(TestStruct left,
                                  TestStruct right)
      => !Equals(left,
                 right);

   /* ------------------------------------------------------------ */
}