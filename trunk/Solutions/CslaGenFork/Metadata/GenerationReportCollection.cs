using System;
using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class GenerationReportCollection : List<GenerationReport>
    {
        public void AddMultiline(GenerationReport item)
        {
            var lines = item.Message.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                Add(new GenerationReport
                        {
                            ObjectName = item.ObjectName,
                            ObjectType = item.ObjectType,
                            Message = line,
                            FileName = item.FileName
                        });
            }
        }
    }
}
