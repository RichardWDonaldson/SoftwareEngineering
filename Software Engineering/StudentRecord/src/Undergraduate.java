
public class Undergraduate extends Student {
public String toString() {
   return "\nMatric: " + this.getMatric() +
		   "\nName: " + this.getName() + 
		   "\nProgramme: " + this.getProgramme() + 
		   "\nYear: " + this.getYear() +
		   "\nCourse Duration: " + this.getCourseDuration();
   }
   
   private String year; 
   
   public void setYear(String value) {
      this.year = value;
   }
   
   public String getYear() {
      return this.year;
   }
   
   private int courseDuration;
   
   public void setCourseDuration(int value) {
      this.courseDuration = value;
   }
   
   public int getCourseDuration() {
      return this.courseDuration;
   }
   
   }
