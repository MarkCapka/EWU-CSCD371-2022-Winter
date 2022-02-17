using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                return File.ReadAllLines("People.csv").Skip(1).ToList();//System.Reflection.Assembly.GetExecutingAssembly().Location; current will work but it relies on unsafe assumptions
            }
        }


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {

            // Define Query
            IEnumerable<string> stateQuery = (
                from line in CsvRows
                let columnSeparatedLines = line.Split(',')
                orderby columnSeparatedLines[6]
                select columnSeparatedLines[6]
                ).Distinct().ToList();

            //Execute Query
            IEnumerable<string> stateList = stateQuery;

            return stateList;

            //IEnumerable<string> temp = CsvRows;
            //IEnumerator<string> enumerator = temp.GetEnumerator();
            //List<string> uniqueStateList = new List<string>();

            //while (enumerator.MoveNext())
            //{
            //    string[] lineDelimited = enumerator.Current.Split(',');
            //    string State = lineDelimited[6].Trim();
            //    if (!uniqueStateList.Contains(State))
            //    {
            //        uniqueStateList.Add(State);
            //    }
            //    //Console.WriteLine(State);
            //}
            //uniqueStateList = (from State in uniqueStateList orderby State descending select State.Distinct<string>()).ToList();
            ////select distinct states with linq query

            //return uniqueStateList;
        }
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
