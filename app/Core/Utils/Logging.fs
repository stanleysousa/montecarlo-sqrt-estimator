namespace MCSqrtEstimator.Core.Utils

module Logging =

    let loggingAgent: MailboxProcessor<string> = MailboxProcessor.Start(fun inbox ->
          let rec messageLoop() = async{
              let! message = inbox.Receive()
              printfn "%s" message
              return! messageLoop()
          }
          messageLoop())

    type LoggingBuilder() =

        // Using the MailboxProcessor to fix parallel execution messing up the messages
        // - Output not using the MailboxProcessor:
        //      > trace: value = trace: value = trace: value = trace: value = trace: value = 524.053729.07.055.05330.0
        //      >
        //      >
        //      >
        //      >
        //      > trace: value = 534340.0
        //      > trace: value = 5347039.0
        //      > trace: value = 53456624.0
        // - Using the MailboxProcessor:
        //      > trace: value = 51.0
        //      > trace: value = 5281.0
        //      > trace: value = 53483.0
        //      > trace: value = 553.0
        //      > trace: value = 8.0
        //      > trace: value = 534392.0
        //      > trace: value = 5346721.0
        //      > trace: value = 53461839.0
        let log v =
            let message = sprintf "trace: value = %A" v
            loggingAgent.Post (message)

        member this.Bind(v, f) =
            log v
            f v

        member this.Return(v) = 
            v

