namespace Tetra;

partial class Option<T>
{
   private sealed class SomeOption : Option<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SomeOption(T content)
         => _content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SomeOption some => Equals(some._content),
               T content => Equals(content),
               _               => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _content
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Some ({_content})";

      /* ------------------------------------------------------------ */
      // IEquatable<Option<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Option<T>? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               SomeOption some => Equals(some._content),
               _               => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => Equals(_content,
                   other);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> _,
                                        Func<T, TNew> whenSome)
         => whenSome(_content);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly T _content;

      /* ------------------------------------------------------------ */
   }
}