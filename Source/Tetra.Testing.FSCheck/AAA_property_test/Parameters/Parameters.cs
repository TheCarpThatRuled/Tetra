namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   public sealed partial class Parameters
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IReadOnlyDictionary<object, object?> _parameters;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Parameters
      (
         IReadOnlyDictionary<object, object?> parameters
      )
         => _parameters = parameters;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static DefineParameters Factory()
         => new();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public string SubstituteParametersForValues
      (
         string characterisation
      )
         => _parameters
           .Aggregate(characterisation,
                      (
                         current,
                         parameter
                      ) => current.Replace(parameter.Key.ToString()!,
                                           parameter.Value?.ToString()));

      /* ------------------------------------------------------------ */

      public T Retrieve<T>
      (
         Parameter<T> parameter
      )
         => parameter
           .Value
           .Unify(Function.PassThrough,
                  () =>
                  {
                     if (!_parameters.TryGetValue(parameter,
                                                  out var value))
                     {
                        throw Failed
                             .InTheActions($@"The parameters do not contain an entry for {parameter}")
                             .ToAssertFailedException();
                     }

                     if (value is not T typedValue)
                     {
                        throw Failed
                             .InTheActions($@"The entry for {parameter} is not a {typeof(T).Name}, it is a {value?.GetType().FullName}")
                             .ToAssertFailedException();
                     }

                     return typedValue;
                  });

      /* ------------------------------------------------------------ */
   }
}