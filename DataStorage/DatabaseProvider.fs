module DatabaseProvider

open System
open System.Data.Entity
open System.IO
open System.Data.Linq
open System.Reflection
open Microsoft.FSharp.Data.TypeProviders

let location = Assembly.GetExecutingAssembly().Location
let dbpath = Path.Combine(Path.GetDirectoryName(location), "WarhammerQuest.sdf")

let connectionString = "metadata=res://*/;provider=System.Data.SqlServerCe.4.0;provider connection string='data source=" + dbpath + "';"

type internal edmx = EdmxFile<"WarhammerQuestModel.edmx", "../Database">
let internal context = new edmx.WarhammerQuestModel.WarhammerQuestEntities(connectionString)