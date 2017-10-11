package Model;


public class Email extends Message {
   private String subject;
   
   public void setSubject(String value) {
      this.subject = value;
   }
   
   public String getSubject() {
      return this.subject;
   }
   
   private String message;
   
   public void setMessage(String value) {
      this.message = value;
   }
   
   public String getMessage() {
      return this.message;
   }
   
   }
