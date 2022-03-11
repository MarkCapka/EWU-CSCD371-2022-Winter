using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingStuff.Tests
{

    public class ParallelTests
    {

        [TestMethod]
        public void MyTestMethod()
        {
            IEnumerable<string> members = typeof(Enumerable).GetMembers().Select(item => item.Name);

            int iterationCount = 0;


            //quick note on locks: see commented out code: 
            //object lockObject;


            //static is just a keyword saying that we aren't closing any members within the scope.

            // static bool filter(string item) //static has compiler check if there is shared data outside of this  expressoin that we might be concerned with. 
            bool filter(string item)   
            {
                //if we didn't do an Interlocked: we can use a lock: 
                    //lock (lockObject)         //leads to an object waiting for the next lock to complete 
                    //{                         //note: lock(iterationCount) would have an error since it is trying to lock a value
                    //    iterationCount++;
                    //}
                     //lock (lockObject)         //leads to an object waiting for the next lock to complete 
                    //{
                    //    iterationCount++;
                    //}
                    
                Interlocked.Increment(ref iterationCount); //while this is being incremented, makes the location inaccessible 

                //iterationCount++;       //error revealed that data that will be exposed, this is because we use the static keyword 
                return item[0] == 'S';
            };

            IEnumerable<string> membersBeginningWithS =
                members.AsParallel().Where(filter);




            //if IEnumerable would the method stop during this line to get the results?  
            //ultimately the line above with membersBeginningWithS doesn't run anything. 
            //#this is not a multithreaded operation

            //LINQ: if the result is an IEnumerable: it doesn't actually iterate through the items, it just sets up a query
            //essentially just setting a filter with a query on the data

            //Because of Deffered execution, execution doesn't actually start happening until we start iterating. 
            //only blocks to write the query, continues running while it is finding the items in the collection
            //
            //returns collection 







            //When we not want to use parallel? 
            //
            int count = membersBeginningWithS.Count();   //This is a multithreaded operation

            //NOTE It is an expensive operation to work with threads. 
            //if it isn't going to be faster to use threads, don't create threads. 


            //GENERAL PRINCIPLE ABOUT PERFORMANCE: 
            //those who think they are great programmers fall into the trap of thinking they should optimize their code. 

            //PREFER CODE READABILITY TO FAST CODE. 
            //THE ONLY TIME YOU SHOULD REALLY WORRY ABOUT PERFORMANCE OPTIMIZATION IS IF YOU HAVE A PERFORMANCE PROBLEM 


            //MICROSOFT HAS BUILT IN TOOLS FOR RUNNING PARALLEL OPERATIONS. SO WE DON'T NECESSARILY HAVE TO COMPENSATE FOR THIS.

        }
    }
}
