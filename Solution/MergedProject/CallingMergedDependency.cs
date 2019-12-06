// ILMerge will merge any assemblies with Copy Local set to True
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agility.Sdk.Model.Jobs; //Copy Local is set to false for the KTA product references
using DependencyProject; //DependencyProject will be included in the main dll by using ILMerge
using TotalAgility.Sdk; //Copy Local is set to false for the KTA product references

namespace MergedProject
{
    // Each project builds into its own dll.
    // However the ILMerge task in this project (MergedProject), 
    // merges dependencies like DependencyProject into the end result dll.
    // Thus MergedProject.dll is larger and contains all the code of DepenencyProject as well.

    public class CallingMergedDependency
    {
        public string UseJobsFromDependency(string sessionId)
        {
            // This uses a dependency on the other project (DependencyProject),
            // but because DependencyProject is merged, MergedProject.dll has 
            // everything it needs to do this without the separate DependencyProject.dll.
            var dependency = new ExampleDependency();
            var jobs = dependency.GetSomeJobs(sessionId);
            return $"Dependent dll function returned {jobs.JobCount.ToString()} jobs";
        }


        public string UseJobsFromMainAssembly(string sessionId)
        {
            var j = new JobService();
            var jf = new JobFilter4();
            jf.MaxNumberToRetrieve = 100;
            var jobs = j.GetJobs4(sessionId, jf);
            return $"Main dll function returned {jobs.JobCount.ToString()} jobs";
        }


    }
}
