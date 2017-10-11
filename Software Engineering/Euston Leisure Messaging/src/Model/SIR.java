package Model;


public class SIR extends Email {
   private String sportCentreCode;
   
   public void setSportCentreCode(String value) {
      this.sportCentreCode = value;
   }
   
   public String getSportCentreCode() {
      return this.sportCentreCode;
   }
   
   private int incidentType;
   
   public void setIncidentType(int value) {
      this.incidentType = value;
   }
   
   public int getIncidentType() {
      return this.incidentType;
   }
   
   }
