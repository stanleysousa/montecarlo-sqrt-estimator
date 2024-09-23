namespace MCSqrtEstimator.Core

//Another model implementation. Models could go into a models directory
module McOther =

     open MCSqrtEstimator.Core.Types

     [<Literal>]
     let ModelName =  "other"

     [<Literal>]
     let InputMessage =  "What are the input constraints?"

     let estimate v n =
        EstimateFailure "NotImplementedException"

     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValueFunc = infinity 