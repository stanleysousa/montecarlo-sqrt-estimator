namespace MCSqrtEstimator.Core.Models

//Another model implementation. Models could go into a models directory
module McOther =

     open MCSqrtEstimator.Core.Types

     [<Literal>]
     let private name =  "other"

     [<Literal>]
     let private inputMessage =  "What are the input constraints?"

     ///<summary>Validate inputs array according to model constraints</summary>
     let validateInputs args :  Result<array<string>, string> = Error "NotImplementedException"

     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValue v = infinity

     let estimate v n = Error "NotImplementedException"

     let getModel =
          {
               ModelName = name
               EstimatorFunc = estimate
               ExpectedValueFunc = expectedValue
          }