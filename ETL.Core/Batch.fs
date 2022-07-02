namespace Etl.Core
open System.Threading.Tasks
module Batch =
    type Status =
      | Next = 0
      | Done = 1     
    type Batch = int -> Task<Status>    
    let batch (batch: Batch) =
        let rec loop i =
             async {
                 match! batch i |> Async.AwaitTask with
                 | Status.Next -> return! loop (i + 1)
                 | _ ->  return () 
             }
        loop 0
        |> Async.StartAsTask
        :> Task
            
            