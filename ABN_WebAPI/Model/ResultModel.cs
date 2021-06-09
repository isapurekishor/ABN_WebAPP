namespace ABN_WebAPI.Model
{
    public class ResultModel
    {
        public decimal Radius { get; set; }
        public decimal Diameter { get; set; }
        public decimal Circumference { get; set; }
        public decimal Area { get; set; }
        public string Status { get; set; }
        public int Progress { get; set; }
    }
    public enum Status
    {
        Running,
        Failed,
        Completed
    }

    public enum Progress
    {
        First = 25,
        Second = 50,
        Third = 75,
        Complete = 100
    }

    public static class Constants
    {
        public const double Pi = 3.14159;
        public const int Di_Constant = 2;
        public const int Ci_Constant = 2;
    }

}
