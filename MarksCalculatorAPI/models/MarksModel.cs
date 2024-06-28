namespace MarksCalculatorAPI.Models
{
    public class MarksModel
    {
        public string Subject { get; set; }
        public double Marks { get; set; }
        public double MaxMarks { get; set; }
        public double Percentage { get; set; }

        public MarksModel(string subject, double marks, double maxMarks)
        {
            Subject = subject;
            Marks = marks;
            MaxMarks = maxMarks;
            Percentage = (marks / maxMarks) * 100;
        }
    }
}
