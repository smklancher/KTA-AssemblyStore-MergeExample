// ILMerge will merge any assemblies with Copy Local set to True
using Agility.Sdk.Model.Jobs; //Copy Local is set to false for the KTA product references
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalAgility.Sdk; //Copy Local is set to false for the KTA product references

namespace DependencyProject
{
    public class ExampleDependency
    {
        public JobList GetSomeJobs(string sessionId)
        {
            //This is called from the main project.
            //When merged it will be part of the same dll.
            var j = new JobService();
            var jf = new JobFilter4();
            jf.MaxNumberToRetrieve = 100;
            return j.GetJobs4(sessionId, jf);
        }
    }
}
