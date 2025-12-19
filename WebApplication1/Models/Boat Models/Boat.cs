namespace WebApplication1.Clubs_Boats.models
{
    
    public class Boat
    {
        
        public int Id { get; set; }
        
       
        public string Name { get; set; } = string.Empty;
        
        // Hvilken type båd det er - bruger BoatType enum
        public BoatType BoatType { get; set; } = BoatType.Sejlbåd;
        
        // Model-nummer eller model-år
        public double Model { get; set; } = 0;
        
      
        public int YearBuilt { get; set; } = 0;
        
        
        public int Capacity { get; set; } = 0;
        
        
        public decimal Price { get; set; } = 0;

        // Status på båden - bruger BoatStatus enum
        public BoatStatus Status { get; set; } = BoatStatus.Available;
        
        // Beskrivelse af motor
        public string EngineDescription { get; set; } = string.Empty;
        
        // Mål i meter
        public decimal Length { get; set; } = 0;  
        public decimal Width { get; set; } = 0;   
        public decimal Height { get; set; } = 0;  
        
        // Vægt i kg
        public decimal Weight { get; set; } = 0;
        
        // Liste over alle vedligeholdelser udført på denne båd
        public List<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

        // Enum er det der definerer mulige status-værdier for en båd
        public enum BoatStatus
        {
            Available,    
            Unavailable,     
            UnderMaintenance  
        }
    }
}
