using Tetra;
using Tetra.Testing;

namespace Check.DataContextTests;

internal sealed class TestableDataContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestableDataContext Create()
      => new();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void CreateBinding<T>(string propertyName,
                                T      initialValue)
      => _bindings
        .Add(propertyName,
             Bind(propertyName,
                  initialValue));

   /* ------------------------------------------------------------ */

   public void CreateBinding<T>(string            propertyName,
                                IOneWayBinding<T> binding)
      => _bindings
        .Add(propertyName,
             Bind(propertyName,
                  binding));

   /* ------------------------------------------------------------ */

   public void CreateBinding<T>(string            propertyName,
                                ITwoWayBinding<T> binding)
      => _bindings
        .Add(propertyName,
             Bind(propertyName,
                  binding));

   /* ------------------------------------------------------------ */

   public T Pull<T>(string propertyName)
   {
      var hasBinding = _bindings.TryGetValue(propertyName,
                                             out var binding);

      if (!hasBinding)
      {
         throw Failed.InTestSetup($@"The testable data context does not have a binding with the name ""{propertyName}""");
      }

      return binding switch
             {
                Binding<T> direct              => direct.Pull(),
                OneWayBinding<T> oneWayBinding => oneWayBinding.Pull(),
                TwoWayBinding<T> twoWayBinding => twoWayBinding.Pull(),
                _                              => throw Failed.InTestSetup($@"By some madness ""{propertyName}"" is not a supported type of DataContext binding...")
             };
   }

   /* ------------------------------------------------------------ */

   public void Push<T>(string propertyName,
                      T      value)
   {
      var hasBinding = _bindings.TryGetValue(propertyName,
                                             out var binding);

      if (!hasBinding)
      {
         throw Failed.InTestSetup($@"The testable data context does not have a binding with the name ""{propertyName}""");
      }

      switch (binding)
      {
         case Binding<T> direct:
            direct.Push(value);
            break;

         case TwoWayBinding<T> twoWayBinding:
            twoWayBinding.Push(value);
            break;

         case OneWayBinding<T>:
            throw Failed.InTestSetup($@"""{propertyName}"" is a {nameof(OneWayBinding<T>)} which does not support setting");

         default:
            throw Failed.InTestSetup($@"By some madness ""{propertyName}"" is not a supported type of DataContext binding...");
      }
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<string, object> _bindings = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestableDataContext() { }

   /* ------------------------------------------------------------ */
}