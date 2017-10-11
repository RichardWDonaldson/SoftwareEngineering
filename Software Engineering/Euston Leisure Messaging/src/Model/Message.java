package Model;


public class Message {
   private String time;
   
   public void setTime(String value) {
      this.time = value;
   }
   
   public String getTime() {
      return this.time;
   }
   
   private String date;
   
   public void setDate(String value) {
      this.date = value;
   }
   
   public String getDate() {
      return this.date;
   }
   
   private User sender;
   
   public void setSender(User value) {
      this.sender = value;
   }
   
   public User getSender() {
      return this.sender;
   }
   
   private User receiver;
   
   public void setReceiver(User value) {
      this.receiver = value;
   }
   
   public User getReceiver() {
      return this.receiver;
   }
   
   public String toString() {
      // TODO implement this operation
      throw new UnsupportedOperationException("not implemented");
   }
   
   }
