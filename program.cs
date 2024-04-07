using System;
using System.Collections.Generic;
using System.IO;
					
public class Program
{
	public static void Main()
	{	
		
		//set up character deails and story beggining na dask for name and age
		Console.WriteLine("*****Welcome to the RPG Game*****\n \nPLEASE, READ CAREFULLY \nThis is a fun and interactive game to let the users choose their role and action on a small and adventurous path of choices. \nYou'll be presented with different situations in which you will your your skills, previously earned, to face danger or even hard decitions. \nAll choices will give you experience or items and will chain to different results. \nBe wise is my advise to you \n");
		Console.WriteLine("Please write your name");
		string name = Console.ReadLine();
		Console.WriteLine($"Hi {name}, please write your age");
		string y = Console.ReadLine();
		int age = int.Parse(y);
		Console.WriteLine($"\nHi {name}, in every adventure there are roles. Please select the class you'll take for this adventure: \n(Select a number)");
		Console.WriteLine("1.Paladin \n2.Mage \n3.Berseker \n4.Assasing");
		string x = Console.ReadLine();
		int classs = int.Parse(x);
		Character prota;
		
		//Select class and atributes of the character
		
		if(classs == 1){
			Console.WriteLine("So you choose to be a Paladin, eh?");
			prota = new Character(name,age,9,10,7,8,11);
		} else if (classs == 2){
			Console.WriteLine("So you choose to be a Mage, eh?");
			prota = new Character(name,age,5,8,8,8,15);
		}else if (classs == 3){
			Console.WriteLine("So you choose to be a Berseker, eh?");
			prota = new Character(name,age,12,12,4,8,6);
		}else if (classs == 4){
			Console.WriteLine("So you choose to be a Assasing, eh?");
			prota = new Character(name,age,7,8,6,13,13);
		}else{
			Console.WriteLine("You are a regular human now then");
			prota = new Character(name,age,5,5,5,5,5);
		}
		//Console.WriteLine("");
		Console.WriteLine("\nThe game starts... \n \n'Mom used to tell me stories of an ancient war, wispers of lost memories, long to be remembered, yet belived to be truth amoung the elders of the capital. The forces of good and evil fought for the powers of the primorial seed, a cristal with the power to grand a wish to whom ever touches it. \nI loved to hear the tales of my ancestors and I always believed to be true. It is told that the crystal was lost in the ruins of the Alcanor, at the bottom of the great maze. I believe that story to be true. The evil forces have taken power over this lands and I've decided to start my journey to find the crystal and ask for the power to free my people.  ");
		Console.WriteLine($"\n{prota.Name}, you've chosen your path and you will start this adventure in a small town in the East of Sileniah, land of the silver wind. You are an apprentice of {x}. You'll be presented with some scenarios. Choose well and yoyu may accomplish your goal... ");
		
		Inventory backpack = new Inventory();				//Bag inventory created
		int action = 0;	
		
		Console.WriteLine("Sun is hiding already\n you prepared everthing for your leave. Your home will be empty after your depart. You see on top of the table a shield, a wand, and a knife.\n Which one you take with you?");
		Console.WriteLine("\n1.Shield \n2.Wand \n3.Knife");
		string m = Console.ReadLine();
		action = int.Parse(m);
		if(action == 1){
			backpack.add_tobackpack("Shield");	
		}else if(action == 2){
			backpack.add_tobackpack("Wand");	
		}else{
			backpack.add_tobackpack("Knife");	
		}
		
		backpack.display_backpack();
		
		Console.WriteLine("\n Now you see a piece of paper and think of writting a small letter in case someone looks after you. Will you write a note? (Y/N)");
		while(m.ToLower() != "yes" || m.ToLower() != "no" ){
			m = Console.ReadLine();
			if(m.ToLower() == "yes"){
				Console.WriteLine("\nWrite the text here:");
				var text = Console.ReadLine();
				string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				// Append text to an existing file named "WriteLines.txt"
				using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "testament.txt"), true))
				{
					outputFile.WriteLine(text);
				}
				break;
					
			}else if(m.ToLower() == "no"){
				break;
			}else{
			Console.WriteLine("\n Please answer yes or no.\n");
			}
		}
		
 
		Console.WriteLine("\nYou grab you handbag and leave the note in the table. YOu go outside and leave your home to unknown roads in search of the relique. The night is near and after walking for hours, you finally see the woods and your land behind, fear is ahead but you choose to continue.\nIts dark and you barely see, the light of the moon allows you to travel but the silent reigns between the trees. Its suspicious. \nOut of nowhere a dagger is thrown to you from the shadows, what do you decide to do? ");
		Console.WriteLine("\n1.Dodge \n2.Block");
		m = Console.ReadLine();
		action = int.Parse(m);
		
		if(action == 1){
			if(prota.Spd<10){
				Console.WriteLine("\nYou tried to dodge it, you it was so fast that it hit you elbow. YOur speed is not that sharp now");
				Console.WriteLine($"\nHP - 20 \n(HP left:{prota.HP})");
			}
		
		}else if(action == 2){
			if(backpack.find_item("Shield")){
				Console.WriteLine("You succesfully blocked it with your shield. Your life points are safe.");
			}else if(prota.Int>10){
				Console.WriteLine("You didnt have a shiled but you knnew a spell to summon one. It protected you and your life poins");
			}else if(prota.Str>10){
				Console.WriteLine("You tried using you hands to proctect you. It saved you but you still got some injuries");
				Console.WriteLine($"\nHP - 10 \n(HP left:{prota.HP})");
			}
			
		}
		
		Console.WriteLine("\nFrom the shadows emerge an assasing with a long sword. What do you do?");
		Console.WriteLine("\n1.Use your strengh \n2.Cast a spell \n3.Block the attack and quickly counter.");
		m = Console.ReadLine();
		action = int.Parse(m);
		
		if(action == 1){
			if(prota.Str>8){
				Console.WriteLine("\nThe Assasing approaches but you se your hability to redirect the blow and grab him in the neck and smash him into the ground, knocked.");
			}
		
		}else if(action == 2){
			if(prota.Int > 10){
				Console.WriteLine("You create a fire ball and throw it to the assasing making him run away in the shadows.");
			}
		}else if(action == 3){
			if(prota.Int>10 || backpack.find_item("Shield")){
				Console.WriteLine("You shield yourself and hit back. The assasing drops the weapon afterwars and hides back into the woods.");
			}
		}
		
		Console.WriteLine("\nThe assasing got away but he dropped the weapon. You take it and save it. You think you may use it in the future.");
		backpack.add_tobackpack("Long Sword");
		backpack.display_backpack();
		
		
		Console.WriteLine("\nNow you continue your road, always waching around for if the strange assasin returns. After traveling several hours, you finally reach a crossed road. In the middle of it you find a dirty paper in the muddy soild. You decide to take it and read it:\n");
		var content = File.ReadAllText("hello.txt");
		Console.WriteLine(content);
		
		Console.WriteLine("\nThe messague is clear. You see the path in front of you and then look back where your home is. Will you take the crossroad or will you return?\n");
		
		Console.WriteLine("To Be continued...");

		
}

class Character
{
	public string Name { get; set;}
	public int Age { get; set;}
	public int Str { get; set;}
	public int Vit { get; set;}
	public int Dex { get; set;}
	public int Int { get; set;}
	public int Spd { get; set;}
	public double HP {get;set;}
	public Character (string name, int age, int str, int vit, int dex, int spd, int intl){
		Name = name;
		Age = age; 
		Str = str;
		Vit = vit;
		Dex = dex;
		Int = intl;
		Spd = spd;
		HP = dex * 10;		
	}	
	public void decrease_life_points(double amount){
		HP = HP - amount;
	}
	
	public void get_status(){
		Console.WriteLine($"{Name}, your stats are: \nstr:{Str}\nvit{Vit}\nDex:{Dex}\nint:{Int}\nSpd:{Spd}");
	}
}

class Inventory
{
	public List<string> backpack = new List<string>();
	public void display_backpack(){
		Console.WriteLine("\nItems in Backpack:");
		for (int i = 0; i < backpack.Count; i++)
            Console.WriteLine(backpack[i]);
	}
	
	public void add_tobackpack(string item){
		backpack.Add(item);	
	}
	
	public bool find_item(string item){
		return backpack.Contains(item);
	}	
}

}