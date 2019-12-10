package aleksdevelopment.WeaponValue;
import java.util.Scanner;
public class Contestants  {
	static Scanner scan = new Scanner(System.in);
	private String name;
	
	private int powerStats;
	int health;
	int weaponUniqueNumber;
	boolean dead;
	
	
	
	Contestants(){
		System.out.print("enter name:");
		this.name=scan.nextLine();
		this.health=100;		
		this.powerStats=0;
		dead = false;
	}
	
	//method to change power during battle
	public void increasePowerStatsHealth(int powerValue) {
		this.health+=(this.powerStats+powerValue);
	}
	
	
	//method to update health during battle
	public void healthUpdate(int damage) {
			this.health-=damage;
	}
	
	
	public String presentName() {
		return this.name;
	}
	
	
	
	
	
	

}
