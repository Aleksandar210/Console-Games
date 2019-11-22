package java_Games;


import java.util.Scanner;
import java.util.Random;
import java.util.ArrayList;
import java.util.Arrays;

public class Main {
	static Scanner scan = new Scanner(System.in);
	public static void main(String args[]) {
	int lives = 6;
	System.out.println("HANG MAN game");
	System.out.println();
	System.out.println("pick category. ");
	System.out.println("1| vehicles");
	System.out.println("2| Animals");
	System.out.println("3| Buildings");
	int pick;
	
	do {
		System.out.print("chose category: ");
	pick = Integer.parseInt(scan.nextLine());
	}while(pick<1 || pick>3);
	startGame(setGame(pick),lives,pick);
	
	}
	
	
	static String[] setGame(int pick) {
		
		Random generate = new Random();
		String optionsAnimals[] = {"Dog","Cat","fish","turtle","dolphin","girafe","ostrich","elephant"};
		String optionsVehicles[] = {"car","truck","tank","ship","boat","motorcycle","snowmobile"};
		String optionsBuildings[] = {"school","hospital","office","firedepartment","police"};
		
		String word=" ";
		int  opt= 0;
		switch(pick) {
		case 1 : opt = generate.nextInt(optionsVehicles.length);
		word = optionsVehicles[opt];
		break;
		case 2: opt = generate.nextInt(optionsAnimals.length);
		word = optionsAnimals[opt];
		break;
		case 3: opt = generate.nextInt(optionsBuildings.length);
		word = optionsBuildings[opt];
		break;
		}
		
		
		
		int length = String.valueOf(word).length();
		String wordLeters[] = new String[length];
		
		int finsih=1;
		for(int i=0;i<length;i++) {
			wordLeters[i] = word.substring(i,finsih);
			finsih++;
		}
		
		
		return wordLeters;
	}
	
	
	static void startGame(String[] word,int lives,int pick) {
		int hpPoints =lives;
		
		boolean stop = true;
		String[] displayWord = new String[word.length];
		if(pick==1) {
		System.out.println("guess the letters    (category Vehicles)");
		}else if(pick==2) {
			System.out.println("guess the letters    (category: Animals)");
		}else if(pick==3) {
			System.out.println("guss the word        (category: Buildings)");
		}
		for(int i=0;i<displayWord.length;i++) {
			displayWord[i]="?";
			System.out.print(" "+displayWord[i]);
		}
		String enter;
		System.out.println();
		while(hpPoints>0) {
			boolean inside = false;
			if(Arrays.equals(displayWord,word)) {
				break;
			}
			System.out.println("            lives remaining:"+hpPoints);
		do {
			System.out.print("enter letter ");
		 enter = scan.nextLine();
		}while(enter.length()>1);
			
		
		for(int i=0;i<word.length;i++) {
			if(enter.equalsIgnoreCase(word[i])) {
				displayWord[i]=enter;
				inside=true;
			}
			
		}
			for(int i=0;i<displayWord.length;i++) {
				
				System.out.print(" "+displayWord[i]);
			}
			
		
		if(inside==false) {
			hpPoints-=1;
		}
		
		
		
	
		
		}
		System.out.println();
		System.out.println();
		if(hpPoints==0) {
			for( int i=0;i<word.length;i++) {
				System.out.print(word[i]);
			}
			}else {
				System.out.println();
				System.out.println("good job winning the game");
			}
		}
		
	}
	
		
		
		
	
		





		
	


	
	



			
		
