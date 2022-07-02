namespace Etl.Core
open System.Threading.Tasks
module Batch =
  type Status =
      | Next = 0
      | Done = 1
  type Batch = int -> Task<Status>
  val batch : Batch -> Task
    