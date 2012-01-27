using System;
using CslaGenerator.Metadata;

namespace CslaGenerator
{
    public class CodeGeneratorBase
    {
        public delegate void GenerationInformationDelegate(string e);
    }

    interface ICodeGenerator
    {
        void Abort();
        event EventHandler Finalized;
        void GenerateProject(CslaGeneratorUnit unit);
        event CodeGeneratorBase.GenerationInformationDelegate GenerationInformation;
        event CodeGeneratorBase.GenerationInformationDelegate Step;
        string TargetDirectory { get; set; }
        GenerationReportCollection ErrorReport { get; }
        GenerationReportCollection WarningReport { get; }
    }
}
