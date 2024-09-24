namespace MCSqrtEstimator.Core

//Another model implementation. Models could go into a models directory
module McOther =

     open MCSqrtEstimator.Core.Types

     [<Literal>]
     let ModelName =  "other"

     [<Literal>]
     let InputMessage =  "What are the input constraints?"

     ///<summary>Validate inputs array according to model constraints</summary>
     let validateInput = Error "NotImplementedException"

     ///<summary>Calculates the expected value for square root of 'v'.</summary>
     let expectedValueFunc = infinity

     let estimate v n = Error "NotImplementedException"