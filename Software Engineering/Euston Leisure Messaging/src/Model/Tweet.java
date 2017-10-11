package Model;


public class Tweet extends Message {
   private String message;
   
   public void setMessage(String value) {
      this.message = value;
   }
   
   public String getMessage() {
      return this.message;
   }
   
   }
