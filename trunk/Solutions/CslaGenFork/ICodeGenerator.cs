using System;
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
        void GenerateProject(Metadata.CslaGeneratorUnit unit);
        event CodeGeneratorBase.GenerationInformationDelegate GenerationInformation;
        event CodeGeneratorBase.GenerationInformationDelegate Step;
        string TargetDirectory { get; set; }
    }
}
