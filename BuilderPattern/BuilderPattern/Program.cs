using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    /// <summary>
    /// Builder pattern demo
    /// 
    /// The builder pattern is useful when
    ///   - Creating complex objects
    ///   - Object creation needs to be seperate from it's assembly
    ///   - Different representations need to be created with finer control
    ///   
    /// It is not appropriate in a lot of cases, where subclassing, refactoring or abstracted interfaces would be a better solution.
    /// 
    /// A situation where builder pattern could be useful though is if you have a bloated constructor with lots of computation setting fields etc.
    /// 
    /// It's also good for a finite number of representations which share complex object build requirements.
    /// 
    /// Implications:
    ///   - Lets you vary internal represenation of your concrete classes
    ///   - Isolates code for construction and represenation
    ///   - Gives finer control over the construction process
    ///   - Shares some DNA with the factory pattern, but builder pattern is focused on object creation in sequential steps
    /// </summary>
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Builder pattern demo starting");

            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining table", 105.0, 35.4, 100.6, 55.5)
            };


            /*This method is using the standard capabilities to do create the report in steps*/

            //Instantiate our concrete builder class and pass in our enumerable of items
            var inventoryBuilder = new DailyReportBuilder(items);

            //Instantiate our director class that provides the orderind of constructional steps
            var director = new InventoryBuildDirector(inventoryBuilder);

            //Use our director to actually create our complex object
            director.BuildCompleteReport();

            //Get the result of the complex object build
            var r = inventoryBuilder.GetDailyReport();
            
            /*This method is using the fluentBuilder capabilities to do everything in one line*/

            var fluentReport = inventoryBuilder.AddTitle().AddDimensions().AddLogistics(DateTime.Now).GetDailyReport();
            Console.WriteLine(fluentReport.Debug());
        }
    }
}
