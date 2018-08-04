namespace transporte.Service.Models
{
    public class Line
    {
        public string lineNumber { get; set; }
        public string source { get; set; }
        public string lineBound { get; set; }
        public bool isNightLine { get; set; }
        public string waitTime { get; set; }
    }
}