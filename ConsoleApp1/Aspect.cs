namespace ConsoleApp1
{
    public class Aspect
    {
        public string MethodFullName { get; set; }
        public string MethodName { get; set; }
        public bool AfterRun { get; set; }
        public bool BeforeRun { get; set; }
        public string RunAssemblyName { get; set; }
        public string RunFullName { get; set; }
        public string RunMethod { get; set; }
    }
}