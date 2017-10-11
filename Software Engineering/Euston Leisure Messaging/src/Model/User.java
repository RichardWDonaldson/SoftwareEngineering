package Model;


public class User {
   private String userID;
   
   public void setUserID(String value) {
      this.userID = value;
   }
   
   public String getUserID() {
      return this.userID;
   }
   
   private String firstName;
   
   public void setFirstName(String value) {
      this.firstName = value;
   }
   
   public String getFirstName() {
      return this.firstName;
   }
   
   private String surname;
   
   public void setSurname(String value) {
      this.surname = value;
   }
   
   public String getSurname() {
      return this.surname;
   }
   
   private String jobTitle;
   
   public void setJobTitle(String value) {
      this.jobTitle = value;
   }
   
   public String getJobTitle() {
      return this.jobTitle;
   }
   
   private String department;
   
   public void setDepartment(String value) {
      this.department = value;
   }
   
   public String getDepartment() {
      return this.department;
   }
   
   public String toString() {
      // TODO implement this operation
      throw new UnsupportedOperationException("not implemented");
   }
   
   }
