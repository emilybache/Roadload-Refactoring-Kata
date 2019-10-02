namespace Roadload
{
    public abstract class Co2Values
    {
        public double? HighRoadloadF0 { get; set; }
        public double? HighRoadloadF1 { get; set; }
        public double? HighRoadloadF2 { get; set; }
        public double? HighRoadloadTm { get; set; }
        public double? HighRoadloadCombined { get; set; }

        public double? MidRoadloadF0 { get; set; }
        public double? MidRoadloadF1 { get; set; }
        public double? MidRoadloadF2 { get; set; }
        public double? MidRoadloadTm { get; set; }
        public double? MidRoadloadCombined { get; set; }

        public double? LowRoadloadF0 { get; set; }
        public double? LowRoadloadF1 { get; set; }
        public double? LowRoadloadF2 { get; set; }
        public double? LowRoadloadTm { get; set; }
        public double? LowRoadloadCombined { get; set; }

        public bool IsMidPoint { get; set; }
        public bool IsSinglePoint { get; set; }
    }
}