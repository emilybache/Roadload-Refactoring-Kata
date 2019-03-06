namespace roadload
{
    public class CO2Values
    {
     
        public double? High_roadload_f0 { get; }
        public double? High_roadload_f1 { get; }
        public double? High_roadload_f2 { get; }
        public double? High_roadload_tm { get; }
        public double? High_roadload_combined { get; set; }
        
        public double? Mid_roadload_f0 { get; }
        public double? Mid_roadload_f1 { get; }
        public double? Mid_roadload_f2 { get; }
        public double? Mid_roadload_tm { get; }
        public double? Mid_roadload_combined { get; set; }

        public double? Low_roadload_f0 { get; }
        public double? Low_roadload_f1 { get; }
        public double? Low_roadload_f2 { get; }
        public double? Low_roadload_tm { get; }
        public double? Low_roadload_combined { get; set; }

        public bool IsMidPoint { get; set; }
        public bool IsSinglePoint { get; set; }
    }
}