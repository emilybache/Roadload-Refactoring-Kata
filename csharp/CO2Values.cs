namespace roadload
{
    public class CO2Values
    {
     
        public double? High_roadload_f0 { get; set; }
        public double? High_roadload_f1 { get; set; }
        public double? High_roadload_f2 { get; set; }
        public double? High_roadload_tm { get; set; }
        public double? High_roadload_combined { get; set; }
        
        public double? Mid_roadload_f0 { get; set; }
        public double? Mid_roadload_f1 { get; set; }
        public double? Mid_roadload_f2 { get; set; }
        public double? Mid_roadload_tm { get; set; }
        public double? Mid_roadload_combined { get; set; }

        public double? Low_roadload_f0 { get; set; }
        public double? Low_roadload_f1 { get; set; }
        public double? Low_roadload_f2 { get; set; }
        public double? Low_roadload_tm { get; set; }
        public double? Low_roadload_combined { get; set; }

        public bool IsMidPoint { get; set; }
        public bool IsSinglePoint { get; set; }
    }
}