module FSAnalysis

#light

open System
open FSharp.Charting
open FSharp.Charting.ChartTypes
open System.Drawing
open System.Windows.Forms
//
// F# library to analyze Chicago crime data
//
// Syed Bukhari
// U. of Illinois, Chicago
// CS341, Fall2016
// Homework 5
//

//
// Parse one line of CSV data:
//
//   Date,IUCR,Arrest,Domestic,Beat,District,Ward,Area,Year
//   09/03/2015 11:57:00 PM,0820,true,false,0835,008,18,66,2015
//   ...
//
// Returns back a tuple with most of the information:
//
//   (date, iucr, arrested, domestic, area, year)
//
// as string*string*bool*bool*int*int.
//
let private ParseOneCrime (line : string) = 
  let elements = line.Split(',')
  let date = elements.[0]
  let iucr = elements.[1]
  let arrested = Convert.ToBoolean(elements.[2])
  let domestic = Convert.ToBoolean(elements.[3])
  let area = Convert.ToInt32(elements.[elements.Length - 2])
  let year = Convert.ToInt32(elements.[elements.Length - 1])
  (date, iucr, arrested, domestic, area, year)


// 
// Parse file of crime data, where the format of each line 
// is discussed above; returns back a list of tuples of the
// form shown above.
//
// NOTE: the "|>" means pipe the data from one function to
// the next.  The code below is equivalent to letting a var
// hold the value and then using that var in the next line:
//
//  let LINES  = System.IO.File.ReadLines(filename)
//  let DATA   = Seq.skip 1 LINES
//  let CRIMES = Seq.map ParseOneCrime DATA
//  Seq.toList CRIMES
//
let private ParseCrimeData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneCrime
  |> Seq.toList


//
// Given a list of crime tuples, returns a count of how many 
// crimes were reported for the given year:
//
let private CrimesThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (_, _, _, _, _, year) -> year = crimeyear) crimes
  let numCrimes = List.length crimes2
  numCrimes

     
//
// CrimesByYear:
//
// Given a CSV file of crime data, analyzes # of crimes by year, 
// returning a chart that can be displayed in a Windows desktop
// app:
//
let CrimesByYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  //
  // plot:
  //
  let myChart = 
    Chart.Line(countsByYear, Name="Total # of Crimes")
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl

let arrestsThisYear crimes crimeyear = 
    let crimes2 = List.filter (fun (_, _, arrested, _, _, year) -> ((year = crimeyear) && arrested)) crimes
    let numArrests = List.length crimes2
    numArrests

let ArrestVsYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  let counts2 = List.map(fun year -> arrestsThisYear crimes year) range
  let counts2ByYear = List.map2(fun year count -> (year, count)) range counts2
  //
  // plot:
  //
  let myChart =
    Chart.Combine([ 
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(counts2ByYear, Name= "# of Arrests")
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl

let checkContains iucrList code =
    let cCode = List.filter (fun aCode -> (String.Compare(aCode,code) = 0)) iucrList
    if ((List.length cCode) = 0) then false else true

let private ParseOneIUCR (line : string) = 
  let elements = line.Split(',')
  let iucr = elements.[0]
  let primaryDesc = elements.[1]
  let secondaryDesc = elements.[2]
  (iucr, primaryDesc, secondaryDesc)

let private ParseIUCR filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneIUCR
  |> Seq.toList


let crimeCodeThisYear crimes crimeyear code = 
        let crimes2 = List.filter (fun (_, iucr, _, _, _, year) -> ((year = crimeyear) &&  (String.Equals(iucr,code)))) crimes
        let numCrimes = List.length crimes2
        numCrimes

let rec getCodeDesc crimeCodes code = 
    match crimeCodes with
    |[] -> "unknown crime code"
    |(iucr, desc1, desc2)::tl when (String.Equals(iucr, code)) -> desc1 + ": " + desc2
    |hd::tl -> getCodeDesc tl code

let CrimeCodeVsYear filename file2 (code : string)= 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  let iucrs = ParseIUCR file2
  let counts2 = List.map(fun year -> crimeCodeThisYear crimes year code) range
  let counts2ByYear = List.map2 (fun year count2 -> (year, count2)) range counts2
  
  //
  // plot:
  //
  let myChart =
    Chart.Combine([ 
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(counts2ByYear, Name = (getCodeDesc iucrs code))
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl
 
let private ParseOneArea (line : string) = 
  let elements = line.Split(',')
  let iucr = Convert.ToInt32(elements.[0])
  let fullName = elements.[1]
  (iucr, fullName)

let private ParseAreas filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneArea
  |> Seq.toList

let crimesInAreaThisYear crimes crimeyear areaCode = 
        let crimes2 = List.filter (fun (_, _, _, _, area, year) -> ((year = crimeyear) &&  (area = areaCode))) crimes
        let numCrimes = List.length crimes2
        numCrimes

let rec getAreaCode areas areaDesc = 
    match areas with
    | [] -> 0
    |(number, desc)::tl when (String.Equals(desc,areaDesc)) -> number
    |hd::tl -> getAreaCode tl areaDesc

let CrimesInAreaVsYear filename file2 (areaString : string)= 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (_, _, _, _, _, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (_, _, _, _, _, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  let areas = ParseAreas file2
  let areaNum = getAreaCode areas areaString
  let counts2 = List.map(fun year -> crimesInAreaThisYear crimes year areaNum) range
  let counts2ByYear = List.map2 (fun year count2 -> (year, count2)) range counts2
  
  //
  // plot:
  //
  let myChart =
    Chart.Combine([ 
                     Chart.Line(countsByYear, Name="Total # of Crimes")
                     Chart.Line(counts2ByYear, Name = (areaString))
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl

let private TotalCrimeInArea crimes area = 
  let crimes2 = List.filter (fun (_, _, _, _, crimeArea, _) -> (crimeArea > 0) && (crimeArea = area)) crimes
  let numCrimes = List.length crimes2
  numCrimes

let AllCrimesByArea filename filename2 = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes1 = ParseCrimeData filename
  let areas = ParseAreas filename2
  let crimes = List.filter(fun (_, _, _, _, area, _) -> area > 0) crimes1
  //
  let (_, _, _, _, minArea, _) = List.minBy (fun (_, _, _, _, area, _) -> area) crimes
  let (_, _, _, _, maxArea, _) = List.maxBy (fun (_, _, _, _, area, _) -> area) crimes
  //
  let range  = [minArea .. maxArea]
  let counts = List.map (fun area -> TotalCrimeInArea crimes area) range
  let countsByYear = List.map2 (fun area count -> (area, count)) range counts
  
  //
  // plot:
  //
  let myChart = Chart.Line(countsByYear, Name="Total Crimes by Chicago Area")
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl