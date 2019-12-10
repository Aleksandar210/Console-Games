package aleksdevelopment.WeaponValue;

import java.util.Scanner;

import java.util.Random;


public class Competition {
static Scanner scan = new Scanner(System.in);
	public static void main(String args[]) {
		System.out.println("   Welcome to the arena!");
		System.out.print("5 contestants joined the arena|  ");
		System.out.println();
		int numberContestants = 5;
		Contestants fighters[] = new Contestants[numberContestants];
		for(int i=0;i<fighters.length;i++) {
			
			
			fighters[i]=new Contestants();
		}
		Weapons weapons[] = new Weapons[5];
		for(int i =0;i<weapons.length;i++) {
			weapons[i]=new Weapons();
		}
		for(int i=0;i<numberContestants;i++) {
			fighters[i].weaponUniqueNumber=weapons[i].getWeaponNumber();
			fighters[i].increasePowerStatsHealth(weapons[i].powerPercent);
		
		}
		boolean exit=false;
		while(exit==false) {
		
		System.out.println("1| start the competition");
		System.out.println("2| End the competition");
		System.out.println("3| see the contestants ");
		System.out.print("pick:");
		int choice;
		do {
			
		
		 choice=Integer.parseInt(scan.nextLine());
		}while(choice<1 ||  choice >3);
		
		switch(choice) {
		
		case 1: 
			
			boolean end = false;
			Random duel = new Random();
			int fighter1 = duel.nextInt(numberContestants);
			int fighter2 = duel.nextInt(numberContestants);
			
			
			while(end==false) {
			
				System.out.println(fighters[fighter1].presentName()+" "+"using "+weapons[fighter1].showName());
				System.out.println();
				System.out.println("         VERSUS ");
				System.out.println(fighters[fighter2].presentName()+" "+"using "+weapons[fighter2].showName());
				System.out.println();
				System.out.print(fighters[fighter1].presentName()+"'s health| "+fighters[fighter1].health+"|"+"                                                          "+fighters[fighter2].presentName() +"'s health |"+fighters[fighter2].health+"|");
				System.out.println();
				
				int turn = duel.nextInt(2);
				System.out.println("          prsEntr");
				scan.nextLine();
				if(turn==0) {
					System.out.println(fighters[fighter1].presentName()+"  is attacking");
					fighters[fighter2].health-=weapons[fighter1].hit();
				}else {
					System.out.println(fighters[fighter2].presentName()+" is attacking");
					fighters[fighter1].health-=weapons[fighter2].hit();
				}
				
				if(fighters[fighter1].health<=0 || fighters[fighter2].health<=0) {
					if(fighters[fighter1].health<=0) {
					fighters[fighter1].dead=true;
					end=true;
					}else if(fighters[fighter2].health<=0) {
						fighters[fighter2].dead=true;
						end=true;
						
					}
					
				}
				
				
				
				
				
			}
			
			break;
			
		case 2:  
			
			System.out.println("    Competiton is over!!");
			System.out.println("RESULTS:");
			for(int i=0;i<numberContestants;i++) {
				System.out.print(fighters[i].presentName()+" "+"|");
				if(fighters[i].dead==true) {
					System.out.println("DEAD"+"|");
				}else {
					System.out.println("ALIVE"+"|");
				}
			}
			
			exit=true;
		break;
		
		case 3:
			for(int i=0;i<numberContestants;i++) {
			System.out.println(fighters[i].presentName()+" using "+weapons[i].showName());
		}
		break;
			
		}
			System.out.println();
			System.out.println("continue..  prsEntr");
			scan.nextLine();
		}
	}
	
}
