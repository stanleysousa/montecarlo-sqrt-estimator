namespace MCSqrtEstimator.Core.Models

//Another model implementation. Models could go into a models directory
module McOther =

     open MCSqrtEstimator.Core.Types

     [<Literal>]
     let private name =  "other"

     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValue v = infinity

     let estimate v n = Error "NotImplementedException"

     let getModel =
          {
               ModelName = name
               EstimatorFunc = estimate
               ExpectedValueFunc = expectedValue
          }