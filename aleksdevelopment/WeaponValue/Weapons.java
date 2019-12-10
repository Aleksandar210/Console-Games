package aleksdevelopment.WeaponValue;

import java.util.Random;

public class Weapons  {
Random generate = new Random();
	
private String name;
private int damage;
int powerPercent;
private int uniqueNumber;


public Weapons(){
Random gen = new Random();
int generate = gen.nextInt(5);
generateWeapons(generate);

//assigning damage and power percentege
switch(this.name) {
case "FrozenDagger": this.damage=15;
					 this.powerPercent=5;
break;
case "FurySword": this.damage=25;
				  this.powerPercent=15;
break;
case "ShadowBow": this.damage=10;
					this.powerPercent=24;
break;
case "StoneHammer": this.damage=30;
					this.powerPercent=5;
break;
case "BloodSpear": this.damage=28;
					this.powerPercent=30;
break;
//

}






}

public void generateWeapons(int number) {
	
	switch(number) {
	case 0: this.name = "FrozenDagger";	
	this.uniqueNumber=0;
	break;
	case 1: this.name=  "FurySword";
	this.uniqueNumber=1;
	break;
	case 2: this.name = "ShadowBow";
	this.uniqueNumber=2;
	break;
	case 3: this.name = "StoneHammer";
	this.uniqueNumber=3;
	break;
	case 4: this.name = "BloodSpear";
	this.uniqueNumber=4;
	break;
	}
	
}


//this Happens when someone is hit (health is lowered by the damage done)
public int hit() {
	return this.damage;
}




//to get the weaponNumber us this function
public int getWeaponNumber() {
	return this.uniqueNumber;
}
public String showName() {
	return this.name;
}

}
